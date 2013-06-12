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
using System.Threading;

namespace WindowsFormsApplication3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //TODO: IMPLEMENT SETTINGS FILE
            //if first run, load directory box
            if (!File.Exists("info.txt"))
            {
                InfoForm firstRun = new InfoForm();
                firstRun.ShowDialog();
            }
            string navurl = "battle.net";
            webBrowser1.Navigate(navurl);
            webBrowser1.ScrollBarsEnabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //set realmlist
            StreamReader openFile = new StreamReader("info.txt");
            string realmlist = openFile.ReadLine();
            openFile.Close();
            realmlist += "/Data/realmlist.wtf";
            Process.Start(realmlist);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //delete cache folder
            StreamReader openFile = new StreamReader("info.txt");
            string path = openFile.ReadLine() + "/Cache";
            if (Directory.Exists(path))
            {
                Directory.Delete(path, true);
            }
            else
            {
                //create popup message
                System.Windows.Forms.MessageBox.Show("Cache file doesn't exist!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            openFile.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //launch game
            StreamReader openFile = new StreamReader("info.txt");
            string path = openFile.ReadLine();
            Process.Start(path+ "/Wow.exe");
            this.Close();
        }

    }
}
