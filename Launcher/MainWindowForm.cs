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
            string navurl = "battle.net";
            webBrowser1.Navigate(navurl);
            webBrowser1.ScrollBarsEnabled = false;
            StreamReader openFile = new StreamReader("info.txt");
            this.path = openFile.ReadLine();
            openFile.Close();
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

        private string path;
    }
}
