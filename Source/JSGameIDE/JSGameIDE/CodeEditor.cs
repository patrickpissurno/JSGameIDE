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
using System.Runtime.InteropServices;
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
    public partial class CodeEditor : Form
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern IntPtr SendMessage(IntPtr h, int msg, int wParam, int[] lParam);

        public CodeEditor()
        {
            InitializeComponent();
            SetTabWidth(codeBox,4);
        }


        //Close without saving button click event
        private void closeWithoutSaving_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Abort;
        }

        /// <summary>
        /// Returns the code data
        /// </summary>
        /// <returns>A string containing the data</returns>
        public string GetData()
        {
            return codeBox.Text;
        }

        /// <summary>
        /// Sets the code data
        /// </summary>
        /// <param name="str">A string containing the data</param>
        public void SetData(string str)
        {
            codeBox.Text = str;
        }

        /// <summary>
        /// Sets the Tab width of a text box
        /// </summary>
        /// <param name="textbox">The texbox you want to set the tab width</param>
        /// <param name="tabWidth">The width as an integer</param>
        public void SetTabWidth(TextBox textbox, int tabWidth)
        {
            SendMessage(textbox.Handle, 0x00CB, 1, new int[] { tabWidth * 4 });
        }

        private void CodeEditor_FormClosed(object sender, FormClosedEventArgs e)
        {
            if (this.DialogResult != DialogResult.Abort)
                this.DialogResult = DialogResult.OK;
            else
                this.DialogResult = DialogResult.Cancel;
        }

        public static string Open(string Title, IDEComponent.ComponentType Type, string Data, int Index, string Event)
        {
            string r = Data;
            if (IDEConfig.IsDefaultEditor)
            {
                using (var form = new CodeEditor())
                {
                    form.Text = Title;
                    form.SetData(Data);
                    var result = form.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        r = form.GetData();
                    }
                    form.Close();
                }
            }
            else
            {
                string path = GameConfig.path + @"\Codes";
                switch (Type)
                {
                    case IDEComponent.ComponentType.Object:
                        path += @"\Objects\obj";
                        break;
                    case IDEComponent.ComponentType.Room:
                        path += @"\Rooms\room";
                        break;
                    case IDEComponent.ComponentType.Script:
                        path += @"\Scripts\script";
                        break;
                    case IDEComponent.ComponentType.UI:
                        path += @"\UIs\ui";
                        break;
                    case IDEComponent.ComponentType.UIComponent:
                        path += @"\UIs\ui" + Index + @"\components\component";
                        break;
                }
                path += Event == null ? Index.ToString() + ".js" : Index.ToString() + @"\" + Event + ".js";
                System.Diagnostics.ProcessStartInfo startInfo = new System.Diagnostics.ProcessStartInfo();
                startInfo.FileName = IDEConfig.CodeEditors[IDEConfig.CodeEditorIndex];
                switch(Path.GetFileNameWithoutExtension(startInfo.FileName).ToLower())
                {
                    default:
                        startInfo.Arguments = path;
                        break;
                    case "brackets":
                        //foreach (var process in System.Diagnostics.Process.GetProcessesByName("Brackets"))
                            //process.Kill();
                        startInfo.WorkingDirectory = Path.GetDirectoryName(path);
                        startInfo.Arguments = "\"" + Path.GetFileName(path) + "\"";
                        break;
                }
                System.Diagnostics.Process.Start(startInfo);
            }
            return r;
        }
    }
}
