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

namespace JSGameIDE
{
    public partial class StartScreen : Form
    {
        public bool quit = true;
        public StartScreen()
        {
            InitializeComponent();
            IDEConfig.Reset();
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
                this.quit = false;
                var form = new MainForm();
                form.Show();
                FileManager.mainForm = form;
                FileManager.Load(openFileDialog1.FileName,true);
                this.Close();
            }
        }
    }
}
