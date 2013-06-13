using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Net;

namespace WindowsFormsApplication3
{
    public partial class MainWindowForm : Form
    {
        public MainWindowForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: IMPLEMENT SETTINGS FILE
            //if first run, load directory box
            if (!File.Exists("info.txt"))
            {
                DirectoryForm firstRun = new DirectoryForm();
                firstRun.ShowDialog();
            }
            StreamReader openFile = new StreamReader("info.txt");
            this.path = openFile.ReadLine();
            openFile.Close();

            //download patch if it doesn't exist
            if (File.Exists(path + "/Data/patch-c.mpq"))
            {
                //patch is there, move forward
            }
            else
            {
                DownloadForm downloadform = new DownloadForm();
                downloadform.ShowDialog();
                
            }
            //connect to database and load news
        }

        

        private void button2_Click(object sender, EventArgs e)
        {
            //set realmlist
            Process.Start(path + "/Data/realmlist.wtf");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete cache folder
            if (Directory.Exists(path + "/Cache"))
            {
                Directory.Delete(path, true);
            }
            else
            {
                //create popup message
                System.Windows.Forms.MessageBox.Show("Cache file doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //launch game
            Process.Start(path + "/Wow.exe");
            this.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AccountCreation accountForm = new AccountCreation();
            accountForm.ShowDialog();
        }

        private string path;

        
    }
}
