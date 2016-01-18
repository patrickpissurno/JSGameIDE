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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    public partial class UIForm : Form
    {
        //UI Form temporary data variables
        public int id = -1;
        public string onCreate = "";
        public string onUpdate = "";
        public string onDraw = "";
        public string onKeyPressed = "";
        public string onKeyReleased = "";
        public string onDestroy = "";
        public UIComponent[] Components = null;

        public UIForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the temporary UI name text
        /// </summary>
        /// <param name="_txt">A string containing the new name</param>
        public void SetNameBoxText(string _txt)
        {
            nameBox.Text = _txt;
        }

        /// <summary>
        /// Sets the First box (whether the game starts with this UI) to a new value
        /// </summary>
        /// <param name="bl">A boolean</param>
        public void SetFirstBox(bool bl)
        {
            movableBox.Checked = bl;
        }

        /// <summary>
        /// Returns the current temporary name of this UI
        /// </summary>
        /// <returns>A string containing the name</returns>
        public string GetNameBoxText()
        {
            return nameBox.Text;
        }

        /// <summary>
        /// Returns the First box value (whether the game starts with this UI)
        /// </summary>
        /// <returns>A boolean</returns>
        public bool GetMovableBox()
        {
            return movableBox.Checked;
        }

        //"Create" button click event
        private void createButton_Click(object sender, EventArgs e)
        {
            //Opens the UI Create Event data in the Code Editor
            this.onCreate = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Create",
                IDEComponent.ComponentType.UI, this.onCreate, this.id, "create");
        }

        //"Update" button click event
        private void updateButton_Click(object sender, EventArgs e)
        {
            //Opens the UI Update Event data in the Code Editor
            this.onUpdate = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Update",
                IDEComponent.ComponentType.UI, this.onUpdate, this.id, "update");
        }

        //"Draw" button click event
        private void drawButton_Click(object sender, EventArgs e)
        {
            //Opens the UI Draw Event data in the Code Editor
            this.onDraw = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Draw",
                IDEComponent.ComponentType.UI, this.onDraw, this.id, "draw");
        }

        //"Key Pressed" button click event
        private void keypressedButton_Click(object sender, EventArgs e)
        {
            //Opens the UI Key Pressed Event data in the Code Editor
            this.onKeyPressed = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Key Pressed",
                IDEComponent.ComponentType.UI, this.onKeyPressed, this.id, "keyPressed");
        }

        //"Key Released" button click event
        private void keyreleasedButton_Click(object sender, EventArgs e)
        {
            //Opens the UI Key Released Event data in the Code Editor
            this.onKeyReleased = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Key Released",
                IDEComponent.ComponentType.UI, this.onKeyReleased, this.id, "keyReleased");
        }

        //"UI Editor" button click event
        private void UIEditorButton_Click(object sender, EventArgs e)
        {
            //Opens the UI Editor with the current UI
            //using (var form = new UIEditor())
            //{
            //    form.Text = "Level Editor: " + nameBox.Text;
            //    form.SetData(this.Components);
            //    var result = form.ShowDialog();
            //    if (result == DialogResult.OK)
            //    {
            //        this.components = form.GetData();
            //    }
            //    form.Close();
            //}
        }

        private void UIForm_Load(object sender, EventArgs e)
        {

        }

        private void destroyButton_Click(object sender, EventArgs e)
        {
            this.onDestroy = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Destroy",
                IDEComponent.ComponentType.UI, this.onDestroy, this.id, "destroy");
        }
    }
}
