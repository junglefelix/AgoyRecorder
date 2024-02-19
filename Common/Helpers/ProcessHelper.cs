using NLog;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Common.Helpers
{
    public static class ProcessHelper
    {
        private static ILogger logger = LogManager.GetCurrentClassLogger();





        public static int RunProcess(string fileName, string arguments, string workingDirectory, bool minimized = false, bool hidden = false)
        {
            logger.Info("Running at: " + workingDirectory + " the following command: " + fileName + " " + arguments);
            int procId;
            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,


                WindowStyle = hidden
                            ? ProcessWindowStyle.Hidden
                            : minimized ? ProcessWindowStyle.Minimized : ProcessWindowStyle.Normal
            };

            using (Process process = Process.Start(processStartInfo))
            {
                procId = process.Id;
                process.WaitForExit();
                logger.Info("Finished running at: " + workingDirectory + " the following command: " + fileName + " " + arguments + " with exit code: " + process.ExitCode);
            }
            return procId;
        }

        public static string RunProcessGetCmdOutput(string fileName, string arguments, string workingDirectory, bool minimized = false, bool hidden = false)
        {
            string cmdOut = String.Empty;
            logger.Info("Running at: " + workingDirectory + " the following command: " + fileName + " " + arguments);

            ProcessStartInfo processStartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
                UseShellExecute = false,
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                RedirectStandardInput = true,
                WindowStyle = hidden
                            ? ProcessWindowStyle.Hidden
                            : minimized ? ProcessWindowStyle.Minimized : ProcessWindowStyle.Normal
            };

            using (Process process = Process.Start(processStartInfo))
            {
                //ProcessId = process.Id;
                cmdOut = process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                logger.Info("Finished running at: " + workingDirectory + " the following command: " + fileName + " " + arguments + " with exit code: " + process.ExitCode);
            }
            return cmdOut;
        }


        public static void RunProcessDontWait(string fileName, string arguments, string workingDirectory)
        {
            logger.Info("Running without waiting to finish at: " + workingDirectory + " the following command: " + fileName + " " + arguments);
            var processStartInfo = new ProcessStartInfo
            {
                FileName = fileName,
                Arguments = arguments,
                WorkingDirectory = workingDirectory,
            };
            Process.Start(processStartInfo);
        }

        public static void StopProcess(string processName)
        {
            foreach (Process process in Process.GetProcesses().Where(p => p.ProcessName.Contains(processName)))
            {
                process.Kill();
                process.Dispose();
            }
        }

        public static void StopProcess(Process process)
        {

            process.Kill();
            process.Dispose();

        }

        public static Process RunProcessWithCallbackNoWait(string app, string arguments, Action<string> Calback, string workDir, bool runHidden = false, bool redirectOutput = true)
        {

            //WorkingDirectory = workingDirectory,
            //    CreateNoWindow = false,
            //    RedirectStandardInput = false,
            //    RedirectStandardError = false,
            //    RedirectStandardOutput = false,
            //    UseShellExecute = true,

            var p = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = workDir,
                    UseShellExecute = !redirectOutput,
                    RedirectStandardOutput = redirectOutput,
                    RedirectStandardError = redirectOutput,
                    RedirectStandardInput = redirectOutput,
                    FileName = app,
                    CreateNoWindow = runHidden,
                    Arguments = arguments
                }
            };
            if (Calback != null)
            {
                p.OutputDataReceived += (sender, args) => Calback(args.Data);
                p.ErrorDataReceived += (sender, args) => Calback(args.Data);
            }
            var rs = p.Start();
            Thread.Sleep(2000);

            if (redirectOutput)
            {
                p.BeginOutputReadLine();
                p.BeginErrorReadLine();
            }
            //p.WaitForExit();
            //var ExitCode = p.ExitCode;
            //Calback(String.Format("Exit code: {0}", ExitCode));
            //Calback(String.Format("App file:  {0}", p.StartInfo.FileName));
            //Calback(String.Format("Parameters:  {0}", arguments));

            //return (ExitCode == 0);
            logger.Info("Started process: {0} with args: {1}", app, arguments);
            return p;
        }

        public static void SendMsgToProcess(Process p, string msg, bool waitForProcToExit)
        {
            p.StandardInput.WriteLine(msg);
            p.StandardInput.Close();
            logger.Info("Finished sending {0} message to process.", msg);
            if (waitForProcToExit)
            {
                logger.Info("Will wait till process to exit...");
                p.WaitForExit();
                logger.Info("Process exited");
            }

        }



        public static bool RunProcessWithCallbackWaifForExit(string path, string cmd, Action<string, bool> Calback, string workDir, bool runHidden = false)
        {
            logger.Info("### RunProcessCallback() launched,");
            //if (!System.IO.File.Exists(path))
            //    return false;
            Calback(string.Format("command: {0}", cmd), true);
            Calback(string.Format("App path: {0}", path), true);
            var p = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = workDir,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = path,
                    CreateNoWindow = runHidden,
                    Arguments = cmd
                }
            };

            p.OutputDataReceived += (sender, args) => Calback(args.Data, true);
            p.ErrorDataReceived += (sender, args) => Calback(args.Data, false);
            var rs = p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
            var ExitCode = p.ExitCode;
            Calback(String.Format("Exit code: {0}", ExitCode), true);
            Calback(String.Format("App file:  {0}", p.StartInfo.FileName), true);
            Calback(String.Format("Parameters:  {0}", cmd), true);

            return (ExitCode == 0);
        }

        public static List<string> RunProcessForExitGetOut(string path, string cmd, string workDir, bool runHidden = false)
        {
            logger.Info("### RunProcessCallback() launched,");
            //if (!System.IO.File.Exists(path))
            //    return false;

            var p = new Process
            {
                StartInfo =
                {
                    WorkingDirectory = workDir,
                    UseShellExecute = false,
                    RedirectStandardOutput = true,
                    RedirectStandardError = true,
                    FileName = path,
                    CreateNoWindow = runHidden,
                    Arguments = cmd
                }
            };
            List<string> lines = new List<string>();
            //string err = "";
            p.OutputDataReceived += (sender, args) => lines.Add(args.Data);
            p.ErrorDataReceived += (sender, args) => lines.Add(args.Data);
            var rs = p.Start();
            p.BeginOutputReadLine();
            p.BeginErrorReadLine();
            p.WaitForExit();
            int ExitCode = p.ExitCode;

            return lines;
        }
    }
}
