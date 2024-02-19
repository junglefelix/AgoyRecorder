using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public class FFMpegHelper
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();

        private string ffmpegPath;
        private Process curFfmpegProc;
        private bool recordingStarted = false;
        private bool runHidden;
        private static readonly object locker = new object();

        public FFMpegHelper(string _ffmpegPath, bool _runHidden=true)
        {
            ffmpegPath = _ffmpegPath;
            runHidden = _runHidden;
            if (!File.Exists(ffmpegPath))
            {
                logger.Error("ffmpeg.exe file is not found: " + ffmpegPath);
            }

        }

        public (List<string> videoSources, List<string> audioSources) GetAvailableSources()
        {
            string arguments = " -list_devices true -f dshow -i dummy";
            string workingDir = Path.GetDirectoryName(ffmpegPath);
            List<string> lines = ProcessHelper.RunProcessForExitGetOut(ffmpegPath, arguments, workingDir,runHidden: true);
            List<string> videoSources = lines.Where(l => l != null && l.StartsWith("[dshow") && l.Contains("(video)")).ToList();
            List<string> audioSources = lines.Where(l => l != null && l.StartsWith("[dshow") && l.Contains("(audio)")).ToList();
            return (videoSources.Select(s => s.Split('"')[1]).ToList(), audioSources.Select(s => s.Split('"')[1]).ToList());
        }
        public void StartRecording(string targetVideoPath, Action<string> callBack = null)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("ffmpeg");
                if (processes.Length > 0)
                {
                    logger.Warn("!! Looks like ffmpeg process is already running. Probably was not stopped in prev test. Will kill it.");
                    foreach (var proc in processes)
                    {
                        proc.Kill();
                    }
                    logger.Info("Finished killing previous ffmpeg processes.");

                }
                string args = " -y -rtbufsize 100M -f gdigrab -video_size 1920x1080 -framerate 10 -probesize 10M -draw_mouse 1 -i desktop -c:v libx264 -r 10 -preset ultrafast -tune zerolatency -crf 28 -pix_fmt yuv420p " + targetVideoPath;
                logger.Info(" Will start FFmpeg screen recording with args: {0}", args);
                string workDir = Path.GetDirectoryName(ffmpegPath);
                curFfmpegProc = ProcessHelper.RunProcessWithCallbackNoWait(ffmpegPath, args, callBack, workDir, runHidden: false);
                recordingStarted = true;
                logger.Info("'recordingStarted' flag is ON");
                logger.Info("Finished starting ffmpeg recording.");

            }
            catch (Exception ex)
            {

                logger.Error("Exception occurred while try to start screen recording. ex={0}{1}", Environment.NewLine, ex.ToString());
            }

        }

        
        private static void KillPrevFFMpegIfRunning()
        {
            Process[] processes = Process.GetProcessesByName("ffmpeg");
            if (processes.Length > 0)
            {
                logger.Warn("!! Looks like ffmpeg process is already running. Probably was not stopped in prev test. Will kill it.");
                foreach (var proc in processes)
                {
                    proc.Kill();
                }
                logger.Info("Finished killing previous ffmpeg processes.");

            }
        }

        public (int width, int height) getVideoSourceResolution(string videoSrc)
        {
            // ffprobe -v error -select_streams v:0 -show_entries stream=width,height -f dshow -i video="HP HD Camera"
            string arguments = $" -v error -select_streams v:0 -show_entries stream=width,height -f dshow -i video=\"{videoSrc}\"";
            string workingDir = Path.GetDirectoryName(ffmpegPath);
            List<string> lines = ProcessHelper.RunProcessForExitGetOut(Path.Combine(workingDir, "ffprobe.exe"), arguments, workingDir).Where(l => l!= null).ToList();
            int width = Convert.ToInt32(lines.Single(l => l.StartsWith("width")).Split('=')[1]);
            int height = Convert.ToInt32(lines.Single(l => l.StartsWith("height")).Split('=')[1]);
            return (width, height);
        }

        public void StartRecordingWith1AudioSource(string targetVideoPath, string audioSrc, string videoSrc, int width, int height, Action<string> callBack = null)
        {
            try
            {
                KillPrevFFMpegIfRunning();
                string args = $" -y  -f dshow -i audio=\"{audioSrc}\"  -f dshow -i video=\"{videoSrc}\" -rtbufsize 100M -framerate 10 -probesize 10M" +
                    $"  -video_size {width}x{height} -c:v libx264 -r 10 -preset ultrafast -tune zerolatency -crf 25 -pix_fmt yuv420p" +
                    $" -acodec libmp3lame -b:a 160k {targetVideoPath}";
                logger.Info(" Will start FFmpeg screen recording with args: {0}", args);
                string workDir = Path.GetDirectoryName(ffmpegPath);
                curFfmpegProc = ProcessHelper.RunProcessWithCallbackNoWait(ffmpegPath, args, callBack, workDir, runHidden: runHidden);
                recordingStarted = true;
                logger.Info("'recordingStarted' flag is ON");
                logger.Info("Finished starting ffmpeg recording.");

            }
            catch (Exception ex)
            {

                logger.Error("Exception occurred while try to start screen recording. ex={0}{1}", Environment.NewLine, ex.ToString());
            }

        }

        internal void StartRecordingWith2AudioSources(string targetVideoPath, string audioScr1, string audioScr2, string videoSrc, int width, int height, Action<string> callBack = null)
        {
            try
            {
                KillPrevFFMpegIfRunning();
                string args = $" -y  -f dshow -i audio=\"{audioScr1}\" -f dshow -i audio=\"{audioScr2}\" -f dshow -i video=\"{videoSrc}\" -rtbufsize 100M" +
                    $" -framerate 10 -probesize 10M  -video_size {width}x{height} -c:v libx264 -r 10 -preset ultrafast -tune zerolatency -crf 25" +
                    $" -pix_fmt yuv420p -acodec libmp3lame -b:a 160k" +
                    $" -filter_complex \"[0:a][1:a]amerge = inputs = 2[a]\" -map 2 -map \"[a]\"  {targetVideoPath}";
                logger.Info(" Will start FFmpeg screen recording with args: {0}", args);
                string workDir = Path.GetDirectoryName(ffmpegPath);
                curFfmpegProc = ProcessHelper.RunProcessWithCallbackNoWait(ffmpegPath, args, callBack, workDir, runHidden: runHidden);
                recordingStarted = true;
                logger.Info("'recordingStarted' flag is ON");
                logger.Info("Finished starting ffmpeg recording.");

            }
            catch (Exception ex)
            {

                logger.Error("Exception occurred while try to start screen recording. ex={0}{1}", Environment.NewLine, ex.ToString());
            }

        }

        public void StartRecordingNoAudio(string targetVideoPath, string videoSrc, int width, int height, Action<string> callBack = null)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("ffmpeg");
                if (processes.Length > 0)
                {
                    logger.Warn("!! Looks like ffmpeg process is already running. Probably was not stopped in prev test. Will kill it.");
                    foreach (var proc in processes)
                    {
                        proc.Kill();
                    }
                    logger.Info("Finished killing previous ffmpeg processes.");

                }
                string args = $" -y  -f dshow -i video=\"{videoSrc}\" -rtbufsize 100M -framerate 10 -probesize 10M  -video_size {width}x{height} -c:v libx264 -r 10 -preset ultrafast -tune zerolatency -crf 25 -pix_fmt yuv420p {targetVideoPath}";
                logger.Info(" Will start FFmpeg screen recording with args: {0}", args);
                string workDir = Path.GetDirectoryName(ffmpegPath);
                curFfmpegProc = ProcessHelper.RunProcessWithCallbackNoWait(ffmpegPath, args, callBack, workDir, runHidden: false);
                recordingStarted = true;
                logger.Info("'recordingStarted' flag is ON");
                logger.Info("Finished starting ffmpeg recording.");

            }
            catch (Exception ex)
            {

                logger.Error("Exception occurred while try to start screen recording. ex={0}{1}", Environment.NewLine, ex.ToString());
            }

        }
        public void StartRecordingWithAudioPipeToFfPlay(string targetVideoPath, string audioSrc, string videoSrc, int width, int height, Action<string> callBack = null)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName("ffmpeg");
                if (processes.Length > 0)
                {
                    logger.Warn("!! Looks like ffmpeg process is already running. Probably was not stopped in prev test. Will kill it.");
                    foreach (var proc in processes)
                    {
                        proc.Kill();
                    }
                    logger.Info("Finished killing previous ffmpeg processes.");

                }
                string args = $"start \"window\" /high /wait /b ffmpeg.exe -y  -f dshow -i audio=\"{audioSrc}\"  -f dshow -i video=\"{videoSrc}\" -rtbufsize 100M -framerate 10 -probesize 10M  -video_size {width}x{height} -c:v libx264 -r 10 -preset ultrafast -tune zerolatency -crf 25 -pix_fmt yuv420p -acodec libmp3lame -b:a 128k \"{targetVideoPath}\" -f mpegts - |ffplay -";
                logger.Info(" Will start FFmpeg screen recording with args: {0}", args);
                string workDir = Path.GetDirectoryName(ffmpegPath);
                curFfmpegProc = ProcessHelper.RunProcessWithCallbackNoWait("cmd /c", args, callBack, workDir, runHidden: false);
                recordingStarted = true;
                logger.Info("'recordingStarted' flag is ON");
                logger.Info("Finished starting ffmpeg recording.");

            }
            catch (Exception ex)
            {

                logger.Error("Exception occurred while try to start screen recording. ex={0}{1}", Environment.NewLine, ex.ToString());
            }

        }

        public void StopRecording()
        {
            lock (locker)
            {

                if (recordingStarted)
                {
                    logger.Info("setting 'recordingStarted' flag to False");
                    recordingStarted = false;


                    try
                    {
                        Process[] processes = Process.GetProcessesByName("ffmpeg");
                        if (processes.Length == 0)
                        {
                            logger.Error("Looks like ffmpeg process is NOT running! Exiting...");
                            return;
                        }


                        logger.Info("Will stop ffmpeg recording by sending 'q' to ffmpeg proces...");
                        ProcessHelper.SendMsgToProcess(curFfmpegProc, "q", waitForProcToExit: true);
                        logger.Info("Process exited.");

                    }
                    catch (Exception ex)
                    {

                        logger.Error("Exception occurred while try to start screen recording. ex={0}{1}", Environment.NewLine, ex.ToString());
                    }
                }
                else
                {
                    logger.Info("'recordingStarted' flag is already False . exiting..");
                }
            }
        }

    }
}
