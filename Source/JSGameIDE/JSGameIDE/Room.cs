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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.IO;

namespace JSGameIDE
{
    public static class Rooms
    {
        //Rooms data
        public static int amount = 0;
        public static List<Room> rooms = new List<Room>();
        public static int firstId = 0;

        /// <summary>
        /// Changes the name of a given room
        /// </summary>
        /// <param name="id">The id of the room</param>
        /// <param name="name">The new name</param>
        public static void SetName(int id, string name)
        {
            if (rooms[id] != null)
            {
                rooms[id].name = name;
                rooms[id].node.Text = name;
            }
        }

        /// <summary>
        /// Deletes all the rooms and resets any data
        /// </summary>
        public static void Reset()
        {
            foreach (Room room in rooms)
            {
                if(room!=null)
                    room.node.Remove();
            }
            amount = 0;
            rooms = new List<Room>();
            firstId = 0;
        }

        /// <summary>
        /// Permanently deletes the room from the project
        /// </summary>
        /// <param name="id">The index of the room to be removed</param>
        public static void Delete(int id)
        {
            //Deletes all the files related to the room
            try
            {
                string _dir = GameConfig.path + @"\Codes\Rooms\room" + id;
                if (Directory.Exists(_dir))
                    Directory.Delete(_dir, true);
            }
            catch { }
            rooms[id] = null;
        }
    }

    public class Room : IDEComponent
    {
        public int id;
        public string name;
        public decimal gravityX = 0;
        public decimal gravityY = 9.8M;
        public bool allowSleep = false;

        [JsonIgnore]
        public TreeNode node;

        //Room Data
        [JsonIgnore]
        public string onCreate = "";
        [JsonIgnore]
        public string onUpdate = "";
        [JsonIgnore]
        public string onDraw = "";
        [JsonIgnore]
        public string onKeyPressed = "";
        [JsonIgnore]
        public string onKeyReleased = "";
        public EditorObject[] editorCreate = null;

        /// <summary>
        /// Creates a new game room
        /// </summary>
        /// <param name="name">The name of the new room</param>
        /// <param name="form">A reference to the main form of the application</param>
        public Room(string name=null, MainForm form=null)
        {
            this.Type = ComponentType.Room;
            if (name != null && form != null)
            {
                this.id = Rooms.amount;
                Rooms.amount++;
                this.name = name + "" + this.id;
                this.node = new TreeNode(this.name);
                this.node.Name = "" + this.id;
                form.AddViewNodeChild("Rooms", this.node);
            }
        }
    }
}
