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
using System.IO;
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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            //Updates this form reference on the File Manager
            FileManager.mainForm = this;
            InitializeComponent();
        }

        //Add new sprite click event
        private void spriteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] _n = new string[]{""};
            Sprites.sprites.Add(new Sprite(_n,"sprite",this));
        }

        /// <summary>
        /// Adds a new child node to a given category
        /// </summary>
        /// <param name="parent">The category (sprites,rooms,objects), as a string.</param>
        /// <param name="node">The child node</param>
        public void AddViewNodeChild(string parent, TreeNode node)
        {
            componentsTree.Nodes[parent].Nodes.Add(node);
            FileManager.UnsavedChanges = true;
        }

        /// <summary>
        /// Returns all the child nodes of a given category
        /// </summary>
        /// <param name="str">The category (sprites,rooms,objects), as a string.</param>
        /// <returns>The child nodes, as a TreeNodeCollection</returns>
        public TreeNodeCollection GetTreeNodes(string str)
        {
            return componentsTree.Nodes[str].Nodes;
        }

        /// <summary>
        /// Sets the title of the main form
        /// </summary>
        /// <param name="str">The new title, as a string</param>
        public void SetTitle(string str)
        {
            this.Text = "JSGameIDE - " + str;
        }

        //A tree node double click event
        private void componentsTree_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Parent != null)
            {
                switch (e.Node.Parent.Text)
                {
                    case "Sprites":
                        //Opens the Sprite Form and loads it with the given sprite data
                        using (var form = new SpriteForm())
                        {
                            form.Text = "Properties of " + e.Node.Text;
                            form.SetNameBoxText(e.Node.Text);
                            form.id = int.Parse(e.Node.Name);
                            form.SetPathBoxText(Sprites.sprites[int.Parse(e.Node.Name)].path);
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given sprite
                                Sprites.SetName(int.Parse(e.Node.Name),form.GetNameBoxText());
                                if (!string.IsNullOrWhiteSpace(form.path[0]))
                                {
                                    DirectoryInfo _dir = new DirectoryInfo(form.path[0]);
                                    if (!string.IsNullOrWhiteSpace(_dir.Parent.ToString()) && _dir.Parent.ToString() != "IMG")
                                    {
                                        //Creates a new folder named "spr"+id(of the sprite) inside the resources directory and copies
                                        //every image into it, adding each path to the array of paths of the Sprites.sprites variable.
                                        Directory.CreateDirectory(GameConfig.path + @"\Resources\IMG\spr" + int.Parse(e.Node.Name));
                                        int i = 0;
                                        List<string> _tempPath = new List<string>();
                                        foreach (string _p in form.path)
                                        {
                                            string _path = @"Resources\IMG\spr" + int.Parse(e.Node.Name) + @"\" + i + Path.GetExtension(_p);
                                            try
                                            {
                                                File.Copy(_p, GameConfig.path + @"\" + _path, true);
                                            }
                                            catch { }
                                            i++;
                                            _tempPath.Add(_path);
                                        }
                                        Sprites.SetPath(int.Parse(e.Node.Name), _tempPath.ToArray<string>());
                                    }
                                }
                                FileManager.UnsavedChanges = true;
                            }
                            form.Close();
                        }
                        break;
                    case "Rooms":
                        //Opens the Room Form and loads it with the given room data
                        using (var form = new RoomForm())
                        {
                            form.Text = "Properties of " + e.Node.Text;
                            form.SetNameBoxText(e.Node.Text);
                            form.SetFirstBox(int.Parse(e.Node.Name) == Rooms.firstId);
                            form.onCreate = Rooms.rooms[int.Parse(e.Node.Name)].onCreate;
                            form.onUpdate = Rooms.rooms[int.Parse(e.Node.Name)].onUpdate;
                            form.onDraw = Rooms.rooms[int.Parse(e.Node.Name)].onDraw;
                            form.onKeyPressed = Rooms.rooms[int.Parse(e.Node.Name)].onKeyPressed;
                            form.onKeyReleased = Rooms.rooms[int.Parse(e.Node.Name)].onKeyReleased;
                            form.editorCreate = Rooms.rooms[int.Parse(e.Node.Name)].editorCreate;
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given room
                                Rooms.SetName(int.Parse(e.Node.Name), form.GetNameBoxText());
                                if (form.GetFirstBox())
                                    Rooms.firstId = int.Parse(e.Node.Name);
                                Rooms.rooms[int.Parse(e.Node.Name)].onCreate = form.onCreate;
                                Rooms.rooms[int.Parse(e.Node.Name)].onUpdate = form.onUpdate;
                                Rooms.rooms[int.Parse(e.Node.Name)].onDraw = form.onDraw;
                                Rooms.rooms[int.Parse(e.Node.Name)].onKeyPressed = form.onKeyPressed;
                                Rooms.rooms[int.Parse(e.Node.Name)].onKeyReleased = form.onKeyReleased;
                                Rooms.rooms[int.Parse(e.Node.Name)].editorCreate = form.editorCreate;
                                FileManager.UnsavedChanges = true;
                            }
                            form.Close();
                        }
                        break;
                    case "Objects":
                        //Opens the Object Form and loads it with the given object data
                        using (var form = new ObjectForm())
                        {
                            form.Text = "Properties of " + e.Node.Text;
                            form.SetNameBoxText(e.Node.Text);
                            form.SetSpriteBox(Objects.objects[int.Parse(e.Node.Name)].sprite);
                            form.SetAutoDrawBox(Objects.objects[int.Parse(e.Node.Name)].autoDraw);
                            form.onCreate = Objects.objects[int.Parse(e.Node.Name)].onCreate;
                            form.onUpdate = Objects.objects[int.Parse(e.Node.Name)].onUpdate;
                            form.onDraw = Objects.objects[int.Parse(e.Node.Name)].onDraw;
                            form.onKeyPressed = Objects.objects[int.Parse(e.Node.Name)].onKeyPressed;
                            form.onKeyReleased = Objects.objects[int.Parse(e.Node.Name)].onKeyReleased;
                            form.onMousePressed = Objects.objects[int.Parse(e.Node.Name)].onMousePressed;
                            form.onMouseReleased = Objects.objects[int.Parse(e.Node.Name)].onMouseReleased;
                            form.onDestroy = Objects.objects[int.Parse(e.Node.Name)].onDestroy;
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given object
                                Objects.SetName(int.Parse(e.Node.Name), form.GetNameBoxText());
                                Objects.objects[int.Parse(e.Node.Name)].onCreate = form.onCreate;
                                Objects.objects[int.Parse(e.Node.Name)].onUpdate = form.onUpdate;
                                Objects.objects[int.Parse(e.Node.Name)].onDraw = form.onDraw;
                                Objects.objects[int.Parse(e.Node.Name)].onKeyPressed = form.onKeyPressed;
                                Objects.objects[int.Parse(e.Node.Name)].onKeyReleased = form.onKeyReleased;
                                Objects.objects[int.Parse(e.Node.Name)].onMousePressed = form.onMousePressed;
                                Objects.objects[int.Parse(e.Node.Name)].onMouseReleased = form.onMouseReleased;
                                Objects.objects[int.Parse(e.Node.Name)].onDestroy = form.onDestroy;
                                Objects.objects[int.Parse(e.Node.Name)].autoDraw = form.GetAutoDrawBox();
                                Objects.objects[int.Parse(e.Node.Name)].sprite = form.GetSpriteBox();
                                FileManager.UnsavedChanges = true;
                            }
                            form.Close();
                        }
                        break;
                    case "Scripts":
                        //Opens the Script Form and loads it with the given script data
                        using (var form = new ScriptForm())
                        {
                            form.Text = "Properties of " + e.Node.Text;
                            form.SetNameBoxText(e.Node.Text);
                            form.data = Scripts.scripts[int.Parse(e.Node.Name)].data;
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given script
                                Scripts.SetName(int.Parse(e.Node.Name), form.GetNameBoxText());
                                Scripts.scripts[int.Parse(e.Node.Name)].data = form.data;
                                FileManager.UnsavedChanges = true;
                            }
                            form.Close();
                        }
                        break;
                }
            }
        }

        //Export button click event
        private void exportarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Builder.Build();
        }

        //Add new room button click event
        private void RoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms.rooms.Add(new Room("room", this));
        }

        //New project button click event
        private void novoToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var form = new NewProject(false, this);
            form.Show();
            this.Hide();
        }

        //Form closing event
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            //Quit confirmation due to Unsaved Changes
            bool run = false;
            if (FileManager.UnsavedChanges)
            {
                DialogResult _res = MessageBox.Show("Save changes to the project?", "JSGameIDE", MessageBoxButtons.YesNoCancel);
                if (_res == DialogResult.Yes)
                    FileManager.Save(true);
                run = _res == DialogResult.Yes || _res == DialogResult.No;
            }
            else
                run = true;
            if (run)
            {
                FileManager.UnsavedChanges = false;
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        //Export and run button click event
        private void testarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Builder.Build(true))
                System.Diagnostics.Process.Start(GameConfig.path+@"\Build\index.html");
        }

        //Save project button click event
        private void salvarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileManager.Save();
        }

        //Open project button click event
        private void abrirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                //Resets all the project data
                FileManager.mainForm = this;
                GameConfig.Reset();
                //Opens the new project
                FileManager.Load(openFileDialog1.FileName,!FileManager.UnsavedChanges);
            }
        }

        //Mouse Up event of the Tree View
        private void componentsTree_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                componentsTree.SelectedNode = componentsTree.GetNodeAt(e.X, e.Y);
                if (componentsTree.SelectedNode.Parent != null)
                {
                    childMenu.Show(componentsTree, e.Location);
                }
            }
        }

        //Tree view delete click event
        private void deletarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (componentsTree.SelectedNode.Parent != null)
            {
                switch (componentsTree.SelectedNode.Parent.Text)
                {
                    case "Sprites":
                        //Deletes the given sprite
                        Sprites.sprites[int.Parse(componentsTree.SelectedNode.Name)] = null;
                        break;
                    case "Objects":
                        //Deletes the given object
                        Objects.objects[int.Parse(componentsTree.SelectedNode.Name)] = null;
                        break;
                    case "Rooms":
                        //Deletes the given room
                        Rooms.rooms[int.Parse(componentsTree.SelectedNode.Name)] = null;
                        break;
                    case "Scripts":
                        //Deletes the given user-defined function
                        Scripts.scripts[int.Parse(componentsTree.SelectedNode.Name)] = null;
                        break;

                }
                componentsTree.SelectedNode.Remove();
                FileManager.UnsavedChanges = true;
            }
        }

        //Add object menu button click event
        private void ObjectToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Objects.objects.Add(new Object("object", this));
        }

        //About menu button click event
        private void sobreToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new About();
            aboutForm.Show();
        }

        //Project options menu button click event
        private void opçõesDoProjetoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProjectOptionsForm(GameConfig.name, GameConfig.width, GameConfig.height, GameConfig.viewWidth, GameConfig.viewHeight);
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                //Updates the project width
                try
                {
                    GameConfig.width = int.Parse(form.lastCanvasWidth);
                }
                catch
                {
                    MessageBox.Show("Error setting the canvas width");
                }

                //Updates the project height
                try
                {
                    GameConfig.height = int.Parse(form.lastCanvasHeight);
                }
                catch
                {
                    MessageBox.Show("Error setting the canvas height");
                }

                //Updates the project view width
                try
                {
                    GameConfig.viewWidth = int.Parse(form.lastViewWidth);
                }
                catch
                {
                    MessageBox.Show("Error setting the view width");
                }

                //Updates the project view height
                try
                {
                    GameConfig.viewHeight = int.Parse(form.lastViewHeight);
                }
                catch
                {
                    MessageBox.Show("Error setting the view height");
                }

                //Updates the project name
                try
                {
                    if (form.GetProjectName() != GameConfig.name)
                    {
                        DirectoryInfo dir = new DirectoryInfo(GameConfig.path);
                        string newPath;
                        GameConfig.name = form.GetProjectName();

                        if (!string.IsNullOrWhiteSpace(dir.Parent.ToString()))
                            newPath = dir.Parent.ToString() + @"\" + GameConfig.name;
                        else
                            newPath = dir.Root.ToString() + GameConfig.name;

                        Directory.Move(GameConfig.path, newPath);
                        GameConfig.path = newPath;
                        FileManager.Save(true);
                    }
                }
                catch {
                    MessageBox.Show("Error setting the project name");
                }
                FileManager.UnsavedChanges = true;
            }
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scripts.scripts.Add(new Script("script", this));
        }
    }
}
