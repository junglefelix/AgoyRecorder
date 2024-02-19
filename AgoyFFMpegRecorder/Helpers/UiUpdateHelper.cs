using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AgoyFFMpegRecorder.Helpers
{
    public static class UiUpdateHelper
    {
        public static void updateUI(Control ctrl, Action updateAction)
        {
            if (ctrl.InvokeRequired)
            {
                ctrl.BeginInvoke((MethodInvoker)delegate ()
                {
                    updateAction();
                });
            }
            else
            {
                updateAction();
            }
        }


    }
}
