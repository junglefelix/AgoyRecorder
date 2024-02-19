using Common.DataModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgoyFFMpegRecorder
{
    public partial class RenameRecFileForm : Form
    {
        RecFileEntry recFile;
        public RenameRecFileForm(RecFileEntry _recFile)
        {
            InitializeComponent();
            recFile = _recFile;

            tbFileName.Text = recFile.overrideDefaultName ?  recFile.newName :  recFile.curName;
        }

        private void btnSetName_Click(object sender, EventArgs e)
        {
            recFile.newName = tbFileName.Text;
            recFile.overrideDefaultName = true;
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
