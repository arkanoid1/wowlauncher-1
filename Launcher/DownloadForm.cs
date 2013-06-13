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

        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamReader openFile = new StreamReader("info.txt");
            WebClient webClient = new WebClient();
            webClient.DownloadFileCompleted += new AsyncCompletedEventHandler(DownloadComplete);
            webClient.DownloadFileAsync(new Uri("http://www.mediafire.com/?6icr3n21ie0dh1w"), openFile.ReadLine() + "/Data/patch-c.mpq");
        }

        private void DownloadComplete(object sender, AsyncCompletedEventArgs e)
        {
            MessageBox.Show("Complete!");
            this.Dispose();
        }
    }
}