﻿/*
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
    public partial class ProjectOptionsForm : Form
    {
        public string lastCanvasWidth = "";
        public string lastCanvasHeight = "";
        public string lastViewWidth = "";
        public string lastViewHeight = "";
        public string icon = "";
        public string Copyright
        {
            get
            {
                return copyrightBox.Text;
            }
            set
            {
            }
        }
        public string Author
        {
            get
            {
                return authorBox.Text;
            }
            set
            {
            }
        }

        public string WindowStyle
        {
            get
            {
                return windowStyleBox.Items[windowStyleBox.SelectedIndex].ToString().ToLower();
            }
            set
            {
            }
        }

        /// <summary>
        /// Opens a Project Options Form
        /// </summary>
        /// <param name="projectName">The old project name</param>
        /// <param name="canvasWidth">The old canvas width</param>
        /// <param name="canvasHeight">The old canvas height</param>
        /// <param name="viewWidth">The old view width</param>
        /// <param name="viewHeight">The old view height</param>
        public ProjectOptionsForm(string projectName, int canvasWidth, int canvasHeight, int viewWidth, int viewHeight, string author, string copyright,
            string windowStyle)
        {
            InitializeComponent();
            projectNameBox.Text = projectName;
            widthTextBox.Text = "" + canvasWidth;
            heightTextBox.Text = "" + canvasHeight;
            viewWidthBox.Text = "" + viewWidth;
            viewHeightBox.Text = "" + viewHeight;
            authorBox.Text = author;
            copyrightBox.Text = copyright;
            iconBox.Image = Image.FromFile(GameConfig.path + @"\Resources\icon.ico");
            icon = GameConfig.path + @"\Resources\icon.ico";
            for (int i = 0; i < windowStyleBox.Items.Count; i++)
            {
                if (windowStyleBox.Items[i].ToString().ToLower().Equals(windowStyle))
                {
                    windowStyleBox.SelectedIndex = i;
                    break;
                }
            }
        }

        /// <summary>
        /// Returns the temporary project name
        /// </summary>
        /// <returns>The name as a string</returns>
        public string GetProjectName()
        {
            return projectNameBox.Text.Trim();
        }

        //Make some textboxes only accept integers
        public void Check_If_Int_On_TextChanged(object sender, EventArgs e)
        {
            TextBox textbox = (TextBox)sender;
            int cursorPosition = textbox.SelectionStart;
            if (textbox.Text.Length > 0)
            {
                try
                {
                    int.Parse(textbox.Text);
                    if(textbox == widthTextBox)
                        lastCanvasWidth = textbox.Text;
                    else if(textbox == heightTextBox)
                        lastCanvasHeight = textbox.Text;
                    else if (textbox == viewWidthBox)
                        lastViewWidth = textbox.Text;
                    else if (textbox == viewHeightBox)
                        lastViewHeight = textbox.Text;
                }
                catch
                {
                    if (textbox == widthTextBox)
                        textbox.Text = lastCanvasWidth;
                    else if (textbox == heightTextBox)
                        textbox.Text = lastCanvasHeight;
                    else if (textbox == viewWidthBox)
                        textbox.Text = lastViewWidth;
                    else if (textbox == viewHeightBox)
                        textbox.Text = lastViewHeight;
                    textbox.SelectionStart = cursorPosition;
                }
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            if (lastCanvasWidth.Length > 0 && lastCanvasHeight.Length > 0 && lastViewWidth.Length > 0 &&
                lastViewHeight.Length > 0 && !string.IsNullOrWhiteSpace(projectNameBox.Text) && !string.IsNullOrWhiteSpace(authorBox.Text)
                && !string.IsNullOrWhiteSpace(copyrightBox.Text))
            {
                DialogResult = DialogResult.OK;
                iconBox.Image.Dispose();
                if(!icon.Equals(GameConfig.path + @"\Resources\icon.ico"))
                    File.Copy(icon, GameConfig.path + @"\Resources\icon.ico", true);
                this.Close();
            }
            else
                MessageBox.Show("Some settings are invalid. Please ensure that everything is correct and try again.");
        }

        private void selectIcon_Click(object sender, EventArgs e)
        {
            openIconDialog.ShowDialog();
            if (!openIconDialog.FileName.Equals(GameConfig.path + @"\Resources\icon.ico"))
            {
                icon = openIconDialog.FileName;
                iconBox.Image.Dispose();
                iconBox.Image = Image.FromFile(icon);
            }
        }
    }
}
