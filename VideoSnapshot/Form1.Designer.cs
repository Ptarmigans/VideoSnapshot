namespace VideoScreenshot
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.start = new System.Windows.Forms.Button();
            this.addFiles = new System.Windows.Forms.Button();
            this.removeFiles = new System.Windows.Forms.Button();
            this.currentProgress = new System.Windows.Forms.ProgressBar();
            this.totalProgress = new System.Windows.Forms.ProgressBar();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.SuspendLayout();
            // 
            // listBox1
            // 
            this.listBox1.AllowDrop = true;
            this.listBox1.FormattingEnabled = true;
            this.listBox1.HorizontalScrollbar = true;
            this.listBox1.Location = new System.Drawing.Point(12, 12);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(279, 95);
            this.listBox1.Sorted = true;
            this.listBox1.TabIndex = 0;
            // 
            // start
            // 
            this.start.Location = new System.Drawing.Point(172, 163);
            this.start.Name = "start";
            this.start.Size = new System.Drawing.Size(118, 29);
            this.start.TabIndex = 2;
            this.start.Text = "Start!";
            this.start.UseVisualStyleBackColor = true;
            this.start.Click += new System.EventHandler(this.start_Click);
            // 
            // addFiles
            // 
            this.addFiles.Location = new System.Drawing.Point(12, 113);
            this.addFiles.Name = "addFiles";
            this.addFiles.Size = new System.Drawing.Size(32, 21);
            this.addFiles.TabIndex = 3;
            this.addFiles.Text = "+";
            this.addFiles.UseVisualStyleBackColor = true;
            this.addFiles.Click += new System.EventHandler(this.addFiles_Click);
            // 
            // removeFiles
            // 
            this.removeFiles.Location = new System.Drawing.Point(50, 113);
            this.removeFiles.Name = "removeFiles";
            this.removeFiles.Size = new System.Drawing.Size(32, 21);
            this.removeFiles.TabIndex = 4;
            this.removeFiles.Text = "-";
            this.removeFiles.UseVisualStyleBackColor = true;
            this.removeFiles.Click += new System.EventHandler(this.removeFiles_Click);
            // 
            // currentProgress
            // 
            this.currentProgress.Location = new System.Drawing.Point(12, 212);
            this.currentProgress.Name = "currentProgress";
            this.currentProgress.Size = new System.Drawing.Size(278, 19);
            this.currentProgress.TabIndex = 5;
            // 
            // totalProgress
            // 
            this.totalProgress.Location = new System.Drawing.Point(12, 256);
            this.totalProgress.Name = "totalProgress";
            this.totalProgress.Size = new System.Drawing.Size(278, 19);
            this.totalProgress.Step = 1;
            this.totalProgress.TabIndex = 6;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "HH:mm:ss";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(15, 165);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.ShowUpDown = true;
            this.dateTimePicker1.Size = new System.Drawing.Size(103, 20);
            this.dateTimePicker1.TabIndex = 7;
            this.dateTimePicker1.Value = new System.DateTime(2018, 4, 29, 0, 5, 0, 0);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(9, 149);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(118, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Time between captures";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(9, 196);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Current Progress";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(9, 240);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 13);
            this.label3.TabIndex = 10;
            this.label3.Text = "Total Progress";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Multiselect = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 287);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker1);
            this.Controls.Add(this.totalProgress);
            this.Controls.Add(this.currentProgress);
            this.Controls.Add(this.removeFiles);
            this.Controls.Add(this.addFiles);
            this.Controls.Add(this.start);
            this.Controls.Add(this.listBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Video Frame Capture";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button start;
        private System.Windows.Forms.Button addFiles;
        private System.Windows.Forms.Button removeFiles;
        private System.Windows.Forms.ProgressBar currentProgress;
        private System.Windows.Forms.ProgressBar totalProgress;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
    }
}

