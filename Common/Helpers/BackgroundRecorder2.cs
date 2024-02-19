
using Common.DataModels;
using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;

namespace Common.Helpers
{
    public class BackgroundRecorder2
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        FFMpegHelper ffHelper;
        AppConfig appConfig;

        System.Timers.Timer timer;
        Stopwatch swElapsedAfterDelayedStopReq;
        Stopwatch swRecordingTime;
        int secondsToStopAfter = -1;
        bool isRecording = false;
        Action stopRecCallback;
        Action<string> recTimeChangedCallback;

        public BackgroundRecorder2(FFMpegHelper _ffmpegHelper, AppConfig _config, Action _stopRecCallback,Action<string> _recTimeChangedCallback)
        {
            ffHelper = _ffmpegHelper;
            appConfig = _config;
            stopRecCallback = _stopRecCallback;
            recTimeChangedCallback = _recTimeChangedCallback;
            swElapsedAfterDelayedStopReq = new Stopwatch();
            swRecordingTime = new Stopwatch();
            timer = new System.Timers.Timer();
            timer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
            timer.Interval =  1000;
            timer.AutoReset = false;
            timer.Start();
        }

        public void startRecordingWith1AudioSource(string recFilePath, string audioScrName , VideoSourceModel videoSrc)
        {
           
            DateTime now = DateTime.Now;
            //string recordFilePath = Path.Combine(appConfig.RecordingBaseDir, $"Rec_{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}-{now.Second}.mp4");
            logger.Debug($"Starting recording video with 1 audio to file: {recFilePath}");
            ffHelper.StartRecordingWith1AudioSource(recFilePath, audioScrName, videoSrc.sourceName, videoSrc.maxWidth, videoSrc.maxHeight, null);
            isRecording = true;
            swRecordingTime.Restart();
            logger.Debug($"Started recording.");
        }

        public void startRecordingWith2AudioSources(string recFilePath,string audioScrName1, string audioScrName2, VideoSourceModel videoSrc)
        {

            DateTime now = DateTime.Now;
            //string recordFilePath = Path.Combine(appConfig.RecordingBaseDir, $"Rec_{now.Year}-{now.Month}-{now.Day}_{now.Hour}-{now.Minute}-{now.Second}.mp4");
            logger.Debug($"Starting recording video with 2 audios to file: {recFilePath}");
            ffHelper.StartRecordingWith2AudioSources(recFilePath, audioScrName1, audioScrName2, videoSrc.sourceName, videoSrc.maxWidth, videoSrc.maxHeight, null);
            isRecording = true;
            swRecordingTime.Restart();
            logger.Debug($"Started recording.");
        }



        public void stopRecording()
        {
            logger.Debug($"Received on-demand request to stop recording");
            if(isRecording)
            {
                isRecording = false;
                ffHelper.StopRecording();
                logger.Debug($"Recording stopped.");
            }
            else
            {
                logger.Debug($"Currently NOT recording, so nothing to stop");
            }
        }

        public void scheduleToStopAfter(int minutes)
        {
           
            logger.Info($"Timer set to trigger {minutes} minutes from now.");
            secondsToStopAfter = minutes * 60;
            swElapsedAfterDelayedStopReq.Restart();
        }

        private void OnTimedEvent(object source, ElapsedEventArgs e)
        {
            logger.Trace($"Started OnTimedEvent");
            timer.Stop();
            try
            {
                RunOnTimerTick();
            }
            catch (Exception ex)
            {
                logger.Error("Exception occurred in RunOnTimerTick(). Ex= " + Environment.NewLine + ex.ToString());
            }
            timer.Start();
            logger.Trace($"Finished On TimedEvent");
        }

        private void RunOnTimerTick()
        {
            if(isRecording)
            {
                string recTimeStr = $"{swRecordingTime.Elapsed.Hours}:{swRecordingTime.Elapsed.Minutes}:{swRecordingTime.Elapsed.Seconds} ";
                recTimeChangedCallback(recTimeStr);
                logger.Trace($"Currently recording");
                if(!swElapsedAfterDelayedStopReq.IsRunning)
                {
                    logger.Trace($"Did NOT request to schedule recording stop");
                }
                else if( swElapsedAfterDelayedStopReq.Elapsed.TotalSeconds >= secondsToStopAfter)
                {
                    logger.Debug($"Stopwatch reached {Convert.ToInt32(swElapsedAfterDelayedStopReq.Elapsed.TotalSeconds)} sec, so will stop recording now...");
                    isRecording = false;
                    swElapsedAfterDelayedStopReq.Stop();
                    ffHelper.StopRecording();
                    logger.Debug($"Recording stopped");
                    logger.Debug($"Will invoke StopRecCallback...");
                    stopRecCallback();
                }
                else
                {
                    logger.Trace($"Stopwatch is {Convert.ToInt32(swElapsedAfterDelayedStopReq.Elapsed.TotalSeconds)} sec, which is less than {secondsToStopAfter}, so will continue recording.");

                }

            }
            else
            {
                logger.Trace($"Not recording.");
            }
        }


        }
}
