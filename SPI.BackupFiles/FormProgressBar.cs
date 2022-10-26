using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Tracing;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
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
            try
            {
                for(var i = 0; i<filesByDate?.Count(); i++)
                {
                    var fileDate = File.GetCreationTime(filesByDate[i]);
                    var currentDateFolder = Directory.CreateDirectory(_targetPathTextBox + "\\" + fileDate.Day + "-" + fileDate.Month + "-" + fileDate.Year); 
                    var fileName = Path.GetFileName(filesByDate[i]);
                    File.Copy(filesByDate[i], currentDateFolder + "\\" + fileName);

                    backgroundWorker1.ReportProgress(i);
                }
            }
            catch(Exception ex)
            {
                if(ex.HResult == -2147024816)
                {
                    int wordFrom = ex.Message.IndexOf("'") + 1;
                    int wordTo = ex.Message.LastIndexOf("'") - " ' already".Length;

                    string file = ex.Message.Substring(wordFrom, wordTo);
                    MessageBox.Show($"Arquivo {file} já existe!");
                }
                if(ex.HResult == -2147024891)
                {
                    MessageBox.Show("É obrigatório inserir o caminho de destino!");
                }
                if(ex is UnauthorizedAccessException)
                {
                    MessageBox.Show("Acesso não autorizado!");
                }
                else
                {
                    MessageBox.Show("Ocorreu um Erro. Tente Novamente!");
                }
            }
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Thread.Sleep(500);
            this.Close();
        }

        private (int, List<string>) CountFiles(string sourceDirectory, DateTime dateTimeInitial, DateTime dateTimeEnd)
        {
            try
            {
                IEnumerable<string> sourceDirectoryFiles = Directory.GetFiles(sourceDirectory).AsEnumerable();

                int countedFiles = FilterByDate(sourceDirectoryFiles, dateTimeInitial, dateTimeEnd).Count();
                List<string> filterByDate = FilterByDate(sourceDirectoryFiles, dateTimeInitial, dateTimeEnd);

                return (countedFiles, filterByDate);

            }
            catch (Exception ex)
            {

                List<string> filterByDate = new List<string>();

                if(ex is ArgumentException)
                { 
                    MessageBox.Show("É obrigatório inserir o caminho de origem!");
                    return (0, filterByDate);
                }
                else
                {
                    MessageBox.Show("Ocorreu um Erro. Tente Novamente!");
                    return (0, filterByDate);
                }

            }
        }

        private List<string> FilterByDate(IEnumerable<string> sourceDirectoryFiles, DateTime initialDateTime, DateTime endDateTime)
        {
            List<string> filesByDateRange = new List<string>();

            foreach(var file in sourceDirectoryFiles)
            {
                var currentFile = File.GetCreationTime(file);

                if(currentFile.Date >= initialDateTime.Date && currentFile.Date <= endDateTime.Date)
                    filesByDateRange.Add(file);
            }

            return filesByDateRange;
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
    }
}
