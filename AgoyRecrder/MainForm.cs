using AgoyRecorder.DataModels;
using Common.Helpers;
using Common.DataModels;
using Common.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Touchless.Vision.Camera;
using Touchless.Vision.Contracts;

namespace AgoyRecrder
{
    public partial class MainForm : Form
    {
        private CameraFrameSource frameSource;
        private static Bitmap latestFrame;
        List<WrapperCameraModel> cameras = new List<WrapperCameraModel>();
        WrapperCameraModel curCamera = null;
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        string ffMpegPath = @"c:\Apps\ffmpeg.exe";
        FFMpegHelper ffMpegHelper = null;
        AppConfig config;
        BackgroundRecorder recorder;
        public MainForm()
        {
            InitializeComponent();
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
             recorder = new BackgroundRecorder(ffMpegHelper, config);
            comboCamera.Items.Clear();
            cameras.Clear();
            foreach(Camera camera in CameraService.AvailableCameras)
            {
                WrapperCameraModel cModel = new WrapperCameraModel() { camera = camera,
                    maxWidth = camera.CaptureWidth, maxHeight = camera.CaptureHeight, fps = camera.Fps, captureSizes = camera.CaptureSizes.ToList(), sourceName = camera.Name };
                cModel.maxWidth = cModel.captureSizes.OrderByDescending(x => x.Width).First().Width;
                cModel.maxHeight = cModel.captureSizes.OrderByDescending(x => x.Height).First().Height;
                cModel.fps = 30; // not sure how to get max fps. 
                cameras.Add(cModel);
                
                string camTitle = $"{cModel.camera.Name} | {cModel.maxWidth}x{cModel.maxHeight}";
                comboCamera.Items.Add(camTitle);
            }
                //comboCamera.Items.Add(camera);
            if(comboCamera.Items.Count > 0) comboCamera.SelectedIndex = 0;

            (List<string> videoSources, List<string> audioSources) = ffMpegHelper.GetAvailableSources();
            comboAudio.Items.Clear();
            foreach(string audioSource in audioSources) comboAudio.Items.Add(audioSource);
            if(comboAudio.Items.Count > 0) comboAudio.SelectedIndex = 0;
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (frameSource != null && frameSource.Camera == cameras[comboCamera.SelectedIndex].camera) return;
            stopCapturing();
            startCapturing();
            
        }

        private void setFrameSource(CameraFrameSource cameraFrameSource)
        {
            if (frameSource == cameraFrameSource) return;
            frameSource = cameraFrameSource;
        }

        public void startCapturing()
        {
            curCamera = cameras[comboCamera.SelectedIndex];
            curCamera.ratio = (double)curCamera.maxWidth / (double)curCamera.maxHeight;
            setFrameSource(new CameraFrameSource(curCamera.camera));
            frameSource.Camera.CaptureWidth = curCamera.maxWidth;
            frameSource.Camera.CaptureHeight = curCamera.maxHeight;
            frameSource.Camera.Fps = Convert.ToInt32(curCamera.fps);
            frameSource.NewFrame += OnNewFrame;
            PictureBox1.Paint += new PaintEventHandler(drawLastImage);
            frameSource.StartFrameCapture();
        }

        

        private void drawLastImage(object sender, PaintEventArgs e)
        {
            if(latestFrame != null)
            {
                int curWidth = PictureBox1.Width;
                int curHeight = PictureBox1.Height;
                double picRatio  = (double)curWidth / (double)curHeight;

                int resizedX, resizedY;
                
                if(picRatio < curCamera.ratio)
                {
                    // limit horizontally
                    resizedX = curWidth;
                    resizedY = Convert.ToInt32(curWidth / curCamera.ratio);

                }
                else
                {
                    // limit vertially
                    resizedX = Convert.ToInt32(curHeight * curCamera.ratio);
                    resizedY = curHeight;
                }
                Bitmap resized = new Bitmap(latestFrame, new Size(resizedX, resizedY));
                e.Graphics.DrawImage(resized, 0,0, resizedX, resizedY);
            }
        }

        private void OnNewFrame(IFrameSource frameSrc, Frame frame, double fps)
        {
            latestFrame = frame.Image;
            PictureBox1.Invalidate();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            stopCapturing();
        }

        private void stopCapturing()
        {
            // Trash the old camera
            if (frameSource != null)
            {
                frameSource.NewFrame -= OnNewFrame;
                frameSource.Camera.Dispose();
                setFrameSource(null);
                PictureBox1.Paint -= new PaintEventHandler(drawLastImage);
            }
        }

        private void btnTest_Click(object sender, EventArgs e)
        {
            int curWidth = PictureBox1.Width;
            int curHeight = PictureBox1.Height;
        }

        private void btnStartRec_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;

            btnStart.Enabled = false;
            btnStopRec.Enabled = true;
            curCamera = cameras[comboCamera.SelectedIndex];
            string recordFilePath = Path.Combine(config.RecordingBaseDir, $"Rec_{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}.mp4");
            logger.Debug($"Will start recording to file: {recordFilePath}");
            ffMpegHelper.StartRecordingWith1AudioSource(recordFilePath, comboAudio.SelectedItem.ToString(), curCamera.sourceName,curCamera.maxWidth, curCamera.maxHeight,  null);
            logger.Debug($"Started recording to file: {recordFilePath}");
        }

        private void btnStopRec_Click(object sender, EventArgs e)
        {
            btnStart.Enabled = true;
            btnStopRec.Enabled = false;
            ffMpegHelper?.StopRecording();
        }

        private void btnStartRecFiles_Click(object sender, EventArgs e)
        {
            curCamera = cameras[comboCamera.SelectedIndex];
            recorder.startRecordingWithAudio(curCamera.sourceName, comboAudio.SelectedItem.ToString(), curCamera.maxWidth, curCamera.maxHeight);
            logger.Debug($"Will start recording files...");
        }

        private void btnStopRecFiles_Click(object sender, EventArgs e)
        {
            recorder.stopRecordingChunks();
            logger.Debug($"Stopped recording files.");
        }
    }
}
