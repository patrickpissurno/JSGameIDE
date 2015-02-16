/*
    <JSGameIDE - An open-source IDE+Library to Javascript Game Development>
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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace JSGameIDE
{
    public partial class SpriteForm : Form
    {
        //Temporary sprite path variable
        public int id;
        public string[] path = new string[0];
        private int currentDisplay = 0;

        public SpriteForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the temporary sprite name
        /// </summary>
        /// <param name="_txt">A string containing the new name</param>
        public void SetNameBoxText(string _txt)
        {
            nameBox.Text = _txt;
        }

        /// <summary>
        /// Sets the temporary path of a sprite
        /// </summary>
        /// <param name="_txt">The path to be set</param>
        public void SetPathBoxText(string[] _txt)
        {
            if (_txt != null)
            {
                framesLabel.Text = "Frames: " + _txt.Length;
                pathBox.Text = _txt[currentDisplay];
                path = _txt;

                //Makes the PictureBox display the sprite correctly
                try
                {
                    if (Path.GetDirectoryName(_txt[currentDisplay]) == @"Resources\IMG\spr" + id)
                        previewBox.Image = Image.FromFile(GameConfig.path + @"\" + _txt[currentDisplay]);
                    else
                        previewBox.Image = Image.FromFile(_txt[currentDisplay]);
                    if (previewBox.Image.Width > previewBox.Width || previewBox.Image.Height > previewBox.Height)
                        previewBox.SizeMode = PictureBoxSizeMode.StretchImage;
                    else
                        previewBox.SizeMode = PictureBoxSizeMode.CenterImage;
                }
                catch { }
            }
        }

        /// <summary>
        /// Gets the temporary sprite name
        /// </summary>
        /// <returns>A string containing the temporary name</returns>
        public string GetNameBoxText()
        {
            return nameBox.Text;
        }

        //Open File button click event
        private void openFileButton_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                currentDisplay = 0;
                SetPathBoxText(openFileDialog1.FileNames);
            }
        }

        private void nextFrameButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 0)
            {
                if (currentDisplay < path.Length-1)
                    currentDisplay++;
                else
                    currentDisplay = 0;
                SetPathBoxText(path);
            }
        }

        private void previousFrameButton_Click(object sender, EventArgs e)
        {
            if (path.Length > 0)
            {
                if (currentDisplay > 0)
                    currentDisplay--;
                else
                    currentDisplay = path.Length-1;
                SetPathBoxText(path);
            }
        }
    }
}
