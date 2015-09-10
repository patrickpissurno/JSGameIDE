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
    public partial class RoomEditor : Form
    {
        //Temporary Room Editor Data
        public List<EditorObject> objects = new List<EditorObject>();
        public List<PictureBox> sprites = new List<PictureBox>();

        //Room Editor runtime variables
        private PictureBox _tempDelete = null;
        private Point rDistance = new Point(0,0);
        private bool rPressed = false;
        private Label mouseLabel;

        public RoomEditor()
        {
            InitializeComponent();
            //Fills the add object menu with all the objects of the game
            foreach (Object obj in Objects.objects)
            {
                if (obj != null)
                {
                    ToolStripItem _item = adicionarToolStripMenuItem.DropDownItems.Add(obj.name);
                    _item.Click += ObjectAdder_Click;
                }
            }
            //Adds all the events of the Room Space to it
            roomSpace.MouseMove += EditorRoom_Move;
            roomSpace.MouseUp += EditorRoom_Up;
            //Center aligns the Room Space
            roomSpace.Width = GameConfig.width;
            roomSpace.Height = GameConfig.height;
            roomSpace.Location = new Point(this.Width/2-roomSpace.Width/2,this.Height/2-roomSpace.Height/2);
            //Adds a Label to show the mouse position
            mouseLabel = new Label();
            mouseLabel.Text = "  X: 0 | Y: 0";
            mouseLabel.Location = new Point(0,this.Height-mouseLabel.Height-37);
            mouseLabel.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);
            this.Controls.Add(mouseLabel);
            mouseLabel.BackColor = Color.WhiteSmoke;
            mouseLabel.BorderStyle = BorderStyle.None;
            mouseLabel.AutoSize = false;
            mouseLabel.Width = this.Width;
            mouseLabel.TextAlign = ContentAlignment.MiddleLeft;
            mouseLabel.BringToFront();
        }

        //Room Editor closing event
        private void RoomEditor_FormClosing(object sender, FormClosingEventArgs e)
        {
            foreach (EditorObject obj in objects)
            {
                if (obj != null)
                {
                    if (obj.pic != null)
                    {
                        obj.x = obj.pic.Location.X;
                        obj.y = obj.pic.Location.Y;
                    }
                }
            }
            this.DialogResult = DialogResult.OK;
        }

        /// <summary>
        /// Sets the temporary data of the Room Editor
        /// </summary>
        /// <param name="objs">An array of Editor Objects</param>
        public void SetData(EditorObject[] objs)
        {
            if (objs != null)
            {
                foreach (EditorObject _obj in objs)
                {
                    if (_obj != null)
                    {
                        AddRoomObject(Objects.objects[_obj.id].name, (int)Math.Floor(_obj.x), (int)Math.Floor(_obj.y));
                    }
                }
            }
        }

        /// <summary>
        /// Returns the temporary data of the Room Editor
        /// </summary>
        /// <returns>Returns an array of EditorObjects</returns>
        public EditorObject[] GetData()
        {
            if (this.objects != null)
            {
                List<EditorObject> _objs = new List<EditorObject>();
                foreach (EditorObject obj in this.objects)
                {
                    if (obj != null)
                        _objs.Add(obj);
                }
                return _objs.ToArray<EditorObject>();
            }
            else
                return null;
        }

        //Top bar add object click event
        private void ObjectAdder_Click(object sender, EventArgs e)
        {
            ToolStripItem item = (ToolStripItem)sender;
            AddRoomObject(item.Text);
        }

        //Room Drag'n'Drop
        private void EditorRoom_Move(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Middle)
            {
                if (!this.rPressed)
                {
                    this.rPressed = true;
                    this.rDistance = roomSpace.PointToClient(Cursor.Position);
                }
                Point _mouse = this.PointToClient(Cursor.Position);
                roomSpace.Location = new Point(_mouse.X - this.rDistance.X, _mouse.Y - this.rDistance.Y);
            }
            //Updates the mouseLabel text
            Point mp = roomSpace.PointToClient(Cursor.Position);
            mouseLabel.Text = "  X: " + mp.X + " | Y: " + mp.Y;
        }
        
        //Resets the Room Drag'n'Drop
        private void EditorRoom_Up(object sender, MouseEventArgs e)
        {
            this.rPressed = false;
        }

        //Object Drag'n'Drop
        private void EditorObject_Hold(object sender, MouseEventArgs e)
        {
            PictureBox _pic = ((PictureBox)sender);
            if (e.Button == MouseButtons.Left)
            {
                Point pos = roomSpace.PointToClient(Cursor.Position);
                if (GameConfig.gridEnabled)
                {
                    int newX = Math.Round(oldX / gridCubeWidth) * gridCubeWidth;
                    int newY = Math.Round(oldY / gridCubeHeight) * gridCubeHeight;
                }
                _pic.Location = pos;
            }
            //Updates the mouseLabel with the position of the object and with its name
            mouseLabel.Text = "  X: " + _pic.Location.X + " | Y: " + _pic.Location.Y + "        " + Objects.GetNameById(int.Parse(_pic.Name));
        }

        private void EditorObject_Click(object sender, MouseEventArgs e)
        {
            //Shows the instance context menu
            if (e.Button == MouseButtons.Right)
            {
                this._tempDelete = ((PictureBox)sender);
                instanceMenu.Show(this._tempDelete, e.Location);
            }
        }

        /// <summary>
        /// Adds a given object to the room
        /// </summary>
        /// <param name="objName">A string containing the name of the given object</param>
        /// <param name="_x">The X position where it should be created</param>
        /// <param name="_y">The Y position where it should be created</param>
        public void AddRoomObject(string objName,int _x=20,int _y=20)
        {

            int _id = Objects.GetIdByName(objName);
            if (_id >= 0)
            {
                PictureBox _t = new PictureBox();
                _t.Location = new Point(_x, _y);
                _t.Image = Image.FromFile(GameConfig.path + @"\" +Sprites.sprites[Objects.objects[_id].sprite].path[0]);
                _t.Size = _t.Image.Size;
                _t.Name = ""+_id;
                roomSpace.Controls.Add(_t);
                this.sprites.Add(_t);
                this.objects.Add(new EditorObject(_x, _y, _id, _t));
                _t.MouseMove += EditorObject_Hold;
                _t.MouseDown += EditorObject_Click;
            }
        }

        //Deletes the object which is below the mouse
        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < this.sprites.Count(); i++)
            {
                PictureBox _p = this.sprites[i];
                if (_p != null)
                {
                    if (this._tempDelete == _p)
                    {
                        roomSpace.Controls.Remove(this._tempDelete);
                        this.sprites.Remove(this._tempDelete);
                        this.objects.RemoveAt(i);
                        break;
                    }
                }
            }
        }

        //Room Editor resize event
        private void RoomEditor_Resize(object sender, EventArgs e)
        {
            //Center aligns the Room Space
            roomSpace.Location = new Point(this.Width / 2 - roomSpace.Width / 2, this.Height / 2 - roomSpace.Height / 2);
            //Sets the size of the bottom label
            mouseLabel.Width = this.Width;
        }

        private void gridOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new GridOptionsForm(GameConfig.gridWidth, GameConfig.gridHeight, GameConfig.gridEnabled);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                GameConfig.gridEnabled = form.lastGridEnabled;
                GameConfig.gridWidth = int.Parse(form.lastGridWidth);
                GameConfig.gridHeight = int.Parse(form.lastGridHeight);
            }
        }

    }
}
