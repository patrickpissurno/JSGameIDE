﻿/*
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
    public partial class ScriptForm : Form
    {
        public int id = -1;
        public string data;

        public ScriptForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the temporary script name text
        /// </summary>
        /// <param name="_txt">A string containing the new name</param>
        public void SetNameBoxText(string _txt)
        {
            nameBox.Text = _txt;
        }

        /// <summary>
        /// Returns the current temporary name of this script
        /// </summary>
        /// <returns>A string containing the name</returns>
        public string GetNameBoxText()
        {
            return nameBox.Text;
        }

        //Edit button click
        private void editButton_Click(object sender, EventArgs e)
        {
            //Opens this script data in the Code Editor
            this.data = CodeEditor.Open("Code Editor: " + nameBox.Text,
                IDEConfig.ComponentType.Script, this.data, this.id, null);
        }
    }
}
