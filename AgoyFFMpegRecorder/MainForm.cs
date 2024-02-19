using AgoyFFMpegRecorder.Helpers;
using Common.DataModels;
using Common.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgoyFFMpegRecorder
{
    public partial class MainForm : Form
    {
       
        VideoSourceModel curVideoSrc = null;
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        
        FFMpegHelper ffMpegHelper = null;
        AppConfig config;
        BackgroundRecorder2 recorder;
        string selectedAudioSource = "";
        bool notifyPopupAppeared = false;
        RecFileEntry recFile;
        bool isRecording = false;
        public MainForm()
        {
            InitializeComponent();
            recFile = new RecFileEntry() { overrideDefaultName = false };
            updateNextFileName();

            SetRecStatusInUI(false);

        }

        public delegate void UpdateDelegate(object sender, UpdateEventArgs args);

        private void notifyIcon2_DoubleClick(object Sender, EventArgs e)
        {
            // Show the form when the user double clicks on the notify icon.

            // Set the WindowState to normal if the form is minimized.
            if (this.WindowState == FormWindowState.Minimized)
                this.WindowState = FormWindowState.Normal;

            // Activate the form.
            this.Activate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            string curDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string appConfigFile = Path.Combine(curDir, "AppConfig.xml");
            if (!File.Exists(appConfigFile))
            {
                logger.Error($"Can't find App config file: {appConfigFile}");
                MessageBox.Show($"Can't find config file: {appConfigFile}", "Error");
                return;
            }
            logger.Debug($"AppConfig file found.");
            config = SerializerHelper.DeserializeFromXmlFile<AppConfig>(appConfigFile);
            ffMpegHelper = new FFMpegHelper(config.FFMpegPath);
            recorder = new BackgroundRecorder2(ffMpegHelper, config, stopRecCallback, recTimeChangedCallback);
            (List<string> videoSourcesNames, List<string> audioSourcesNames) = ffMpegHelper.GetAvailableSources();

            config.Audio.AvailableAudioSources = audioSourcesNames;
            config.Save();
            config.Audio.SetActiveAudioSrc();
            lblSelectedAudioSrc.Text = config.Audio.CurrentAudioMicSrc;
            lblIsCombineAudio.Text = config.Audio.IsCombiningAudio ? "Yes" : "No";

            foreach (string videoSrc in videoSourcesNames)
            {
                if (config.AvailableVideoSources.Any(s => s.sourceName == videoSrc)) continue; // source already in config/
                (int width, int height) = ffMpegHelper.getVideoSourceResolution(videoSrc);
                VideoSourceModel src = new VideoSourceModel() { sourceName = videoSrc, maxWidth = width, maxHeight = height, fps = 30, ratio = (double)width / (double)height };
                config.AvailableVideoSources.Add(src);
                config.Save();
            }
            lblSelectedVideoSrc.Text = config.SelectedVideoSource.sourceNameWithResolution;

        }


        private void btnStartRec_Click(object sender, EventArgs e)
        {
            curVideoSrc = config.SelectedVideoSource;
            SetRecStatusInUI(true);
            DateTime now = DateTime.Now;
            string recordFilePath = Path.Combine(config.RecordingBaseDir, $"Rec_{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}-{now.Second}.mp4");

            if(recFile.overrideDefaultName)
            {
                logger.Debug($"Override default name is true. Name is: {recFile.newName}");
                recordFilePath = Path.Combine(config.RecordingBaseDir, recFile.newName);
                recFile.overrideDefaultName = false;
                updateNextFileName();

            }
            else
            {
                logger.Debug($"Override default name is false.");
            }
            recFile.curName = Path.GetFileName(recordFilePath);
            if (config.Audio.IsCombiningAudio)
            {
                logger.Debug($"Starting to record video with 2 audio sources");
                recorder.startRecordingWith2AudioSources(recordFilePath,config.Audio.CurrentAudioMicSrc,config.Audio.ComputerAudioSourceName, curVideoSrc);

            }
            else
            {
                logger.Debug($"Starting to record video with 1 video source");
                recorder.startRecordingWith1AudioSource(recordFilePath,config.Audio.CurrentAudioMicSrc, curVideoSrc);
            }
            isRecording = true;
            logger.Debug($"Clicked 'Start Recording' button.");
        }

        private void btnStopRec_Click(object sender, EventArgs e)
        {
            logger.Debug($"Will stop recording...");
            SetRecStatusInUI(false);
            recorder.stopRecording();
            isRecording = false;
            renameRecFileIfNeeded();

            logger.Debug($"Stopped recording files.");
        }

        public void stopRecCallback()
        {
            logger.Debug($"stopRecCallback invoked!");
            isRecording = false;
            SetRecStatusInUI(false);
            renameRecFileIfNeeded();
        }

        public void renameRecFileIfNeeded()
        {
            if (recFile.overrideDefaultName)
            {
                recFile.overrideDefaultName = false;
                updateNextFileName();

                logger.Debug($"Will rename rec file from {recFile.curName} to  {recFile.newName}");
                try
                {
                    File.Move(Path.Combine(config.RecordingBaseDir, recFile.curName), Path.Combine(config.RecordingBaseDir, recFile.newName));
                    logger.Debug($"Successfully renamed file");
                }
                catch (Exception ex)
                {
                    logger.Error($"Failed to rename file from {recFile.curName} to {recFile.newName} | Ex: {Environment.NewLine}{ex.ToString()}");
                }
            }
            else logger.Debug($"Override default name is false -> will not rename rec file.");
        }

        private void updateNextFileName()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    tbNextFileName.Text = recFile.overrideDefaultName ? recFile.newName : "<default>";
                });
            }
            else
            {
                tbNextFileName.Text = recFile.overrideDefaultName ? recFile.newName : "<default>";
            }
        }

        public void recTimeChangedCallback(string recordingLengthStr)
        {
            logger.Debug($"recTimeChangedCallback invoked!, recording length: {recordingLengthStr}");
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    StatusMenu.Text = $"Status: Recording for {recordingLengthStr}";
                    lblRecordingFor.Text = recordingLengthStr;
                });
            }
            else
            {
                StatusMenu.Text = $"Status: Recording for {recordingLengthStr}";
                lblRecordingFor.Text = recordingLengthStr;

            }
        }

        private void SetRecStatusInUI(bool isStartingRec)
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateControls(isStartingRec);
                });
            }
            else
            { 
                updateControls(isStartingRec);
            }
        }

        private void updateControls(bool isStartingRec)
        {
            StatusMenu.Text = isStartingRec ? "Status: Recording" : "Status: Stopped";
            btnStopRec.Enabled = isStartingRec;
            stopRecordMenu.Enabled = isStartingRec;
            stopRecAfter.Enabled = isStartingRec;
            btnStartRec.Enabled = !isStartingRec;
            startRecordMenu.Enabled = !isStartingRec;
            //lblStatus.Text = isStartingRec ? "Recording..." : "Stopped";
            this.notifyIcon1.Icon = isStartingRec ?  Properties.Resources.pacifier_red : Properties.Resources.pacifier_big;
            this.notifyIcon1.Text =  isStartingRec ? "Agoy Recorder - Recording" : "Agoy Recorder - Idle";
            if (!isStartingRec) lblRecordingFor.Text = "n/a";

            if(isStartingRec)
            {
                lblStatus.Text = "Recording...";
                lblStatus.Font = new Font(Label.DefaultFont, FontStyle.Bold);
                lblStatus.ForeColor = Color.Red;
            }
            else
            {
                lblStatus.Text = "Stopped";
                lblStatus.Font = new Font(Label.DefaultFont, FontStyle.Regular);
                lblStatus.ForeColor = Color.Black;
            }
        }

        private void audioSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AudioSourceForm audioSourceForm = new AudioSourceForm(ffMpegHelper, config);
            audioSourceForm.ShowDialog();
            lblSelectedVideoSrc.Text = config.SelectedVideoSource.sourceNameWithResolution;
            
            lblSelectedAudioSrc.Text = config.Audio.CurrentAudioMicSrc;
            lblIsCombineAudio.Text = config.Audio.IsCombiningAudio ? "Yes" : "No";
        }

        private void videoSourceToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoSourceForm videoSourceForm = new VideoSourceForm(ffMpegHelper, config);
            videoSourceForm.ShowDialog();
            lblSelectedVideoSrc.Text = config.SelectedVideoSource.sourceNameWithResolution;
            

        }

        private void recordingParametersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            VideoRecordingParamsForm1 videoRecordingParamsForm1 = new VideoRecordingParamsForm1();
            videoRecordingParamsForm1.ShowDialog();

        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {

                Show();
                this.WindowState = FormWindowState.Normal;
                notifyIcon1.Visible = false;


            }
               
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }

        private void MainForm_Resize(object sender, EventArgs e)
        {
            if (FormWindowState.Minimized == this.WindowState)
            {
                notifyIcon1.Visible = true;
                if(!notifyPopupAppeared)
                {
                    notifyPopupAppeared = true;
                    notifyIcon1.ShowBalloonTip(500, "Agoy Recorder", "Left-click to open main config. Right-click for Recording menu", new ToolTipIcon());
                }
                this.Hide();
            }

            else if (FormWindowState.Normal == this.WindowState)
            {
                notifyIcon1.Visible = false;
            }
        }

        private void IconMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void IconContexMenu_Opening(object sender, CancelEventArgs e)
        {

        }

        private void startRec_Click(object Sender, EventArgs e)
        {
            btnStartRec_Click(null, null);
        }

        private void stopRec_Click(object Sender, EventArgs e)
        {
            btnStopRec_Click(null, null);
        }
        
        private void openMainWindow_Click(object Sender, EventArgs e)
        {
            Show();
            this.WindowState = FormWindowState.Normal;
            notifyIcon1.Visible = false;
        }        
        private void exitApp_Click(object Sender, EventArgs e)
        {
            this.Close();
        }

        private void stopAfter_1min_Click(object Sender, EventArgs e)
        {
            scheduleToStopAfter(1);
        }
        
        private void stopAfter_1hour_Click(object Sender, EventArgs e)
        {
            scheduleToStopAfter(60);
        }
        
        private void stopAfter_2hours_Click(object Sender, EventArgs e)
        {
            scheduleToStopAfter(120);
        }


        private void scheduleToStopAfter(int minutes)
        {
            logger.Debug($"Scheduled to stop recording after {minutes} min");
            recorder.scheduleToStopAfter(minutes);

        }

        private void renameCurOrNextRecording(object Sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            if (!isRecording) recFile.curName = $"Rec_{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}-{now.Second}.mp4";
            RenameRecFileForm renameForm = new RenameRecFileForm(recFile);
            
            renameForm.ShowDialog();

            updateNextFileName();
        }

        private void btnChangeName_Click(object sender, EventArgs e)
        {
            renameCurOrNextRecording((object) sender, e);
        }

        private void btnOpenRecDir_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", config.RecordingBaseDir);
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            logger.Debug($"Closing App. Will stop recording if it is running..");
            if (isRecording)
            {
                btnStopRec_Click(null, null);
                logger.Debug($"Stopped recording. Will close now. ");
            }
            else logger.Debug($"Not recording. Can sloe now.");
        }
    }

    public class UpdateEventArgs : EventArgs
    {
        public int minutes { get; set; }
    }
}
