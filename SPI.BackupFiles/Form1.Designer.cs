namespace SPI.BackupFiles
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.sourcePathBtn = new System.Windows.Forms.Button();
            this.sourcePathTextBox = new System.Windows.Forms.TextBox();
            this.targetPathTextBox = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.button3 = new System.Windows.Forms.Button();
            this.dateTimeInitial = new System.Windows.Forms.DateTimePicker();
            this.dateTimeEnd = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // sourcePathBtn
            // 
            this.sourcePathBtn.Location = new System.Drawing.Point(64, 142);
            this.sourcePathBtn.Name = "sourcePathBtn";
            this.sourcePathBtn.Size = new System.Drawing.Size(84, 23);
            this.sourcePathBtn.TabIndex = 0;
            this.sourcePathBtn.Text = "Origem";
            this.sourcePathBtn.UseVisualStyleBackColor = true;
            this.sourcePathBtn.Click += new System.EventHandler(this.sourcePathBtn_Click);
            // 
            // sourcePathTextBox
            // 
            this.sourcePathTextBox.Location = new System.Drawing.Point(154, 142);
            this.sourcePathTextBox.Name = "sourcePathTextBox";
            this.sourcePathTextBox.Size = new System.Drawing.Size(258, 23);
            this.sourcePathTextBox.TabIndex = 1;
            this.sourcePathTextBox.TextChanged += new System.EventHandler(this.sourcePathTextBox_TextChanged);
            // 
            // targetPathTextBox
            // 
            this.targetPathTextBox.Location = new System.Drawing.Point(154, 185);
            this.targetPathTextBox.Name = "targetPathTextBox";
            this.targetPathTextBox.Size = new System.Drawing.Size(258, 23);
            this.targetPathTextBox.TabIndex = 3;
            this.targetPathTextBox.TextChanged += new System.EventHandler(this.targetPathTextBox_TextChanged);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(64, 185);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(84, 23);
            this.button2.TabIndex = 2;
            this.button2.Text = "Destino";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.targetPathBtn_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(180, 365);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(111, 47);
            this.button3.TabIndex = 4;
            this.button3.Text = "Iniciar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.startBtn_Click);
            // 
            // dateTimeInitial
            // 
            this.dateTimeInitial.Location = new System.Drawing.Point(154, 231);
            this.dateTimeInitial.Name = "dateTimeInitial";
            this.dateTimeInitial.Size = new System.Drawing.Size(258, 23);
            this.dateTimeInitial.TabIndex = 5;
            this.dateTimeInitial.ValueChanged += new System.EventHandler(this.dateTimeEnd_ValueChanged);
            // 
            // dateTimeEnd
            // 
            this.dateTimeEnd.Location = new System.Drawing.Point(154, 274);
            this.dateTimeEnd.Name = "dateTimeEnd";
            this.dateTimeEnd.Size = new System.Drawing.Size(258, 23);
            this.dateTimeEnd.TabIndex = 6;
            this.dateTimeEnd.ValueChanged += new System.EventHandler(this.dateTimeInitial_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(75, 231);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 15);
            this.label1.TabIndex = 7;
            this.label1.Text = "Data Inicio";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(75, 274);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 15);
            this.label2.TabIndex = 8;
            this.label2.Text = "Data Fim";
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(486, 440);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimeEnd);
            this.Controls.Add(this.dateTimeInitial);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.targetPathTextBox);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.sourcePathTextBox);
            this.Controls.Add(this.sourcePathBtn);
            this.Name = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Button sourcePathBtn;
        private TextBox sourcePathTextBox;
        private TextBox targetPathTextBox;
        private Button button2;
        private FolderBrowserDialog folderBrowserDialog1;
        private Button button3;
        private DateTimePicker dateTimeInitial;
        private DateTimePicker dateTimeEnd;
        private Label label1;
        private Label label2;
    }
}