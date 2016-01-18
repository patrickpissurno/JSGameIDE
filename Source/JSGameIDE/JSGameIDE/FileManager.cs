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

/* This program  uses  a third-party  extension  for the JSON writing and
 * reading,  which was not developed  by  me: JSON.NET.  All the credits/
 * rights  of  this  extension are  of  its  author:  James  Newton-King.
 * This  extension is provided  without  ANY WARRANTY  and  any distribu-
 * tion  of it  should be  done with  its  own  license  and  terms.  For
 * further  details  about  JSON.NET  see: http://www.newtonsoft.com/json
 *                For more details about its license see: 
 * https://github.com/JamesNK/Newtonsoft.Json.Schema/blob/master/LICENSE.md
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;
using System.Media;

namespace JSGameIDE
{
    public static class FileManager
    {
        public static MainForm mainForm;
        //Whether any unsaved modification is present
        private static bool unsavedChanges;
        public static bool UnsavedChanges
        {
            get { return unsavedChanges; }
            set
            {
                if (value)
                {
                    mainForm.SetTitle(GameConfig.name + "*");
                    LivePreview.Reload();
                }
                else
                    mainForm.SetTitle(GameConfig.name);
                unsavedChanges = value;
            }
        }
        public static bool ProjectLoaded = false;

        /// <summary>
        /// Saves the current project
        /// </summary>
        /// <param name="quiet">Whether the quiet mode is on or off</param>
        public static void Save(bool quiet = false)
        {
            try
            {
                JSGP package = new JSGP();
                package.projectVersion = GameConfig.projectVersion;
                package.name = GameConfig.name;
                package.author = GameConfig.author;
                package.copyright = GameConfig.copyright;
                package.gameWidth = GameConfig.width;
                package.gameHeight = GameConfig.height;
                package.viewWidth = GameConfig.viewWidth;
                package.viewHeight = GameConfig.viewHeight;
                package.windowStyle = GameConfig.windowStyle;
                package.rooms = Rooms.rooms.ToArray();
                package.roomAmount = Rooms.amount;
                package.roomFirstId = Rooms.firstId;
                package.sprites = Sprites.sprites.ToArray();
                package.spriteAmount = Sprites.amount;
                package.objects = Objects.objects.ToArray();
                package.objectAmount = Objects.amount;
                package.scripts = Scripts.scripts.ToArray();
                package.scriptAmount = Scripts.amount;
                package.sounds = Sounds.sounds.ToArray();
                package.soundAmount = Sounds.amount;
                package.UIs = UIs.uis.ToArray();
                package.UIAmount = UIs.amount;

                //SAVE CODING DATA
                string targetPath = null;

                //Objects
                foreach (Object obj in Objects.objects)
                {
                    if (obj != null)
                    {
                        targetPath = GameConfig.path + @"\Codes\Objects\obj" + obj.id;
                        Directory.CreateDirectory(targetPath);
                        using (StreamWriter w = new StreamWriter(targetPath + @"\create.js"))
                        {
                            w.Write(obj.onCreate);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\update.js"))
                        {
                            w.Write(obj.onUpdate);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\draw.js"))
                        {
                            w.Write(obj.onDraw);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\keyPressed.js"))
                        {
                            w.Write(obj.onKeyPressed);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\keyReleased.js"))
                        {
                            w.Write(obj.onKeyReleased);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\destroy.js"))
                        {
                            w.Write(obj.onDestroy);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\mousePressed.js"))
                        {
                            w.Write(obj.onMousePressed);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\mouseReleased.js"))
                        {
                            w.Write(obj.onMouseReleased);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\collisionEnter.js"))
                        {
                            w.Write(obj.onCollisionEnter);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\collisionExit.js"))
                        {
                            w.Write(obj.onCollisionExit);
                        }
                    }
                }

                //Rooms
                foreach (Room rm in Rooms.rooms)
                {
                    if (rm != null)
                    {
                        targetPath = GameConfig.path + @"\Codes\Rooms\room" + rm.id;
                        Directory.CreateDirectory(targetPath);
                        using (StreamWriter w = new StreamWriter(targetPath + @"\create.js"))
                        {
                            w.Write(rm.onCreate);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\update.js"))
                        {
                            w.Write(rm.onUpdate);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\draw.js"))
                        {
                            w.Write(rm.onDraw);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\keyPressed.js"))
                        {
                            w.Write(rm.onKeyPressed);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\keyReleased.js"))
                        {
                            w.Write(rm.onKeyReleased);
                        }
                    }
                }

                //UIs
                foreach (UI ui in UIs.uis)
                {
                    if (ui != null)
                    {
                        targetPath = GameConfig.path + @"\Codes\UIs\ui" + ui.id;
                        Directory.CreateDirectory(targetPath);
                        using (StreamWriter w = new StreamWriter(targetPath + @"\create.js"))
                        {
                            w.Write(ui.onCreate);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\update.js"))
                        {
                            w.Write(ui.onUpdate);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\draw.js"))
                        {
                            w.Write(ui.onDraw);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\keyPressed.js"))
                        {
                            w.Write(ui.onKeyPressed);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\keyReleased.js"))
                        {
                            w.Write(ui.onKeyReleased);
                        }
                        using (StreamWriter w = new StreamWriter(targetPath + @"\destroy.js"))
                        {
                            w.Write(ui.onDestroy);
                        }
                        targetPath += @"\components";
                        Directory.CreateDirectory(targetPath);
                        if (ui.components != null)
                        {
                            foreach(UIComponent component in ui.components)
                            {
                                if(component != null)
                                {
                                    using (StreamWriter w = new StreamWriter(targetPath + @"\component" + component.id + ".js"))
                                    {
                                        w.Write(component.data);
                                    }
                                }
                            }
                        }
                    }
                }

                foreach (Script s in Scripts.scripts)
                {
                    if (s != null)
                    {
                        targetPath = GameConfig.path + @"\Codes\Scripts";
                        Directory.CreateDirectory(targetPath);
                        using (StreamWriter w = new StreamWriter(targetPath + @"\script" + s.id + ".js"))
                        {
                            w.Write(s.data);
                        }
                    }
                }

                //Save the editor preferences
                package.gridWidth = GameConfig.gridWidth;
                package.gridHeight = GameConfig.gridHeight;
                package.gridEnabled = GameConfig.gridEnabled;

                string output = JsonConvert.SerializeObject(package);
                using (StreamWriter outfile = new StreamWriter(GameConfig.path + @"\project.JSGP"))
                {
                    outfile.Write(output);
                }
                if (!quiet)
                {
                    MessageBox.Show("Project saved successfully.");
                }
                FileManager.UnsavedChanges = false;
            }
            catch {
                if(!quiet)
                    MessageBox.Show("Saving error.");
            }
        }

        /// <summary>
        /// Loads a given project
        /// </summary>
        /// <param name="path">A string containing the path to the given project</param>
        public static void Load(string path,bool quiet = false, StartScreen startScreen = null)
        {
            bool run;
            if (!quiet)
            {
                DialogResult _res = MessageBox.Show("Save changes to the project?", "JSGameIDE", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);
                if (_res == DialogResult.Yes)
                    Save(true);
                run =  _res== DialogResult.Yes || _res == DialogResult.No;
            
            }
            else
                run = true;
            if (run)
            {
                try
                {
                    string input = "";
                    //Reads all the project data
                    using (StreamReader sr = new StreamReader(path))
                    {
                        input += sr.ReadToEnd();
                    }
                    //Parses the file (JSON)
                    var output2 = JsonConvert.DeserializeObject<dynamic>(input);
                    //Updates all the project data
                    GameConfig.name = (string)output2.name;
                    try
                    {
                        GameConfig.projectVersion = (int)output2.projectVersion;
                    }
                    catch
                    {
                        //LEGACY SUPPORT
                        GameConfig.projectVersion = 0;
                    }
                    if (GameConfig.projectVersion > IDEConfig.IDEVersion)
                    {
                        SystemSounds.Exclamation.Play();
                        DialogResult _res = MessageBox.Show("This project was made on a later version of JSGameIDE. We recommend that you update your IDE to the latest version to open this project, otherwise bugs may appear. Force the project to be opened?", "JSGameIDE", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
                        if (_res != DialogResult.Yes)
                            run = false;
                    }
                    else if (GameConfig.projectVersion < IDEConfig.IDEVersion)
                    {
                        SystemSounds.Exclamation.Play();
                        DialogResult _res = MessageBox.Show("This project was made on a earlier version of JSGameIDE. If you proceed, the project will be updated and will no longer be compatible with older versions. Continue?", "JSGameIDE", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
                        if (_res != DialogResult.Yes)
                            run = false;
                    }
                    else
                        run = true;
                    if (run)
                    {
                        GameConfig.path = Path.GetDirectoryName(path);
                        GameConfig.width = (int)output2.gameWidth;
                        GameConfig.height = (int)output2.gameHeight;
                        GameConfig.viewWidth = (int)output2.viewWidth;
                        GameConfig.viewHeight = (int)output2.viewHeight;
                        if (output2.windowStyle != null)
                            GameConfig.windowStyle = (string)output2.windowStyle;
                        Sprites.amount = (int)output2.spriteAmount;
                        if (output2.soundAmount != null)
                            Sounds.amount = (int)output2.soundAmount;
                        else
                            Sounds.amount = 0;
                        if (output2.UIAmount != null)
                            UIs.amount = (int)output2.UIAmount;
                        else
                            UIs.amount = 0;
                        Objects.amount = (int)output2.objectAmount;
                        Rooms.amount = (int)output2.roomAmount;
                        Rooms.firstId = (int)output2.roomFirstId;
                        Scripts.amount = (int)output2.scriptAmount;
                        if (output2.author != null)
                            GameConfig.author = output2.author;
                        if (output2.copyright != null)
                            GameConfig.copyright = output2.copyright;

                        //Load all the preferences
                        if (output2.gridWidth != null)
                            GameConfig.gridWidth = (int)output2.gridWidth;
                        if (output2.gridHeight != null)
                            GameConfig.gridHeight = (int)output2.gridHeight;
                        if (output2.gridEnabled != null)
                            GameConfig.gridEnabled = (bool)output2.gridEnabled;

                        //Loads the sprites
                        var _a = ((JArray)output2.sprites).ToObject<List<dynamic>>();
                        for (int i = 0; i < Sprites.amount; i++) { Sprites.sprites.Add(null); }
                        foreach (var _b in _a)
                        {
                            if (_b != null)
                            {
                                Sprite spr = new Sprite();
                                spr.name = (string)_b.name;
                                spr.id = (int)_b.id;
                                if (_b.path != null)
                                {
                                    List<string> _path = new List<string>();
                                    foreach (var _c in _b.path)
                                    {
                                        _path.Add((string)_c);
                                    }
                                    spr.path = _path.ToArray<string>();
                                }
                                Sprites.sprites[spr.id] = spr;
                                TreeNode _node = new TreeNode(spr.name);
                                _node.Name = "" + spr.id;
                                spr.node = _node;
                                mainForm.AddViewNodeChild("Sprites", _node);
                            }
                        }

                        //Loads the sounds
                        if (output2.sounds != null)
                        {
                            _a = ((JArray)output2.sounds).ToObject<List<dynamic>>();
                            for (int i = 0; i < Sounds.amount; i++) { Sounds.sounds.Add(null); }
                            foreach (var _b in _a)
                            {
                                if (_b != null)
                                {
                                    Sound snd = new Sound();
                                    snd.name = (string)_b.name;
                                    snd.id = (int)_b.id;
                                    snd.path = (string)_b.path;
                                    Sounds.sounds[snd.id] = snd;
                                    TreeNode _node = new TreeNode(snd.name);
                                    _node.Name = "" + snd.id;
                                    snd.node = _node;
                                    mainForm.AddViewNodeChild("Sounds", _node);
                                }
                            }
                        }

                        //Loads the objects
                        _a = ((JArray)output2.objects).ToObject<List<dynamic>>();
                        for (int i = 0; i < Objects.amount; i++) { Objects.objects.Add(null); }
                        foreach (var _b in _a)
                        {
                            if (_b != null)
                            {
                                Object obj = new Object();
                                obj.id = (int)_b.id;
                                obj.name = (string)_b.name;
                                obj.sprite = (int)_b.sprite;
                                obj.autoDraw = (bool)_b.autoDraw;
                                if (_b.usePhysics != null)
                                    obj.usePhysics = (bool)_b.usePhysics;
                                if (_b.bodyType != null)
                                    obj.bodyType = (Physics.BodyTypes)_b.bodyType;
                                if (_b.lockRotation != null)
                                    obj.lockRotation = (bool)_b.lockRotation;
                                if (_b.colliderType != null)
                                    obj.colliderType = (Physics.ColliderTypes)_b.colliderType;
                                if (_b.density != null)
                                    obj.density = (decimal)_b.density;
                                if (_b.friction != null)
                                    obj.friction = (decimal)_b.friction;
                                if (_b.restitution != null)
                                    obj.restitution = (decimal)_b.restitution;
                                string importerPath = GameConfig.path + @"\Codes\Objects\obj" + obj.id;
                                //LEGACY PROJECT IMPORTER
                                if (GameConfig.projectVersion < 1)
                                {
                                    obj.onCreate = (string)_b.onCreate;
                                    obj.onUpdate = (string)_b.onUpdate;
                                    obj.onDraw = (string)_b.onDraw;
                                    obj.onKeyPressed = (string)_b.onKeyPressed;
                                    obj.onKeyReleased = (string)_b.onKeyReleased;
                                    obj.onDestroy = (string)_b.onDestroy;
                                    obj.onMousePressed = (string)_b.onMousePressed;
                                    obj.onMouseReleased = (string)_b.onMouseReleased;
                                    obj.onCollisionEnter = "";
                                    obj.onCollisionExit = "";
                                    Directory.CreateDirectory(importerPath);
                                }
                                else
                                {
                                    obj.onCreate = File.ReadAllText(importerPath + @"\create.js");
                                    obj.onUpdate = File.ReadAllText(importerPath + @"\update.js");
                                    obj.onDraw = File.ReadAllText(importerPath + @"\draw.js");
                                    obj.onKeyPressed = File.ReadAllText(importerPath + @"\keyPressed.js");
                                    obj.onKeyReleased = File.ReadAllText(importerPath + @"\keyReleased.js");
                                    obj.onDestroy = File.ReadAllText(importerPath + @"\destroy.js");
                                    obj.onMousePressed = File.ReadAllText(importerPath + @"\mousePressed.js");
                                    obj.onMouseReleased = File.ReadAllText(importerPath + @"\mouseReleased.js");
                                    if (!File.Exists(importerPath + @"\collisionEnter.js"))
                                        File.CreateText(importerPath + @"\collisionEnter.js").Close();
                                    if (!File.Exists(importerPath + @"\collisionExit.js"))
                                        File.CreateText(importerPath + @"\collisionExit.js").Close();
                                    obj.onCollisionEnter = File.ReadAllText(importerPath + @"\collisionEnter.js");
                                    obj.onCollisionExit = File.ReadAllText(importerPath + @"\collisionExit.js");
                                }
                                Objects.objects[obj.id] = obj;
                                TreeNode _node = new TreeNode(obj.name);
                                _node.Name = "" + obj.id;
                                obj.node = _node;
                                mainForm.AddViewNodeChild("Objects", _node);
                            }
                        }

                        //Loads the rooms
                        for (int i = 0; i < Rooms.amount; i++) { Rooms.rooms.Add(null); }
                        _a = ((JArray)output2.rooms).ToObject<List<dynamic>>();
                        foreach (var _b in _a)
                        {
                            if (_b != null)
                            {
                                Room room = new Room();
                                room.id = (int)_b.id;
                                room.name = (string)_b.name;
                                if (_b.allowSleep != null)
                                    room.allowSleep = (bool)_b.allowSleep;
                                if (_b.gravityX != null)
                                    room.gravityX = (decimal)_b.gravityX;
                                if (_b.gravityY != null)
                                    room.gravityY = (decimal)_b.gravityY;
                                string importerPath = GameConfig.path + @"\Codes\Rooms\room" + room.id;
                                //LEGACY PROJECT IMPORTER
                                if (GameConfig.projectVersion < 1)
                                {
                                    room.onCreate = (string)_b.onCreate;
                                    room.onUpdate = (string)_b.onUpdate;
                                    room.onDraw = (string)_b.onDraw;
                                    room.onKeyPressed = (string)_b.onKeyPressed;
                                    room.onKeyReleased = (string)_b.onKeyReleased;
                                    Directory.CreateDirectory(importerPath);
                                }
                                else
                                {
                                    room.onCreate = File.ReadAllText(importerPath + @"\create.js");
                                    room.onUpdate = File.ReadAllText(importerPath + @"\update.js");
                                    room.onDraw = File.ReadAllText(importerPath + @"\draw.js");
                                    room.onKeyPressed = File.ReadAllText(importerPath + @"\keyPressed.js");
                                    room.onKeyReleased = File.ReadAllText(importerPath + @"\keyReleased.js");
                                }


                                if (_b.editorCreate != null)
                                {
                                    List<EditorObject> _editorCreate = new List<EditorObject>();
                                    foreach (var _c in _b.editorCreate)
                                    {
                                        EditorObject _obj = new EditorObject((float)_c.x, (float)_c.y, (int)_c.id);
                                        _editorCreate.Add(_obj);
                                    }
                                    room.editorCreate = _editorCreate.ToArray<EditorObject>();
                                }
                                Rooms.rooms[room.id] = room;
                                TreeNode _node = new TreeNode(room.name);
                                _node.Name = "" + room.id;
                                room.node = _node;
                                mainForm.AddViewNodeChild("Rooms", _node);
                            }
                        }

                        //Loads the UIs
                        if (output2.UIs != null && output2.UIAmount != null)
                        {
                            for (int i = 0; i < UIs.amount; i++) { UIs.uis.Add(null); }
                            _a = ((JArray)output2.UIs).ToObject<List<dynamic>>();
                            foreach (var _b in _a)
                            {
                                if (_b != null)
                                {
                                    UI ui = new UI();
                                    ui.id = (int)_b.id;
                                    ui.name = (string)_b.name;
                                    ui.x = (int)_b.x;
                                    ui.y = (int)_b.y;
                                    ui.width = (int)_b.width;
                                    ui.height = (int)_b.height;
                                    ui.align = (UI.UIAlignment)_b.align;
                                    ui.movable = (bool)_b.movable;
                                    string importerPath = GameConfig.path + @"\Codes\UIs\ui" + ui.id;
                                    ui.onCreate = File.ReadAllText(importerPath + @"\create.js");
                                    ui.onUpdate = File.ReadAllText(importerPath + @"\update.js");
                                    ui.onDraw = File.ReadAllText(importerPath + @"\draw.js");
                                    ui.onKeyPressed = File.ReadAllText(importerPath + @"\keyPressed.js");
                                    ui.onKeyReleased = File.ReadAllText(importerPath + @"\keyReleased.js");
                                    ui.onDestroy = File.ReadAllText(importerPath + @"\destroy.js");

                                    if (_b.components != null)
                                    {
                                        importerPath += @"\components";
                                        List<UIComponent> components = new List<UIComponent>();
                                        foreach (var _c in _b.components)
                                        {
                                            UIComponent _obj = new UIComponent((int)_c.x, (int)_c.y, (int)_c.id);
                                            if(File.Exists(importerPath + @"\component" + _obj.id + ".js"))
                                                _obj.data = File.ReadAllText(importerPath + @"\component" + _obj.id + ".js");
                                            components.Add(_obj);
                                        }
                                        ui.components = components.ToArray();
                                    }
                                    UIs.uis[ui.id] = ui;
                                    TreeNode _node = new TreeNode(ui.name);
                                    _node.Name = "" + ui.id;
                                    ui.node = _node;
                                    mainForm.AddViewNodeChild("UIs", _node);
                                }
                            }
                        }

                        //Loads the scripts
                        _a = ((JArray)output2.scripts).ToObject<List<dynamic>>();
                        for (int i = 0; i < Scripts.amount; i++) { Scripts.scripts.Add(null); }
                        foreach (var _b in _a)
                        {
                            if (_b != null)
                            {
                                Script script = new Script();
                                script.id = (int)_b.id;
                                script.name = (string)_b.name;

                                string importerPath = GameConfig.path + @"\Codes\Scripts";
                                //LEGACY PROJECT IMPORTER
                                if (GameConfig.projectVersion < 1)
                                {
                                    script.data = (string)_b.data;
                                    Directory.CreateDirectory(importerPath);
                                }
                                else
                                {
                                    script.data = File.ReadAllText(importerPath + @"\script" + script.id + ".js");
                                }
                                Scripts.scripts[script.id] = script;
                                TreeNode _node = new TreeNode(script.name);
                                _node.Name = "" + script.id;
                                script.node = _node;
                                mainForm.AddViewNodeChild("Scripts", _node);
                            }
                        }
                        //Fixes Projects without icon
                        if (!File.Exists(GameConfig.path + @"\Resources\icon.ico"))
                            File.Copy(Application.StartupPath + @"\Resources\player.ico", GameConfig.path + @"\Resources\icon.ico");
                        //LEGACY PROJECT IMPORTER UPDATER
                        if (GameConfig.projectVersion != IDEConfig.IDEVersion)
                        {
                            GameConfig.projectVersion = IDEConfig.IDEVersion;
                            FileManager.Save(true);
                        }
                        FileManager.UnsavedChanges = false;
                        FileManager.ProjectLoaded = true;
                        IDEConfig.RecentProjectAdd(GameConfig.name, GameConfig.path + @"\project.JSGP");
                        if (startScreen != null)
                        {
                            startScreen.Close();
                            mainForm.Show();
                        }
                    }
                    else
                    {
                        if (startScreen != null)
                        {
                            startScreen.quit = true;
                            startScreen.Show();
                            mainForm.Hide();
                        }
                    }
                }
                catch
                {
                    MessageBox.Show("Can't open the file.");
                }
            }
        }

        /// <summary>
        /// Updates a single file
        /// </summary>
        /// <param name="comp">The component to be updated</param>
        /// <param name="data">The new data</param>
        /// <param name="eventName">The event to be updated</param>
        public static void UpdateSingle(IDEComponent comp, string data, string eventName)
        {
            if (comp.Type != IDEComponent.ComponentType.None &&
                comp.Type != IDEComponent.ComponentType.Sprite &&
                comp.Type != IDEComponent.ComponentType.Sound)
            {
                string targetPath = GameConfig.path;
                switch(comp.Type)
                {
                    case IDEComponent.ComponentType.Object:
                        targetPath += @"\Codes\Objects\obj" + ((Object)comp).id + @"\" + eventName + ".js";
                        break;
                    case IDEComponent.ComponentType.Room:
                        targetPath += @"\Codes\Rooms\room" + ((Room)comp).id + @"\" + eventName + ".js";
                        break;
                    case IDEComponent.ComponentType.Script:
                        targetPath += @"\Codes\Scripts\script" + ((Script)comp).id + ".js";
                        break;
                }
                Directory.CreateDirectory(Path.GetDirectoryName(targetPath));
                using (StreamWriter w = new StreamWriter(targetPath))
                {
                    w.Write(data);
                }
            }
        }

        /// <summary>
        /// Reads a single file
        /// </summary>
        /// <param name="comp">The component to be read</param>
        /// <param name="eventName">The event to be read</param>
        public static string ReadSingle(IDEComponent comp, string eventName)
        {
            if (comp.Type != IDEComponent.ComponentType.None &&
                comp.Type != IDEComponent.ComponentType.Sprite &&
                comp.Type != IDEComponent.ComponentType.Sound)
            {
                string targetPath = GameConfig.path;
                switch (comp.Type)
                {
                    case IDEComponent.ComponentType.Object:
                        targetPath += @"\Codes\Objects\obj" + ((Object)comp).id + @"\" + eventName + ".js";
                        break;
                    case IDEComponent.ComponentType.Room:
                        targetPath += @"\Codes\Rooms\room" + ((Room)comp).id + @"\" + eventName + ".js";
                        break;
                    case IDEComponent.ComponentType.Script:
                        targetPath += @"\Codes\Scripts\script" + ((Script)comp).id + ".js";
                        break;
                }
                if(File.Exists(targetPath))
                    return File.ReadAllText(targetPath);
            }
            return null;
        }

        /// <summary>
        /// Reloads all the code from the files.
        /// </summary>
        public static void ReloadCode()
        {
            try
            {
                //Objects
                foreach (Object obj in Objects.objects)
                {
                    if (obj != null)
                    {
                        string importerPath = GameConfig.path + @"\Codes\Objects\obj" + obj.id;
                        if (Directory.Exists(importerPath))
                        {
                            obj.onCreate = File.ReadAllText(importerPath + @"\create.js");
                            obj.onUpdate = File.ReadAllText(importerPath + @"\update.js");
                            obj.onDraw = File.ReadAllText(importerPath + @"\draw.js");
                            obj.onKeyPressed = File.ReadAllText(importerPath + @"\keyPressed.js");
                            obj.onKeyReleased = File.ReadAllText(importerPath + @"\keyReleased.js");
                            obj.onDestroy = File.ReadAllText(importerPath + @"\destroy.js");
                            obj.onMousePressed = File.ReadAllText(importerPath + @"\mousePressed.js");
                            obj.onMouseReleased = File.ReadAllText(importerPath + @"\mouseReleased.js");
                            obj.onCollisionEnter = File.ReadAllText(importerPath + @"\collisionEnter.js");
                            obj.onCollisionExit = File.ReadAllText(importerPath + @"\collisionExit.js");
                        }
                    }
                }
                //UIs
                foreach (UI ui in UIs.uis)
                {
                    if (ui != null)
                    {
                        string importerPath = GameConfig.path + @"\Codes\UIs\ui" + ui.id;
                        if (Directory.Exists(importerPath))
                        {
                            ui.onCreate = File.ReadAllText(importerPath + @"\create.js");
                            ui.onUpdate = File.ReadAllText(importerPath + @"\update.js");
                            ui.onDraw = File.ReadAllText(importerPath + @"\draw.js");
                            ui.onKeyPressed = File.ReadAllText(importerPath + @"\keyPressed.js");
                            ui.onKeyReleased = File.ReadAllText(importerPath + @"\keyReleased.js");
                            ui.onDestroy = File.ReadAllText(importerPath + @"\destroy.js");
                            importerPath += @"\components";
                            if(Directory.Exists(importerPath))
                            {
                                foreach(UIComponent component in ui.components)
                                {
                                    if(component != null && File.Exists(importerPath + @"\component" + component.id + ".js"))
                                        component.data = File.ReadAllText(importerPath + @"\component" + component.id + ".js");
                                }
                            }
                        }
                    }
                }
                //Rooms
                foreach (Room room in Rooms.rooms)
                {
                    if (room != null)
                    {
                        string importerPath = GameConfig.path + @"\Codes\Rooms\room" + room.id;
                        if (Directory.Exists(importerPath))
                        {
                            room.onCreate = File.ReadAllText(importerPath + @"\create.js");
                            room.onUpdate = File.ReadAllText(importerPath + @"\update.js");
                            room.onDraw = File.ReadAllText(importerPath + @"\draw.js");
                            room.onKeyPressed = File.ReadAllText(importerPath + @"\keyPressed.js");
                            room.onKeyReleased = File.ReadAllText(importerPath + @"\keyReleased.js");
                        }
                    }
                }
                //Scripts
                foreach (Script script in Scripts.scripts)
                {
                    if (script != null)
                    {
                        string importerPath = GameConfig.path + @"\Codes\Scripts" + @"\script" + script.id + ".js";
                        if (File.Exists(importerPath))
                            script.data = File.ReadAllText(importerPath);
                    }
                }
            }
            catch { }
        }
    }

    //The JSGP data package class
    public class JSGP
    {
        public string name;
        public int projectVersion;
        public string author;
        public string copyright;
        public int gameWidth;
        public int gameHeight;
        public int viewWidth;
        public int viewHeight;
        public string windowStyle;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Sprite[] sprites;
        public int spriteAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Sound[] sounds;
        public int soundAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object[] objects;
        public int objectAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public UI[] UIs;
        public int UIAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Room[] rooms;
        public int roomAmount;
        public int roomFirstId;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Script[] scripts;
        public int scriptAmount;

        //Room Editor Settings
        public int gridWidth;
        public int gridHeight;
        public bool gridEnabled;
    }


    public static class DirectoryExtension
    {
        //Directory copy extension
        public static void Copy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            // Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);
            DirectoryInfo[] dirs = dir.GetDirectories();

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }

            // If the destination directory doesn't exist, create it. 
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }

            // Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, true);
            }

            // If copying subdirectories, copy them and their contents to new location. 
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    Copy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }
    }
}
