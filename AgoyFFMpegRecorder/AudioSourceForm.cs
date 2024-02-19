using Common.DataModels;
using Common.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgoyFFMpegRecorder
{
    public partial class AudioSourceForm : Form
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        FFMpegHelper ffMpegHelper;
        AppConfig config;
        public AudioSourceForm(FFMpegHelper _ffMpegHelper, AppConfig _config)
        {
            InitializeComponent();
            ffMpegHelper = _ffMpegHelper;
            config = _config;
            listBoxAvailableAudioSources.Items.Clear();
            listBoxAvailableAudioSources.Items.AddRange(config.Audio.AvailableAudioSources.ToArray());

            listBoxPreferredAudioSources.Items.Clear();
            listBoxPreferredAudioSources.Items.AddRange(config.Audio.PreferredAudioSources.ToArray());

            
            logger.Debug($"Computer audio available ?: {config.Audio.IsComputerAudioSrcAvailable()}");
            if( config.Audio.IsComputerAudioSrcAvailable())
            {
                lblComputerAudioStatus.Text = "Available";
                lblComputerAudioStatus.ForeColor = Color.Green;
                lblComputerAudioStatus.Font = new Font(lblComputerAudioStatus.Font, FontStyle.Bold);
            }
            else
            {
                lblComputerAudioStatus.Text = "NOT Available";
                lblComputerAudioStatus.ForeColor = Color.Red;
                lblComputerAudioStatus.Font = new Font(lblComputerAudioStatus.Font, FontStyle.Bold);
            }

            checkBoxMuxAudio.Checked = config.Audio.CombineAudio;


        }

        

       

        private void btnAudioSrsAddManual_Click(object sender, EventArgs e)
        {
                if(!string.IsNullOrEmpty(tbPreferredManualSource.Text) && !listBoxPreferredAudioSources.Items.Contains(tbPreferredManualSource.Text))
                listBoxPreferredAudioSources.Items.Add(tbPreferredManualSource.Text);

        }

        private void listBoxAvailableAudioSources_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxAvailableAudioSources_DoubleClick(object sender, EventArgs e)
        {
            if(listBoxAvailableAudioSources.SelectedItem != null && !listBoxPreferredAudioSources.Items.Contains(listBoxAvailableAudioSources.SelectedItem.ToString()))
            {
                listBoxPreferredAudioSources.Items.Add(listBoxAvailableAudioSources.SelectedItem.ToString());
            }
        }

        private void btnClear_MouseClick(object sender, MouseEventArgs e)
        {
            listBoxPreferredAudioSources.Items.Clear();
        }

        private void btnAudioSourceOk_Click(object sender, EventArgs e)
        {
            config.Audio.PreferredAudioSources.Clear();
            foreach (var item in listBoxPreferredAudioSources.Items)
            {
                config.Audio.PreferredAudioSources.Add(item.ToString());
            }
            config.Audio.SetActiveAudioSrc();
            config.Save();
            this.Close();
        }

        private void btnAudioSourceDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tbPreferredManualSource_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void listBoxPreferredAudioSources_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void checkBoxMuxAudio_CheckedChanged(object sender, EventArgs e)
        {
            config.Audio.CombineAudio = checkBoxMuxAudio.Checked;
            config.Save();
            if (checkBoxMuxAudio.Checked)
            {
                listBoxAvailableAudioSources.Items.Clear();
                listBoxAvailableAudioSources.Items.AddRange(config.Audio.AvailableAudioSources.Except(new string[] {config.Audio.ComputerAudioSourceName }).ToArray());

                listBoxPreferredAudioSources.Items.Clear();
                listBoxPreferredAudioSources.Items.AddRange(config.Audio.PreferredAudioSources.Except(new string[] { config.Audio.ComputerAudioSourceName }).ToArray());
            }
            else
            {
                listBoxAvailableAudioSources.Items.Clear();
                listBoxAvailableAudioSources.Items.AddRange(config.Audio.AvailableAudioSources.ToArray());

                listBoxPreferredAudioSources.Items.Clear();
                listBoxPreferredAudioSources.Items.AddRange(config.Audio.PreferredAudioSources.ToArray());
            }
        }
    }
}
