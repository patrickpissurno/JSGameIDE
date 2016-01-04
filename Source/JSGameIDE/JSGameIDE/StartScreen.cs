/*
    <JSGameIDE - An open-source IDE+Framework to Javascript Game Development>
    Copyright (C) 2015  Patrick Pissurno

    This program is free software: you can redistribute it and/or modify
    it under the terms of the GNU General Public License as published by
    the Free Software Foundation, version 3, except for commercial usage,
    which is strictly FORBIDDEN.
   
    COMMERCIAL USAGE IS STRICTLY FORBIDDEN!
    
    If you're going to distribute a version of this program you need to
    keep this commentary in all the classes of it, and also you  should
    mantain it open source and under the same  terms  of  the  original
    version.

    This program is distributed in the hope that it will be useful,
    but WITHOUT ANY WARRANTY; without even the implied warranty of
    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See  the
    GNU General Public License for more details.

    You should have received a copy of  the  GNU  General Public  License
    along with this program.  If  not, see <http://www.gnu.org/licenses/>.
  
    For further  details see: http://patrickpissurno.github.io/JSGameIDE/
 */

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    public partial class StartScreen : Form
    {
        public bool quit = true;
        private string autoLoadPath;

        public Panel[] recentPanels;
        public Label[] recentTitles;
        public Label[] recentPaths;
        public StartScreen(string autoLoadPath = null)
        {
            InitializeComponent();
            IDEConfig.Reset();
            this.autoLoadPath = autoLoadPath;

            this.recentPanels = new Panel[] { recentPanel1, recentPanel2, recentPanel3, recentPanel4 };
            this.recentTitles = new Label[] { recentTitle1, recentTitle2, recentTitle3, recentTitle4 };
            this.recentPaths = new Label[] { recentPath1, recentPath2, recentPath3, recentPath4 }; 

            //Fill recent
            for (int i = 0; i < 4; i++)
            {
                if (i < IDEConfig.RecentProjectNames.Count)
                {
                    if (!string.IsNullOrWhiteSpace(IDEConfig.RecentProjectNames[i]) &&
                        !string.IsNullOrWhiteSpace(IDEConfig.RecentProjectPaths[i]))
                    {
                        recentPanels[i].Show();
                        recentTitles[i].Text = IDEConfig.RecentProjectNames[i];
                        recentPaths[i].Text = IDEConfig.RecentProjectPaths[i];
                    }
                    else
                        recentPanels[i].Hide();
                }
                else
                    recentPanels[i].Hide();
            }
            
        }

        //Start Screen closing event
        private void StartScreen_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (quit)
                Application.Exit();
        }

        //New project button click event
        private void newButton_Click(object sender, EventArgs e)
        {
            var form = new NewProject(true,null,this);
            form.Show();
            this.Hide();
        }

        //Open project button click event
        private void openButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Open(openFileDialog1.FileName);
            }
        }

        private void Open(string path)
        {
            this.quit = false;
            var form = new MainForm();
            form.Show();
            FileManager.mainForm = form;
            FileManager.Load(path, true);
            this.Close();
        }

        private void StartScreen_Load(object sender, EventArgs e)
        {
            if(autoLoadPath != null)
                Open(autoLoadPath);
        }

        private void recentPanel_MouseEnter(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(255, 225, 225, 225);;
            Panel p = recentPanels[int.Parse((sender as Control).Tag.ToString().Trim())-1];
            if (p != null)
                p.BackColor = c;
        }

        private void recentPanel_MouseLeave(object sender, EventArgs e)
        {
            Color c = Color.FromArgb(255, 240, 240, 240);
            Panel p = recentPanels[int.Parse((sender as Control).Tag.ToString().Trim())-1];
            if (p != null)
                p.BackColor = c;
        }

        private void recentPanel_Click(object sender, EventArgs e)
        {
            Open(recentPaths[int.Parse((sender as Control).Tag.ToString().Trim())-1].Text);
        }
    }
}
