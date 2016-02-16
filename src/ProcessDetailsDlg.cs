using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SAS.Tasks.SASProcesses
{
    public partial class ProcessDetailsDlg : Form
    {
        public SasProcess Process { get; set; }
        public ProcessDetailsDlg()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            if (Process != null) pgProcess.SelectedObject = Process;
            base.OnLoad(e);
        }
    }
}
