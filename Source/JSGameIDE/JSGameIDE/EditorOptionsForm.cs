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
    public partial class EditorOptionsForm : Form
    {
        public List<string> Paths = null;
        public int selectedIndex = 0;
        public EditorOptionsForm()
        {
            InitializeComponent();
            Paths = IDEConfig.CodeEditors.ToArray().ToList();
            codeEditorBox.Items.Clear();
            foreach(string str in Paths)
            {
                if (str != "Default")
                    codeEditorBox.Items.Add(Path.GetFileName(str));
                else
                    codeEditorBox.Items.Add("Default");
            }
            codeEditorBox.SelectedIndex = IDEConfig.CodeEditorIndex;
            selectedIndex = IDEConfig.CodeEditorIndex;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            selectedIndex = codeEditorBox.SelectedIndex;
            DialogResult = DialogResult.OK;
            FileManager.ReloadCode();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            customEditorFileDialog.ShowDialog();
            if (!string.IsNullOrWhiteSpace(customEditorFileDialog.FileName))
            {
                Paths.Add(customEditorFileDialog.FileName);
                codeEditorBox.Items.Add(Path.GetFileName(customEditorFileDialog.FileName));
                codeEditorBox.SelectedIndex = Paths.Count - 1;
            }
        }
    }
}
