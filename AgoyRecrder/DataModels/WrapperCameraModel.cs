using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Touchless.Vision.Camera;

namespace AgoyRecorder.DataModels
{
    public class WrapperCameraModel
    {
        public Camera  camera { get; set; }
        public List<CaptureSize> captureSizes { get; set; }

        public string sourceName { get; set; }
        public int maxWidth { get; set; }
        public int maxHeight { get; set; }
        public double fps { get; set; }

        public double ratio { get; set; }
    }
}
