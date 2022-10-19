using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SPI.BackupFiles
{
    public partial class FormProgressBar : Form
    {

        private string _sourcePathTextBox { get; set; }
        private string _targetPathTextBox { get; set; }
        private DateTime _dateTimeInitial { get; set; }
        private DateTime _dateTimeEnd { get; set; }
        private List<string>? filesByDate { get; set; } 


        public FormProgressBar(string sourcePathTextBox, string targetPathTextBox, DateTime dateTimeInitial, DateTime dateTimeEnd)
        {
            InitializeComponent();

            _sourcePathTextBox = sourcePathTextBox;
            _targetPathTextBox = targetPathTextBox;
            _dateTimeInitial = dateTimeInitial;
            _dateTimeEnd = dateTimeEnd;
        }

        private void FormProgressBar_Load(object sender, EventArgs e)
        {
            (int countedFiles, filesByDate) = CountFiles(_sourcePathTextBox, _dateTimeInitial, _dateTimeEnd);

            //ProgressBar1 Config
            progressBar1.Minimum = 0;
            progressBar1.Maximum = countedFiles;
            progressBar1.Step = 1;

            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            for(var i = 0; i<filesByDate?.Count(); i++)
            { 
                var fileName = Path.GetFileName(filesByDate[i]);
                File.Copy(filesByDate[i], _targetPathTextBox + "\\" + fileName);

                backgroundWorker1.ReportProgress(i);
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }



        private (int, List<string>) CountFiles(string sourceDirectory, DateTime dateTimeInitial, DateTime dateTimeEnd)
        {
            IEnumerable<string> sourceDirectoryFiles = Directory.GetFiles(sourceDirectory).AsEnumerable();

            int countedFiles = FilterByDate(sourceDirectoryFiles, dateTimeInitial, dateTimeEnd).Count();
            List<string> filterByDate = FilterByDate(sourceDirectoryFiles, dateTimeInitial, dateTimeEnd);

            return (countedFiles, filterByDate);
        }

        private List<string> FilterByDate(IEnumerable<string> sourceDirectoryFiles, DateTime initialDateTime, DateTime endDateTime)
        {
            List<string> filesByDateRange = new List<string>();

            //TODO exception para caso não tenho nenhum item

            foreach(var file in sourceDirectoryFiles)
            {
                var currentFile = File.GetCreationTime(file);

                if(currentFile.Date >= initialDateTime.Date && currentFile.Date <= endDateTime.Date)
                    filesByDateRange.Add(file);
            }

            return filesByDateRange;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.Close();
        }
    }
}
