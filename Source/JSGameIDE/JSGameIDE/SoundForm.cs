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
using System.Windows.Forms;
using System.IO;
using WMPLib;
using System.Drawing;
using System.Reflection;

namespace JSGameIDE
{
    public partial class SoundForm : Form
    {
        //Temporary sound path variable
        public int id;
        public string path = null;

        private WindowsMediaPlayer Player;
        private Image audioPlay;
        private Image audioStop;

        private Assembly assembly;
        private bool IsPlaying = false;

        public SoundForm()
        {
            InitializeComponent();
            Player = new WindowsMediaPlayer();
            Player.PlayStateChange += Player_PlayStateChange;

            assembly = Assembly.GetExecutingAssembly();
            audioPlay = Image.FromStream(assembly.GetManifestResourceStream("JSGameIDE.audio_play.png"));
            audioStop = Image.FromStream(assembly.GetManifestResourceStream("JSGameIDE.audio_stop.png"));
        }

        private void Player_PlayStateChange(int NewState)
        {
            if ((WMPPlayState)NewState == WMPPlayState.wmppsStopped)
            {
                IsPlaying = false;
                ButtonInvalidate();
            }
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
        /// Sets the temporary path of a sound
        /// </summary>
        /// <param name="_txt">The path to be set</param>
        public void SetPathBoxText(string _txt)
        {
            if (!string.IsNullOrWhiteSpace(_txt))
            {
                pathBox.Text = _txt;
                path = _txt;

                //Change the Sound Player path
                if (Path.GetDirectoryName(_txt) == @"Resources\SND")
                    Player.URL = GameConfig.path + @"\" + _txt;
                else
                    Player.URL = _txt;
                Player.controls.stop();
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
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                SetPathBoxText(openFileDialog1.FileName);
            }
        }

        private void SoundForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Player.close();
        }

        private void playButton_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(Player.URL))
            {
                {
                    if (!IsPlaying)
                    {
                        Player.controls.play();
                        IsPlaying = !IsPlaying;
                        ButtonInvalidate();
                    }
                    else
                        Player.controls.stop();
                }
            }
        }

        private void ButtonInvalidate()
        {
            playButton.BackgroundImage = IsPlaying ? audioStop : audioPlay;
        }
    }
}
