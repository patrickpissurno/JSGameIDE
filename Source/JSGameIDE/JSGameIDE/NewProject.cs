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
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    public partial class NewProject : Form
    {
        //Temporary new project variables
        public bool start;
        private bool created = false;
        private MainForm form;
        private StartScreen form2;
        public string path = "";

        /// <summary>
        /// Opens a New Project form
        /// </summary>
        /// <param name="start">If this was called by the Start Screen</param>
        /// <param name="form">A reference to the Main Form (if called by it)</param>
        /// <param name="form2">A reference to the Start Screen (if called by it)</param>
        public NewProject(bool start=false,MainForm form = null,StartScreen form2=null)
        {
            this.start = start;
            if (form != null)
                this.form = form;
            if(form2!=null)
                this.form2=form2;
            InitializeComponent();
        }

        //Path button click event
        private void pathButton_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.path = folderBrowserDialog1.SelectedPath;
                pathBox.Text = this.path;
            }
        }

        /// <summary>
        /// Returns the name of the New Project
        /// </summary>
        /// <returns>A string containing the name</returns>
        public string GetName()
        {
            return nameBox.Text;
        }

        //Create button click event
        private void button2_Click(object sender, EventArgs e)
        {
            MainForm _form;
            if(this.form==null || this.start)
                _form = new MainForm();
            else
                _form = this.form;
            if (this.path != "" && GetName() != "")
            {
                //Quit confirmation due to Unsaved Changes
                bool run = false;
                if (FileManager.UnsavedChanges)
                {
                    DialogResult _res = MessageBox.Show("Save changes to the project?", "JSGameIDE", MessageBoxButtons.YesNoCancel);
                    if (_res == DialogResult.Yes)
                        FileManager.Save(true);
                    run = _res == DialogResult.Yes || _res == DialogResult.No;
                }
                else
                    run = true;
                if (run)
                {
                    //Resets the project data (for sure)
                    GameConfig.Reset();
                    //Creates directories and updates the IDE with the new project's data
                    GameConfig.name = GetName();
                    GameConfig.path = this.path + @"\" + GameConfig.name;
                    if (!Directory.Exists(GameConfig.path + @"\Resources\IMG"))
                        Directory.CreateDirectory(GameConfig.path + @"\Resources\IMG");
                    if (!Directory.Exists(GameConfig.path + @"\Build"))
                        Directory.CreateDirectory(GameConfig.path + @"\Build");
                    File.Copy(Application.StartupPath + @"\Resources\player.ico", GameConfig.path + @"\Resources\icon.ico");
                    _form.SetTitle(GameConfig.name);
                    _form.Show();
                    this.created = true;
                    this.Close();
                }
            }
        }

        //New Project form closing event
        private void NewProject_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!this.start)
            {
                if (this.form != null)
                    this.form.Show();
            }
            else
            {
                if (this.created)
                {
                    this.form2.quit = false;
                    this.form2.Close();
                }
                else
                    this.form2.Show();
            }
        }

        //Cancel button click event
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
