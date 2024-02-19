using Common.DataModels;
using Common.Helpers;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AgoyRecorder.Tests
{
    [TestFixture]
    public class MiscTests
    {
        [Test]
        public void CreateConfig()
        {
            AppConfig config = new AppConfig() { FFMpegPath = @"c:\Apps\ffmpeg.exe" };
            SerializerHelper.SerializeXmlToFile(config, @"c:\Temp\AppConfig.xml");
        }
    }
}
