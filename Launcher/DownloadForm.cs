using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Diagnostics;
using System.IO;

namespace WindowsFormsApplication3
{
    public partial class DownloadForm : Form
    {

        public DownloadForm()
        {
            InitializeComponent();
        }

        private void DownloadForm_Load(object sender, EventArgs e)
        {
            StreamReader openFile = new StreamReader("info.txt");
            this.path = openFile.ReadLine();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
            webClient.DownloadProgressChanged += new DownloadProgressChangedEventHandler(ProgressChange);
            webClient.DownloadFileAsync(new Uri("http://www.mediafire.com/?6icr3n21ie0dh1w"), path + "/Data/patch-c.mpq");
            button1.Enabled = false;
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Cancelled == true)
            {
                File.Delete(path + "/Data/patch-c.mpq");
                MessageBox.Show("Download Cancelled!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                MessageBox.Show("Complete!", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            this.Dispose();
        }

        private void ProgressChange(object sender, DownloadProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private string path;
    }
}