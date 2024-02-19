using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Common.DataModels
{
    public class VideoSourceModel
    {
        //public Camera  camera { get; set; }
        //public List<CaptureSize> captureSizes { get; set; }

        public string sourceName { get; set; }
        public int maxWidth { get; set; }
        public int maxHeight { get; set; }
        public double fps { get; set; }

        public double ratio { get; set; }
        public string sourceNameWithResolution
        {
            get
            {
                string fullName = $"{this.sourceName} | {this.maxWidth}x{this.maxHeight}";
                return fullName;
            }
        }
    }
}
