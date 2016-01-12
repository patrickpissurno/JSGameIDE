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
    public partial class ObjectForm : Form
    {
        //Object form temporary data variables
        public int id = -1;
        public string onCreate = "";
        public string onUpdate = "";
        public string onDraw = "";
        public string onKeyPressed = "";
        public string onKeyReleased = "";
        public string onMousePressed = "";
        public string onMouseReleased = "";
        public string onDestroy = "";

        public Physics.BodyTypes BodyType
        {
            get
            {
                return (Physics.BodyTypes)bodyTypeBox.SelectedIndex;
            }
            set { }
        }

        public Physics.ColliderTypes ColliderType
        {
            get
            {
                return (Physics.ColliderTypes)colliderTypeBox.SelectedIndex;
            }
            set { }
        }

        public bool UsePhysics
        {
            get
            {
                return usePhysicsCheckbox.Checked;
            }
            set { }
        }

        public bool LockRotation
        {
            get
            {
                return lockRotationCheckbox.Checked;
            }
            set { }
        }

        public decimal Density
        {
            get
            {
                return densityBox1.Value;
            }
            set { }
        }

        public decimal Friction
        {
            get
            {
                return frictionBox.Value;
            }
            set { }
        }

        public decimal Restitution
        {
            get
            {
                return restitutionBox.Value;
            }
            set { }
        }

        public ObjectForm()
        {
            InitializeComponent();
            bodyTypeBox.Items.AddRange(new string[] { Physics.BodyTypes.Static.ToString(), Physics.BodyTypes.Kinematic.ToString(), Physics.BodyTypes.Dynamic.ToString()});
            colliderTypeBox.Items.AddRange(new string[] { Physics.ColliderTypes.Box.ToString(), Physics.ColliderTypes.InnerCircle.ToString(), Physics.ColliderTypes.OuterCircle.ToString() });

            //Loads all the game sprites into the object sprite selection menu
            List<string> _sprites = new List<string>();
            _sprites.Add("None");
            foreach (Sprite spr in Sprites.sprites)
            {
                if(spr!=null)
                    _sprites.Add(spr.name);
            }
            spriteBox.Items.AddRange(_sprites.ToArray());
        }

        /// <summary>
        /// Sets the temporary object name text
        /// </summary>
        /// <param name="_txt">A string containing the new name</param>
        public void SetNameBoxText(string _txt)
        {
            nameBox.Text = _txt;
        }

        /// <summary>
        /// Returns the current temporary name of this object
        /// </summary>
        /// <returns>A string containing the name</returns>
        public string GetNameBoxText()
        {
            return nameBox.Text;
        }

        /// <summary>
        /// Sets the currently selected sprite of this object
        /// </summary>
        /// <param name="_id">The id of the sprite as an integer</param>
        public void SetSpriteBox(int _id)
        {
            spriteBox.SelectedItem = Sprites.GetNameById(_id);
        }

        /// <summary>
        /// Returns the id of the currently selected sprite of this object
        /// </summary>
        /// <returns>The id of the sprite as an integer</returns>
        public int GetSpriteBox()
        {
            return Sprites.GetIdByName(spriteBox.SelectedItem.ToString());
        }

        /// <summary>
        /// Sets the Auto Draw box (whether the game automatically draws this object) to a new value
        /// </summary>
        /// <param name="bl">A boolean</param>
        public void SetAutoDrawBox(bool bl)
        {
            autoDrawBox.Checked = bl;
        }

        /// <summary>
        /// Returns the Auto Draw box current value (whether the game automatically draws this object)
        /// </summary>
        /// <returns>A boolean</returns>
        public bool GetAutoDrawBox()
        {
            return autoDrawBox.Checked;
        }

        //Create button click event
        private void createButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Create Event data in the Code Editor
            this.onCreate = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Create",
                IDEConfig.ComponentType.Object, this.onCreate, this.id, "create");
        }

        //Update button click event
        private void updateButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Update Event data in the Code Editor
            this.onUpdate = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Update",
                IDEConfig.ComponentType.Object, this.onUpdate, this.id, "update");
        }

        //Draw button click event
        private void drawButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Draw Event data in the Code Editor
            this.onDraw = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Draw",
                IDEConfig.ComponentType.Object, this.onDraw, this.id, "draw");
        }

        //Key Pressed button click event
        private void keypressedButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Key Pressed Event data in the Code Editor
            this.onKeyPressed = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Key Pressed",
                IDEConfig.ComponentType.Object, this.onKeyPressed, this.id, "keyPressed");
        }

        //Key Released button click event
        private void keyreleasedButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Key Released Event data in the Code Editor
            this.onKeyReleased = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Key Released",
                IDEConfig.ComponentType.Object, this.onKeyReleased, this.id, "keyReleased");
        }

        //Mouse Pressed button click event
        private void mousepressedButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Mouse Pressed Event data in the Code Editor
            this.onMousePressed = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Mouse Pressed",
                IDEConfig.ComponentType.Object, this.onMousePressed, this.id, "mousePressed");
        }

        //Mouse Released button click event
        private void mousereleasedButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Mouse Released Event data in the Code Editor
            this.onMouseReleased = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Mouse Released",
                IDEConfig.ComponentType.Object, this.onMouseReleased, this.id, "mouseReleased");
        }

        //Destroy button click event
        private void destroyButton_Click(object sender, EventArgs e)
        {
            //Opens the Object Destroy Event data in the Code Editor
            this.onDestroy = CodeEditor.Open("Code Editor: " + nameBox.Text + " - Destroy",
                IDEConfig.ComponentType.Object, this.onDestroy, this.id, "destroy");
        }

        private void ObjectForm_Load(object sender, EventArgs e)
        {
            bodyTypeBox.SelectedIndex = (int)Objects.objects[id].bodyType;
            colliderTypeBox.SelectedIndex = (int)Objects.objects[id].colliderType;
            usePhysicsCheckbox.Checked = Objects.objects[id].usePhysics;
            lockRotationCheckbox.Checked = Objects.objects[id].lockRotation;
            densityBox1.Value = Objects.objects[id].density;
            frictionBox.Value = Objects.objects[id].friction;
            restitutionBox.Value = Objects.objects[id].restitution;
        }
    }
}
