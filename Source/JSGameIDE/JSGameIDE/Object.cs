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
    public static class Objects
    {
        //Objects data
        public static int amount = 0;
        public static List<Object> objects = new List<Object>();

        /// <summary>
        /// Changes the name of a given object
        /// </summary>
        /// <param name="id">The id of the object</param>
        /// <param name="name">The new name</param>
        public static void SetName(int id, string name)
        {
            if (objects[id] != null)
            {
                objects[id].name = name;
                objects[id].node.Text = name;
            }
        }

        /// <summary>
        /// Deletes all the objects and resets any data
        /// </summary>
        public static void Reset()
        {
            foreach (Object obj in objects)
            {
                if(obj!=null)
                    obj.node.Remove();
            }
            amount = 0;
            objects = new List<Object>();
        }

        /// <summary>
        /// Returns the id of a given object
        /// </summary>
        /// <param name="str">The name of the object</param>
        /// <returns>The id of the object as an integer. If it doesn't exists, returns -1</returns>
        public static int GetIdByName(string str)
        {
            foreach (Object obj in objects)
            {
                if (obj != null)
                {
                    if (obj.name == str)
                        return obj.id;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the name of a given object
        /// </summary>
        /// <param name="_id">The id of the object</param>
        /// <returns>A string containing its name. If it doesn't exist, returns "None"</returns>
        public static string GetNameById(int _id)
        {
            if (_id == -1)
                return "None";
            else
            {
                if (objects[_id] == null)
                    return "None";
                else
                    return objects[_id].name;
            }
        }

        /// <summary>
        /// Permanently deletes the object from the project
        /// </summary>
        /// <param name="id">The index of the object to be removed</param>
        public static void Delete(int id)
        {
            //Removes the object from the Room Editor in each room
            foreach (Room room in Rooms.rooms)
            {
                if (room != null)
                {
                    List<EditorObject> objs = room.editorCreate.ToList();
                    foreach (EditorObject o in room.editorCreate)
                    {
                        if (o != null)
                        {
                            if (o.id == id)
                                objs.Remove(o);
                        }
                    }
                    room.editorCreate = objs.ToArray();
                }
            }

            //Deletes all the files related to the object
            try
            {
                string _dir = GameConfig.path + @"\Codes\Objects\obj" + id;
                if (Directory.Exists(_dir))
                    Directory.Delete(_dir, true);
            }
            catch { }
            objects[id] = null;
        }
    }
    
    public class Object : IDEComponent
    {
        public int id;
        public string name;
        public int sprite = -1;
        public bool autoDraw = true;

        //Physics
        public bool usePhysics = false;
        public bool lockRotation = false;
        public Physics.BodyTypes bodyType = Physics.BodyTypes.Static;
        public Physics.ColliderTypes colliderType = Physics.ColliderTypes.Box;
        public decimal density = 1.0M;
        public decimal friction = 0.5M;
        public decimal restitution = 0.5M;

        [JsonIgnore]
        public TreeNode node;

        //Object Data
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
        [JsonIgnore]
        public string onMousePressed = "";
        [JsonIgnore]
        public string onMouseReleased = "";
        [JsonIgnore]
        public string onDestroy = "";
        [JsonIgnore]
        public string onCollisionEnter = "";
        [JsonIgnore]
        public string onCollisionExit = "";

        /// <summary>
        /// Creates a new game object
        /// </summary>
        /// <param name="name">The name of the new object</param>
        /// <param name="form">A reference to the main form of the application</param>
        public Object(string name=null, MainForm form=null)
        {
            this.Type = ComponentType.Object;
            if (name != null && form != null)
            {
                this.id = Objects.amount;
                Objects.amount++;
                this.name = name + "" + this.id;
                this.node = new TreeNode(this.name);
                this.node.Name = "" + this.id;
                form.AddViewNodeChild("Objects", this.node);
            }
        }
    }
    public class EditorObject
    {
        public float x;
        public float y;
        public int id;
        [JsonIgnore]
        public PictureBox pic;
        /// <summary>
        /// Creates a Room Editor Object instance.
        /// </summary>
        /// <param name="_x">X position in room.</param>
        /// <param name="_y">Y position in room.</param>
        /// <param name="_id">The id of the Object.</param>
        /// <param name="_pic">The PictureBox of the Object.</param>
        public EditorObject(float _x=0, float _y=0, int _id=-1, PictureBox _pic = null)
        {
            this.x = _x;
            this.y = _y;
            this.id = _id;
            this.pic = _pic;
        }
    }
}
