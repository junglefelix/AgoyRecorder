using Common.DataModels;
using Common.Helpers;
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
    public partial class VideoSourceForm : Form
    {
        FFMpegHelper ffMpegHelper;
        AppConfig config;
        public VideoSourceForm(FFMpegHelper _ffMpegHelper, AppConfig _config)
        {
            InitializeComponent();
            ffMpegHelper = _ffMpegHelper;
            config = _config;
            listBoxAvailableVideoSources.Items.Clear();
            listBoxAvailableVideoSources.Items.AddRange(config.AvailableVideoSources.Select(s => s.sourceNameWithResolution).ToArray());
            if (config.SelectedVideoSource != null) tbSelectedVideoSource.Text = config.SelectedVideoSource.sourceNameWithResolution;
        }

        private void listBoxAvailableVideoSources_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void listBoxAvailableVideoSources_DoubleClick(object sender, EventArgs e)
        {

            if (listBoxAvailableVideoSources.SelectedItem != null)
            {
                tbSelectedVideoSource.Text = listBoxAvailableVideoSources.SelectedItem.ToString();
            }

        }

        private void btnAudioSourceOk_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(tbSelectedVideoSource.Text))
            {
                var selectedSrc = config.AvailableVideoSources.FirstOrDefault(s => s.sourceNameWithResolution == tbSelectedVideoSource.Text);
                if (selectedSrc != null)
                {
                    config.SelectedVideoSource = selectedSrc;
                    config.Save();
                }
            }
            this.Close();
        }

        private void btnAudioSourceDiscard_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
