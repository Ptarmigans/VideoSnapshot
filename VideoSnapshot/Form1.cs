using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VideoScreenshot
{
    public partial class Form1 : Form
    {
        CancellationTokenSource cts;
        public Form1()
        {
            InitializeComponent();
            this.listBox1.DragDrop += new System.Windows.Forms.DragEventHandler(this.listBox1_DragDrop);
            this.listBox1.DragEnter += new System.Windows.Forms.DragEventHandler(this.listBox1_DragEnter);
        }

        private void listBox1_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
                e.Effect = DragDropEffects.All;
            else
                e.Effect = DragDropEffects.None;
        }

        private void listBox1_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop, false);
            string ext;
            int i;
            for (i = 0; i < files.Length; i++)
            {
                ext = Path.GetExtension(files[i]);
                //Filter out directories
                if (ext != "")
                    listBox1.Items.Add(files[i]);
            }
        }

        private void addFiles_Click(object sender, EventArgs e)
        {
            DialogResult result = openFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                foreach (String file in openFileDialog1.FileNames)
                {
                    listBox1.Items.Add(file);
                }
            }
            Console.WriteLine(result);
        }

        private void removeFiles_Click(object sender, EventArgs e)
        {
            ListBox.SelectedObjectCollection selection = new ListBox.SelectedObjectCollection(listBox1);
            selection = listBox1.SelectedItems;

            while (listBox1.SelectedIndex >= 0)
            {
                int i;
                for (i = selection.Count - 1; i >= 0; i--)
                {
                    listBox1.Items.Remove(selection[i]);
                }
            }
        }

        private void stop_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Stop");
            if(cts != null)
            {
                cts.Cancel();
            }
            unlockControls();
        }

        private async void start_Click(object sender, EventArgs e)
        {
            cts = new CancellationTokenSource();
            try
            {
                await started(cts.Token);
            }
            catch (OperationCanceledException)
            {
                Console.WriteLine("Cancelled");
            }
        }

        private async Task started(CancellationToken ct)
        {
            lockDownControls();
            currentProgress.Value = 0;
            totalProgress.Value = 0;
            
            //Get all the files for processing
            ListBox.ObjectCollection files = new ListBox.ObjectCollection(listBox1);
            files = listBox1.Items;
            int filesNo = files.Count;
            int processedFrames = 0;
            int processedFiles = 0;

            //Stop if there are no files
            if (filesNo == 0)
            {
                MessageBox.Show("No videos selected!");
                return;
            }

            string arg;
            string location = "";
            double[] lengthSecs = new double[filesNo];
            //Get the time in seconds for the interval from the date time picker
            double interval = dateTimePicker1.Value.TimeOfDay.TotalSeconds;
            string stdOut = "";
            string timeFromSeconds;
            string timeFromSecondsFileSafe;

            //Set up conditions for running ffmpeg
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            //Don't show the cmd window
            p.StartInfo.CreateNoWindow = true;
            //Hang onto the shell output
            p.StartInfo.RedirectStandardOutput = true;

            //Get the lengths of all the videos
            for (int i = 0; i < filesNo; i++)
            {
                location = files[i].ToString();
                arg = "/C ffmpeg -i \"" + location + "\" 2>&1 | find \"Duration\"";
                p.StartInfo.Arguments = arg;
                p.Start();
                stdOut = p.StandardOutput.ReadToEnd();
                lengthSecs[i] = TimeSpan.Parse(stdOut.Substring(12, 11)).TotalSeconds;
            }
            double currVal;
            totalProgress.Maximum = filesNo;
            for (int i = 0; i < filesNo; i++)
            {
                location = files[i].ToString();
                processedFiles++;
                for (double j = 0; j < lengthSecs[i]; j = j + interval)
                {
                    timeFromSeconds = TimeSpan.FromSeconds(j).ToString();
                    timeFromSecondsFileSafe = string.Format("{0:hh\\-mm\\-ss}", TimeSpan.FromSeconds(j));
                    arg = "/C ffmpeg -y -ss " + timeFromSeconds + " -i \"" + location + "\" -frames:v 1 \"" + Path.GetDirectoryName(location) + "\\" + Path.GetFileNameWithoutExtension(location) + "-" + timeFromSecondsFileSafe + ".png\"";
                    //p.StartInfo.Arguments = arg;
                    Console.WriteLine(arg);
                    //p.Start();
                    //p.WaitForExit();
                    await waitForExitAsync(arg);
                    processedFrames++;
                    currVal = (j / lengthSecs[i]) * 100;
                    currentProgress.Value = (int)currVal;
                    if (ct.IsCancellationRequested)
                    {
                        MessageBox.Show(processedFrames + " frames processed from " + processedFiles + " file(s) out of " + filesNo + ".");
                        currentProgress.Value = 0;
                        totalProgress.Value = 0;
                        return;
                    }
                }
                totalProgress.PerformStep();
            }
            totalProgress.Value = totalProgress.Maximum;
            currentProgress.Value = currentProgress.Maximum;
            MessageBox.Show("Done! " + processedFrames + " frames processed from " + processedFiles + " file(s) out of " + filesNo + ".");
            unlockControls();
        }

        private Task waitForExitAsync(string arg)
        {
            var tcs = new TaskCompletionSource<bool>();
            Process p = new Process();
            p.StartInfo.FileName = "cmd.exe";
            p.StartInfo.UseShellExecute = false;
            //Don't show the cmd window
            p.StartInfo.CreateNoWindow = true;
            //Hang onto the shell output
            p.StartInfo.RedirectStandardOutput = true;
            p.StartInfo.Arguments = arg;
            p.EnableRaisingEvents = true;
            p.Exited += (sender, args) =>
            {
                tcs.SetResult(true);
                p.Dispose();
            };
            p.Start();
            return tcs.Task;
        }

        private void lockDownControls()
        {
            //Disable + button, - button, drag and drop, changing timer, change start to stop
            addFiles.Enabled = false;
            removeFiles.Enabled = false;
            listBox1.AllowDrop = false;
            dateTimePicker1.Enabled = false;
            //Change the start button to act as a stop button
            start.Text = "Stop!";
            start.Click -= start_Click;
            start.Click += stop_Click;
        }

        private void unlockControls()
        {
            addFiles.Enabled = true;
            removeFiles.Enabled = true;
            listBox1.AllowDrop = true;
            dateTimePicker1.Enabled = true;
            start.Text = "Start!";
            start.Click -= stop_Click;
            start.Click += start_Click;
        }
    }
}
