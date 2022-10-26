using System.Globalization;

namespace SPI.BackupFiles
{
    public partial class FormBackup : Form
    {
        public FormBackup()
        {
            InitializeComponent();
        }

        private void sourcePathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                sourcePathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void sourcePathTextBox_TextChanged(object sender, EventArgs e)
        {
        }

        private void targetPathBtn_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                targetPathTextBox.Text = folderBrowserDialog1.SelectedPath;
            }
        }

        private void targetPathTextBox_TextChanged(object sender, EventArgs e)
        {

        }

        private void startBtn_Click(object sender, EventArgs e)
        {
            FormProgressBar form2 = new FormProgressBar(sourcePathTextBox.Text, targetPathTextBox.Text, dateTimeInitial.Value, dateTimeEnd.Value);
            form2.Show();
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void dateTimeInitial_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimeEnd_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            sourcePathTextBox.Text = BackupService.GetDirectoryPaths()?.SourcePath; 
            targetPathTextBox.Text = BackupService.GetDirectoryPaths()?.TargetPath; 
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}