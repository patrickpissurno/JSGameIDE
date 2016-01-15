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
    public static class Sprites
    {
        //Sprites data
        public static int amount = 0;
        public static List<Sprite> sprites = new List<Sprite>();

        /// <summary>
        /// Changes the name of a given sprite
        /// </summary>
        /// <param name="id">The id of the sprite</param>
        /// <param name="name">The new name</param>
        public static void SetName(int id, string name)
        {
            if (sprites[id] != null)
            {
                sprites[id].name = name;
                sprites[id].node.Text = name;
            }
        }

        /// <summary>
        /// Changes the path of a given sprite
        /// </summary>
        /// <param name="id">The id of the sprite</param>
        /// <param name="path">The new path</param>
        public static void SetPath(int id, string[] path)
        {
            if (sprites[id] != null)
            {
                sprites[id].path = path;
            }
        }

        /// <summary>
        /// Returns the id of a given sprite
        /// </summary>
        /// <param name="str">The name of the sprite</param>
        /// <returns>The id of the sprite as an integer. If it doesn't exists, returns -1</returns>
        public static int GetIdByName(string str)
        {
            foreach (Sprite spr in sprites)
            {
                if (spr != null)
                {
                    if (spr.name == str)
                        return spr.id;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the name of a given sprite
        /// </summary>
        /// <param name="_id">The id of the sprite</param>
        /// <returns>A string containing the its name. If it doesn't exist, returns "None"</returns>
        public static string GetNameById(int _id)
        {
            if (_id == -1)
                return "None";
            else
            {
                if (sprites[_id] == null)
                    return "None";
                else
                    return sprites[_id].name;
            }
        }

        /// <summary>
        /// Deletes all the sprites and resets any data
        /// </summary>
        public static void Reset()
        {
            foreach (Sprite sprite in sprites)
            {
                if(sprite!=null)
                    sprite.node.Remove();
            }
            amount = 0;
            sprites = new List<Sprite>();
        }

        /// <summary>
        /// Permanently deletes the sprite from the project
        /// </summary>
        /// <param name="id">The index of the sprite to be removed</param>
        public static void Delete(int id)
        {
            //Removes the sprite from every object
            foreach (Object obj in Objects.objects)
            {
                if (obj != null)
                {
                    if (obj.sprite == id)
                        obj.sprite = -1;
                }
            }

            //Deletes all the files related to the object
            try
            {
                string _dir = GameConfig.path + @"\Resources\IMG\spr" + id;
                if (Directory.Exists(_dir))
                    Directory.Delete(_dir, true);
            }
            catch { }
            sprites[id] = null;
        }
    }
    public class Sprite
    {
        //Sprite Data
        public string[] path;
        public int id;
        public string name;
        [JsonIgnore]
        public TreeNode node;

        /// <summary>
        /// Creates a new game sprite
        /// </summary>
        /// <param name="path">The path of the new sprite</param>
        /// <param name="name">The name of the new sprite</param>
        /// <param name="form">A reference to the main form of the application</param>
        public Sprite(string[] path=null,string name=null,MainForm form=null)
        {
            if (path != null && name != null && form != null)
            {
                this.path = path;
                this.id = Sprites.amount;
                Sprites.amount++;
                this.name = name + "" + this.id;
                this.node = new TreeNode(this.name);
                this.node.Name = "" + this.id;
                form.AddViewNodeChild("Sprites", this.node);
            }
        }
    }
}
