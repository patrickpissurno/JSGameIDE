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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    public partial class RoomForm : Form
    {
        //Room Form temporary data variables
        public int id = -1;
        public string onCreate = "";
        public string onUpdate = "";
        public string onDraw = "";
        public string onKeyPressed = "";
        public string onKeyReleased = "";
        public EditorObject[] editorCreate = null;

        public bool AllowSleep
        {
            get
            {
                return allowSleepBox.Checked;
            }
            set { }
        }

        public decimal GravityX
        {
            get
            {
                return gravityXBox.Value;
            }
            set { }
        }

        public decimal GravityY
        {
            get
            {
                return gravityYBox.Value;
            }
            set { }
        }

        public RoomForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the temporary room name text
        /// </summary>
        /// <param name="_txt">A string containing the new name</param>
        public void SetNameBoxText(string _txt)
        {
            nameBox.Text = _txt;
        }

        /// <summary>
        /// Sets the First box (whether the game starts with this room) to a new value
        /// </summary>
        /// <param name="bl">A boolean</param>
        public void SetFirstBox(bool bl)
        {
            firstBox.Checked = bl;
        }

        /// <summary>
        /// Returns the current temporary name of this room
        /// </summary>
        /// <returns>A string containing the name</returns>
        public string GetNameBoxText()
        {
            return nameBox.Text;
        }

        /// <summary>
        /// Returns the First box value (whether the game starts with this room)
        /// </summary>
        /// <returns>A boolean</returns>
        public bool GetFirstBox()
        {
            return firstBox.Checked;
        }

        //"Create" button click event
        private void createButton_Click(object sender, EventArgs e)
        {
            //Opens the Room Create Event data in the Code Editor
            this.onCreate = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Create",
                IDEComponent.ComponentType.Room, this.onCreate, this.id, "create");
        }

        //"Update" button click event
        private void updateButton_Click(object sender, EventArgs e)
        {
            //Opens the Room Update Event data in the Code Editor
            this.onUpdate = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Update",
                IDEComponent.ComponentType.Room, this.onUpdate, this.id, "update");
        }

        //"Draw" button click event
        private void drawButton_Click(object sender, EventArgs e)
        {
            //Opens the Room Draw Event data in the Code Editor
            this.onDraw = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Draw",
                IDEComponent.ComponentType.Room, this.onDraw, this.id, "draw");
        }

        //"Key Pressed" button click event
        private void keypressedButton_Click(object sender, EventArgs e)
        {
            //Opens the Room Key Pressed Event data in the Code Editor
            this.onKeyPressed = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Key Pressed",
                IDEComponent.ComponentType.Room, this.onKeyPressed, this.id, "keyPressed");
        }

        //"Key Released" button click event
        private void keyreleasedButton_Click(object sender, EventArgs e)
        {
            //Opens the Room Key Released Event data in the Code Editor
            this.onKeyReleased = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Key Released",
                IDEComponent.ComponentType.Room, this.onKeyReleased, this.id, "keyReleased");
        }

        //"Room Editor" button click event
        private void roomEditorButton_Click(object sender, EventArgs e)
        {
            //Opens the Room Editor with the current room
            using (var form = new RoomEditor())
            {
                form.Text = "Level Editor: " + nameBox.Text;
                form.SetData(this.editorCreate);
                var result = form.ShowDialog();
                if (result == DialogResult.OK)
                {
                    this.editorCreate = form.GetData();
                }
                form.Close();
            }
        }

        private void RoomForm_Load(object sender, EventArgs e)
        {
            allowSleepBox.Checked = Rooms.rooms[id].allowSleep;
            gravityXBox.Value = Rooms.rooms[id].gravityX;
            gravityYBox.Value = Rooms.rooms[id].gravityY;
        }
    }
}
