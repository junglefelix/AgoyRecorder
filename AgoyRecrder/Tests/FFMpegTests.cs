using Common.Helpers;
using NLog;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoyRecrder.Tests
{
    [TestFixture]
    public class FFMpegTests
    {
        FFMpegHelper ffHelper;
        private static ILogger logger = LogManager.GetCurrentClassLogger();
        string ffMpegPath = @"c:\Apps\ffmpeg.exe";
        [OneTimeSetUp]
        public void SpmTestsSetup()
        {
            ffHelper = new FFMpegHelper(ffMpegPath);
        }
        [OneTimeTearDown]
        public void SpmTestsTearDown()
        {
        }

        [Test]
        public void GetSourcesTest_RunProcGetCmdOut()
        {
            string arguments = " -list_devices true -f dshow -i dummy";
            string workingDir = Path.GetDirectoryName(ffMpegPath);
            string result = ProcessHelper.RunProcessGetCmdOutput("cmd.exe", $" /C {ffMpegPath} {arguments}", workingDir);

        }

        [Test]
        public void GetSourcesTest_RunProc2()
        {
            string arguments = " -list_devices true -f dshow -i dummy";
            string workingDir = Path.GetDirectoryName(ffMpegPath);
            List<string> lines1 = ProcessHelper.RunProcessForExitGetOut("cmd.exe", $" /c {ffMpegPath} {arguments}", workingDir);
            string allLines = string.Join(Environment.NewLine, lines1);

            //works also
            List<string> lines2 = ProcessHelper.RunProcessForExitGetOut(ffMpegPath, arguments, workingDir);

        }

    }
}
