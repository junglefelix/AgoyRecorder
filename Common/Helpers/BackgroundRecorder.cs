
using Common.DataModels;
using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class BackgroundRecorder
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        FFMpegHelper ffHelper;
        AppConfig appConfig;
        string videoSrcName;
        string audioSrcName;
        int width;
        int height;
        bool shouldRecord= false;

        public BackgroundRecorder(FFMpegHelper _ffmpegHelper, AppConfig _config)
        {
            ffHelper = _ffmpegHelper;
            appConfig = _config;
        }

        public void startRecordingWithAudio(string _videoSrcName, string _audioScrName, int _width, int _height)
        {
            videoSrcName = _videoSrcName;
            audioSrcName = _audioScrName;
            width = _width;
            height = _height;
            shouldRecord = true;
            Task.Factory.StartNew(() => recordLoop());
            logger.Debug($"Started recording loop");
         
            

        }

        public void startRecordingNoAudio(string _videoSrcName, int _width, int _height)
        {
            videoSrcName = _videoSrcName;
            audioSrcName = "" ;
            width = _width;
            height = _height;
            shouldRecord = true;
            Task.Factory.StartNew(() => recordLoop());
            logger.Debug($"Started recording loop");



        }

        public void recordLoop()
        {
            while(true)
            {
                if (!shouldRecord) break;



                DateTime now = DateTime.Now;
                string recordFilePath = Path.Combine(appConfig.RecordingBaseDir, $"Rec_{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}.mp4");
                logger.Debug($"Will start recording to file: {recordFilePath}");
               if(string.IsNullOrEmpty(audioSrcName)) ffHelper.StartRecordingNoAudio(recordFilePath,  videoSrcName, width, height, null);
               else ffHelper.StartRecordingWith1AudioSource(recordFilePath, audioSrcName, videoSrcName, width, height, null);
                logger.Debug($"Started recording to file: {recordFilePath}");
                Thread.Sleep(appConfig.FileLengthInSec * 1000);
                logger.Debug($"Waited {appConfig.FileLengthInSec} sec. Will stop recording.");
                ffHelper.StopRecording();
            }
            logger.Debug($"Exiting record Loop!");
        }

        public void stopRecordingChunks()
        {
            logger.Debug($"Setting 'shoudRecord' flag to false");
            shouldRecord = false;
        }



    }
}
