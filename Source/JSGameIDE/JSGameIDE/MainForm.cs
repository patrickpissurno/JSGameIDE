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
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.Media;

namespace JSGameIDE
{
    public partial class MainForm : Form
    {
        private new bool Focused = false;
        public MainForm()
        {
            //Updates this form reference on the File Manager
            FileManager.mainForm = this;
            InitializeComponent();
            LivePreview.Init(this, livePreview, developerTab, tableLayoutPanel1);
            this.KeyPreview = true;
            this.Activated += MainForm_Activated;
            this.Deactivate += MainForm_Deactivated;
        }

        void MainForm_Activated(object sender, EventArgs e)
        {
            Focused = true;
            if (!IDEConfig.IsDefaultEditor)
            {
                FileManager.ReloadCode();
                LivePreview.Reload();
            }
        }
        void MainForm_Deactivated(object sender, EventArgs e)
        {
            Focused = false;
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
                    case "Sounds":
                        //Opens the Sound Form and loads it with the given sprite data
                        using (var form = new SoundForm())
                        {
                            form.Text = "Properties of " + e.Node.Text;
                            form.SetNameBoxText(e.Node.Text);
                            form.id = int.Parse(e.Node.Name);
                            form.SetPathBoxText(Sounds.sounds[int.Parse(e.Node.Name)].path);
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given sound
                                Sounds.SetName(int.Parse(e.Node.Name), form.GetNameBoxText());
                                if (!string.IsNullOrWhiteSpace(form.path))
                                {
                                    DirectoryInfo _dir = new DirectoryInfo(form.path);
                                    if (!string.IsNullOrWhiteSpace(_dir.Parent.ToString()) && _dir.Parent.ToString() != "SND")
                                    {
                                        //Copies the sound to the resources folder
                                        Directory.CreateDirectory(GameConfig.path + @"\Resources\SND");
                                        string _path = @"Resources\SND" + @"\snd" + form.id + Path.GetExtension(form.path);
                                        try
                                        {
                                            if (File.Exists(GameConfig.path + @"\" + _path))
                                                File.Delete(GameConfig.path + @"\" + _path);
                                            File.Copy(form.path, GameConfig.path + @"\" + _path, true);
                                        }
                                        catch { }
                                        Sounds.SetPath(int.Parse(e.Node.Name), _path);
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
                            Room room = Rooms.rooms[int.Parse(e.Node.Name)];
                            form.id = room.id;
                            form.SetFirstBox(int.Parse(e.Node.Name) == Rooms.firstId);
                            form.onCreate = room.onCreate;
                            form.onUpdate = room.onUpdate;
                            form.onDraw = room.onDraw;
                            form.onKeyPressed = room.onKeyPressed;
                            form.onKeyReleased = room.onKeyReleased;
                            form.editorCreate = room.editorCreate;
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given room
                                Rooms.SetName(int.Parse(e.Node.Name), form.GetNameBoxText());
                                if (form.GetFirstBox())
                                    Rooms.firstId = int.Parse(e.Node.Name);
                                room.onCreate = form.onCreate;
                                room.onUpdate = form.onUpdate;
                                room.onDraw = form.onDraw;
                                room.onKeyPressed = form.onKeyPressed;
                                room.onKeyReleased = form.onKeyReleased;
                                room.editorCreate = form.editorCreate;
                                room.gravityX = form.GravityX;
                                room.gravityY = form.GravityY;
                                room.allowSleep = form.AllowSleep;
                                if (!IDEConfig.IsDefaultEditor)
                                    FileManager.ReloadCode();
                                FileManager.UnsavedChanges = true;
                            }
                            form.Close();
                        }
                        break;
                    case "UIs":
                        //Opens the UI Form and loads it with the given UI data
                        using (var form = new UIForm())
                        {
                            form.Text = "Properties of " + e.Node.Text;
                            form.SetNameBoxText(e.Node.Text);
                            UI ui = UIs.uis[int.Parse(e.Node.Name)];
                            form.id = ui.id;
                            form.SetMovableBox(ui.movable);
                            form.onCreate = ui.onCreate;
                            form.onUpdate = ui.onUpdate;
                            form.onDraw = ui.onDraw;
                            form.onKeyPressed = ui.onKeyPressed;
                            form.onKeyReleased = ui.onKeyReleased;
                            form.onDestroy = ui.onDestroy;
                            form.Components = ui.components;
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given UI
                                UIs.SetName(int.Parse(e.Node.Name), form.GetNameBoxText());
                                ui.onCreate = form.onCreate;
                                ui.onUpdate = form.onUpdate;
                                ui.onDraw = form.onDraw;
                                ui.onKeyPressed = form.onKeyPressed;
                                ui.onKeyReleased = form.onKeyReleased;
                                ui.onDestroy = form.onDestroy;
                                ui.components = form.Components;
                                ui.movable = form.GetMovableBox();
                                ui.align = form.Alignment;
                                ui.x = form.x;
                                ui.y = form.y;
                                ui.width = form.width;
                                ui.height = form.height;
                                if (!IDEConfig.IsDefaultEditor)
                                    FileManager.ReloadCode();
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
                            Object obj = Objects.objects[int.Parse(e.Node.Name)];
                            form.id = obj.id;
                            form.SetSpriteBox(obj.sprite);
                            form.SetAutoDrawBox(obj.autoDraw);
                            form.onCreate = obj.onCreate;
                            form.onUpdate = obj.onUpdate;
                            form.onDraw = obj.onDraw;
                            form.onKeyPressed = obj.onKeyPressed;
                            form.onKeyReleased = obj.onKeyReleased;
                            form.onMousePressed = obj.onMousePressed;
                            form.onMouseReleased = obj.onMouseReleased;
                            form.onDestroy = obj.onDestroy;
                            form.onCollisionEnter = obj.onCollisionEnter;
                            form.onCollisionExit = obj.onCollisionExit;
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given object
                                Objects.SetName(int.Parse(e.Node.Name), form.GetNameBoxText());
                                obj.onCreate = form.onCreate;
                                obj.onUpdate = form.onUpdate;
                                obj.onDraw = form.onDraw;
                                obj.onKeyPressed = form.onKeyPressed;
                                obj.onKeyReleased = form.onKeyReleased;
                                obj.onMousePressed = form.onMousePressed;
                                obj.onMouseReleased = form.onMouseReleased;
                                obj.onDestroy = form.onDestroy;
                                obj.autoDraw = form.GetAutoDrawBox();
                                obj.sprite = form.GetSpriteBox();
                                obj.bodyType = form.BodyType;
                                obj.usePhysics = form.UsePhysics;
                                obj.lockRotation = form.LockRotation;
                                obj.density = form.Density;
                                obj.friction = form.Friction;
                                obj.restitution = form.Restitution;
                                obj.colliderType = form.ColliderType;
                                obj.onCollisionEnter = form.onCollisionEnter;
                                obj.onCollisionExit = form.onCollisionExit;
                                if (!IDEConfig.IsDefaultEditor)
                                    FileManager.ReloadCode();
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
                            form.id = Scripts.scripts[int.Parse(e.Node.Name)].id;
                            form.data = Scripts.scripts[int.Parse(e.Node.Name)].data;
                            var result = form.ShowDialog();
                            if (result == DialogResult.OK)
                            {
                                //Updates the data of the given script
                                int id = int.Parse(e.Node.Name);
                                Script script = Scripts.scripts[id];
                                script.data = form.data;

                                //Updates the code with the new script name
                                string name = form.GetNameBoxText();
                                if (script.name != name)
                                {
                                    if (!IDEConfig.IsDefaultEditor)
                                    {
                                        string newData = FileManager.ReadSingle(script, null);
                                        if (newData != null)
                                            script.data = newData;
                                    }
                                    script.data = script.data.Replace(script.name, name);
                                    FileManager.UpdateSingle(script, script.data, null);
                                }

                                Scripts.SetName(id, name);
                                if (!IDEConfig.IsDefaultEditor)
                                    FileManager.ReloadCode();
                                FileManager.UnsavedChanges = true;
                            }
                            form.Close();
                        }
                        break;
                }
            }
        }

        //Add new room button click event
        private void RoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Rooms.rooms.Add(new Room("room", this));
        }

        //New project button click event
        private void newToolStripMenuItem1_Click(object sender, EventArgs e)
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
                SystemSounds.Exclamation.Play();
                DialogResult _res = MessageBox.Show("Save changes to the project?", "JSGameIDE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (_res == DialogResult.Yes)
                    FileManager.Save(true);
                run = _res == DialogResult.Yes || _res == DialogResult.No;
            }
            else
                run = true;
            if (run)
            {
                FileManager.UnsavedChanges = false;
                LivePreview.Shutdown();
                Application.Exit();
            }
            else
                e.Cancel = true;
        }

        //Export and run button click event
        private void buildAndRunToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(Builder.Build(true))
                System.Diagnostics.Process.Start(GameConfig.path + @"\Build\HTML5\index.html");
        }

        //Save project button click event
        private void saveToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FileManager.Save();
        }

        //Open project button click event
        private void openToolStripMenuItem1_Click(object sender, EventArgs e)
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
                if (componentsTree.SelectedNode != null && componentsTree.SelectedNode.Parent != null)
                {
                    childMenu.Show(componentsTree, e.Location);
                }
            }
        }

        //Tree view delete click event
        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (componentsTree.SelectedNode.Parent != null)
            {
                int id = int.Parse(componentsTree.SelectedNode.Name);
                switch (componentsTree.SelectedNode.Parent.Text)
                {
                    case "Sprites":
                        //Deletes the given sprite
                        Sprites.Delete(id);
                        break;
                    case "Objects":
                        //Deletes the given object
                        Objects.Delete(id);
                        break;
                    case "UIs":
                        //Deletes the given UI
                        UIs.Delete(id);
                        break;
                    case "Rooms":
                        //Deletes the given room
                        Rooms.Delete(id);
                        break;
                    case "Scripts":
                        //Deletes the given user-defined function
                        Scripts.Delete(id);
                        break;
                    case "Sounds":
                        //Deletes the given sound
                        Sounds.Delete(id);
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
        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var aboutForm = new About();
            aboutForm.Show();
        }

        //Project options menu button click event
        private void projectOptionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new ProjectOptionsForm(GameConfig.name, GameConfig.width, GameConfig.height, GameConfig.viewWidth,
                GameConfig.viewHeight, GameConfig.author, GameConfig.copyright, GameConfig.windowStyle);
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
                        string name = form.GetProjectName();
                        string newPath = GameConfig.path.Replace(GameConfig.name, name);

                        //Access denied bug. Something is locking the file.
                        Directory.Move(GameConfig.path, newPath);
                        GameConfig.path = newPath;
                        GameConfig.name = name;
                        FileManager.Save(true);
                    }
                }
                catch {
                    MessageBox.Show("Error setting the project name");
                }
                GameConfig.copyright = form.Copyright.Trim();
                GameConfig.author = form.Author.Trim();
                GameConfig.windowStyle = form.WindowStyle.Trim();
                FileManager.UnsavedChanges = true;
            }
        }

        private void scriptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Scripts.scripts.Add(new Script("script", this));
        }

        private void wikiToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/patrickpissurno/JSGameIDE/wiki");
        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var form = new EditorOptionsForm();
            form.ShowDialog();
            if (form.DialogResult == DialogResult.OK)
            {
                IDEConfig.CodeEditors = form.Paths;
                IDEConfig.CodeEditorIndex = form.selectedIndex;
                IDEConfig.Save();
            }
        }

        private void reloadAssetsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                FileManager.ReloadCode();
            }
            catch 
            {
                MessageBox.Show("Error reloading project assets");
            }
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LivePreview.Reload();
        }

        private void windowsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            WindowsExport.Build();
        }

        private void hTML5ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Builder.Build();
        }

        public static void HotkeysDown(Keys key, bool control)
        {
            if (FileManager.mainForm != null && FileManager.mainForm.Focused)
            {
                if (control)
                {
                    switch (key)
                    {
                        case Keys.S:
                            //Saves the project
                            FileManager.Save(true);
                            break;
                        case Keys.B:
                            //Export and run the project
                            if (Builder.Build(true))
                                System.Diagnostics.Process.Start(GameConfig.path + @"\Build\HTML5\index.html");
                            break;

                    }
                }
            }
        }

        private void toggleDebugToolStripMenuItem_Click(object sender, EventArgs e)
        {
            toggleDebugToolStripMenuItem.Text = LivePreview.ConsoleOpen ? "Show debug" : "Hide debug";
            LivePreview.ConsoleOpen = !LivePreview.ConsoleOpen;
            LivePreview.ShowDebug(LivePreview.ConsoleOpen);
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            LivePreview.ShowDebug(false);
        }

        private void soundToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Sounds.sounds.Add(new Sound("", "sound", this));
        }

        private void uIToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UIs.uis.Add(new UI("ui", this));
        }
    }
}
