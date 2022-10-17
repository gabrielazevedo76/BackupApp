using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPI.BackupFiles
{
    public partial class FormProgressBar : Form
    {

        private readonly int _length;

        public FormProgressBar(int length)
        {
            InitializeComponent();
            _length = length;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
            //ProgressBar1 Config
            progressBar1.Minimum = 0;
            progressBar1.Maximum = _length - 1;
            progressBar1.Step = 1;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var i = 0;

            while(i < (_length - 1))
            {
                var value = BackupAction.GetValueHandler();
                backgroundWorker1?.ReportProgress(value);

                i = value;
            }

            if(i == (_length - 1))
            {
                e.Cancel = true;
            }

        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        /*
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if(e.Cancelled)
                BackupAction.progressBarForm.Close(); 
        }
        */
    }
}
