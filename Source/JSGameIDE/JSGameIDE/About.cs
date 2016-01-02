using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    partial class About : Form
    {
        public About()
        {
            InitializeComponent();
            int v = -1;
            string msg = "";
            try
            {
                v = int.Parse(new System.Net.WebClient().DownloadString("http://patrickpissurno.github.io/JSGVersion.html").Trim());
                msg += v > IDEConfig.IDEVersion ? " (New Update Available)" : "";
                msg += IDEConfig.IDEVersion > v ? " (Development build)" : "";
            }
            catch
            {
                msg += " (Can't check for updates)";
            }

            labelVersion.Text = "Update " + IDEConfig.IDEVersion.ToString() + msg;
        }

        //Ok button event
        private void okButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
