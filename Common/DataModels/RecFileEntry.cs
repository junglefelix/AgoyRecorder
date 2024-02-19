using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.DataModels
{
    public class RecFileEntry
    {
        public string newName { get; set; }
        public string curName { get; set; }
        public bool overrideDefaultName { get; set; }
    }
}
