using Common.Helpers;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Common.DataModels
{
    public class AppConfig
    {
        public string FFMpegPath { get; set; }
        public string RecordingBaseDir { get; set; }
        public int FileLengthInSec { get; set; }

        public AudioConfig Audio { get; set; } = new AudioConfig();
        public List<VideoSourceModel> AvailableVideoSources { get; set; } = new List<VideoSourceModel>();
        public VideoSourceModel SelectedVideoSource { get; set; }
        public void Save()
        {
            string curDir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
            string appConfigFile = Path.Combine(curDir, "AppConfig.xml");
            SerializerHelper.SerializeXmlToFile(this, appConfigFile);
        }
    }

    public class AudioConfig
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        public string ComputerAudioSourceName { get; set; } = "virtual-audio-capturer";
        public bool CombineAudio { get; set; }
        public List<string> AvailableAudioSources { get; set; } = new List<string>();
        public List<string> PreferredAudioSources { get; set; } = new List<string>();

        public bool IsComputerAudioSrcAvailable()
        {
            bool isAvailable = this.AvailableAudioSources.Contains(this.ComputerAudioSourceName);
            return isAvailable;
        }

        [XmlIgnoreAttribute]
        public string CurrentAudioMicSrc;

        [XmlIgnoreAttribute]
        public bool IsCombiningAudio = false;

        public void SetActiveAudioSrc()
        {
            if (this.IsComputerAudioSrcAvailable() && this.CombineAudio)
            {
                this.IsCombiningAudio = true;
                if (!this.PreferredAudioSources.Any())
                {

                    this.CurrentAudioMicSrc = this.AvailableAudioSources.First(s => s != this.ComputerAudioSourceName);
                    logger.Debug($"Preferred audio sources are not defined! Will use 1st available source: '{ this.CurrentAudioMicSrc}'");

                }
                else
                {
                    string firstMatchingAudioSrc = this.PreferredAudioSources.FirstOrDefault(s => this.AvailableAudioSources.Contains(s) && s != this.ComputerAudioSourceName);
                    if (firstMatchingAudioSrc != null)
                    {
                        logger.Debug($"Found matching audio source: '{firstMatchingAudioSrc}'");
                        this.CurrentAudioMicSrc = firstMatchingAudioSrc;

                    }
                    else
                    {
                        this.CurrentAudioMicSrc = this.AvailableAudioSources.First(s => s != this.ComputerAudioSourceName);
                        logger.Warn($"Did not find matching audio source! Will use 1st available source: '{ this.CurrentAudioMicSrc}' ");
                    }
                }
            }
            else
            {
                this.IsCombiningAudio = false;
                if (!this.PreferredAudioSources.Any())
                {

                    this.CurrentAudioMicSrc = this.AvailableAudioSources.First();
                    logger.Debug($"Preferred audio sources are not defined! Will use 1st available source: '{ this.CurrentAudioMicSrc}'");

                }
                else
                {
                    string firstMatchingAudioSrc = this.PreferredAudioSources.FirstOrDefault(s => this.AvailableAudioSources.Contains(s));
                    if (firstMatchingAudioSrc != null)
                    {
                        logger.Debug($"Found matching audio source: '{firstMatchingAudioSrc}'");
                        this.CurrentAudioMicSrc = firstMatchingAudioSrc;

                    }
                    else
                    {
                        this.CurrentAudioMicSrc = this.AvailableAudioSources.First();
                        logger.Warn($"Did not find matching audio source! Will use 1st available source: '{ this.CurrentAudioMicSrc}' ");
                    }
                }
            }
        }

    }

    
}
