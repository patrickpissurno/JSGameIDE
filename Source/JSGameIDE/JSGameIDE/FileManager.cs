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
                    mainForm.SetTitle(GameConfig.name + "*");
                else
                    mainForm.SetTitle(GameConfig.name);
                unsavedChanges = value;
            }
        }

        /// <summary>
        /// Saves the current project
        /// </summary>
        /// <param name="quiet">Whether the quiet mode is on or off</param>
        public static void Save(bool quiet = false)
        {
            try
            {
                JSGP package = new JSGP();
                package.name = GameConfig.name;
                package.gameWidth = GameConfig.width;
                package.gameHeight = GameConfig.height;
                package.viewWidth = GameConfig.viewWidth;
                package.viewHeight = GameConfig.viewHeight;
                package.rooms = Rooms.rooms.ToArray();
                package.roomAmount = Rooms.amount;
                package.roomFirstId = Rooms.firstId;
                package.sprites = Sprites.sprites.ToArray();
                package.spriteAmount = Sprites.amount;
                package.objects = Objects.objects.ToArray();
                package.objectAmount = Objects.amount;
                string output = JsonConvert.SerializeObject(package);
                using (StreamWriter outfile = new StreamWriter(GameConfig.path + @"\project.JSGP"))
                {
                    outfile.Write(output);
                }
                if (!quiet)
                {
                    MessageBox.Show("Project saved successfully.");
                    FileManager.UnsavedChanges = false;
                }
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
        public static void Load(string path,bool quiet = false)
        {
            bool run;
            if(!quiet)
                run = MessageBox.Show("Are you sure? (Any unsaved data will be lost)", "JSGameIDE", MessageBoxButtons.YesNo) == DialogResult.Yes;
            else
                run=true;
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
                    JSGP output = JsonConvert.DeserializeObject<JSGP>(input);
                    var output2 = JsonConvert.DeserializeObject<dynamic>(input);
                    //Updates all the project data
                    GameConfig.name = output.name;
                    GameConfig.path = Path.GetDirectoryName(path);
                    GameConfig.width = (int)output2.gameWidth;
                    GameConfig.height = (int)output2.gameHeight;
                    GameConfig.viewWidth = (int)output2.viewWidth;
                    GameConfig.viewHeight = (int)output2.viewHeight;
                    var sprs = ((JArray)output2.sprites).ToObject<List<dynamic>>();
                    var objs = ((JArray)output2.objects).ToObject<List<dynamic>>();
                    var rms = ((JArray)output2.rooms).ToObject<List<dynamic>>();
                    Sprites.sprites = output.sprites.ToList<Sprite>();
                    Sprites.amount = output.spriteAmount;
                    Objects.objects = output.objects.ToList<Object>();
                    Objects.amount = output.objectAmount;
                    Rooms.rooms = output.rooms.ToList<Room>();
                    Rooms.firstId = output.roomFirstId;
                    Rooms.amount = output.roomAmount;

                    //Loads all the sprites
                    foreach (Sprite spr in Sprites.sprites)
                    {
                        if (spr != null)
                        {
                            spr.name = (string)sprs[spr.id].name;
                            spr.path = (string)sprs[spr.id].path;
                            TreeNode _node = new TreeNode(spr.name);
                            _node.Name = "" + spr.id;
                            spr.node = _node;
                            mainForm.AddViewNodeChild("Sprites", _node);
                        }
                    }

                    //Loads all the rooms
                    foreach (Room room in Rooms.rooms)
                    {
                        if (room != null)
                        {
                            room.name = (string)rms[room.id].name;
                            TreeNode _node = new TreeNode(room.name);
                            _node.Name = "" + room.id;
                            room.node = _node;
                            mainForm.AddViewNodeChild("Rooms", _node);
                        }
                    }

                    //Loads all the objects
                    foreach (Object obj in Objects.objects)
                    {
                        if (obj != null)
                        {
                            obj.name = (string)objs[obj.id].name;
                            TreeNode _node = new TreeNode(obj.name);
                            _node.Name = "" + obj.id;
                            obj.node = _node;
                            mainForm.AddViewNodeChild("Objects", _node);
                        }
                    }
                    //Sets the title of the Main Form with the project title
                    mainForm.SetTitle(GameConfig.name);
                    //MessageBox.Show("Project opened successfully.");
                    FileManager.UnsavedChanges = false;
                }
                catch
                {
                    MessageBox.Show("Can't open the file.");
                }
            }
        }
    }

    //The JSGP data package class
    public class JSGP
    {
        public string name;
        public int gameWidth;
        public int gameHeight;
        public int viewWidth;
        public int viewHeight;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Sprite[] sprites;
        public int spriteAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Object[] objects;
        public int objectAmount;
        [JsonProperty(NullValueHandling = NullValueHandling.Ignore)]
        public Room[] rooms;
        public int roomAmount;
        public int roomFirstId;
    }
}
