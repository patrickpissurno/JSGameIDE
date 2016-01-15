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
    public static class Sounds
    {
        //Sounds data
        public static int amount = 0;
        public static List<Sound> sounds = new List<Sound>();

        /// <summary>
        /// Changes the name of a given audio
        /// </summary>
        /// <param name="id">The id of the audio</param>
        /// <param name="name">The new name</param>
        public static void SetName(int id, string name)
        {
            if (sounds[id] != null)
            {
                sounds[id].name = name;
                sounds[id].node.Text = name;
            }
        }

        /// <summary>
        /// Changes the path of a given sound
        /// </summary>
        /// <param name="id">The id of the sound</param>
        /// <param name="path">The new path</param>
        public static void SetPath(int id, string path)
        {
            if (sounds[id] != null)
            {
                sounds[id].path = path;
            }
        }

        /// <summary>
        /// Returns the id of a given sound
        /// </summary>
        /// <param name="str">The name of the sound</param>
        /// <returns>The id of the sound as an integer. If it doesn't exists, returns -1</returns>
        public static int GetIdByName(string str)
        {
            foreach (Sound snd in sounds)
            {
                if (snd != null)
                {
                    if (snd.name == str)
                        return snd.id;
                }
            }
            return -1;
        }

        /// <summary>
        /// Returns the name of a given sound
        /// </summary>
        /// <param name="_id">The id of the sound</param>
        /// <returns>A string containing the its name. If it doesn't exist, returns "None"</returns>
        public static string GetNameById(int _id)
        {
            if (_id == -1)
                return "None";
            else
            {
                if (sounds[_id] == null)
                    return "None";
                else
                    return sounds[_id].name;
            }
        }

        /// <summary>
        /// Deletes all the sounds and resets any data
        /// </summary>
        public static void Reset()
        {
            foreach (Sound sound in sounds)
            {
                if(sound != null)
                    sound.node.Remove();
            }
            amount = 0;
            sounds = new List<Sound>();
        }

        /// <summary>
        /// Permanently deletes the sound from the project
        /// </summary>
        /// <param name="id">The index of the sound to be removed</param>
        public static void Delete(int id)
        {
            //Deletes the sound file
            try
            {
                string _dir = GameConfig.path + @"\" + sounds[id].path;
                if(File.Exists(_dir))
                    File.Delete(_dir);
            }
            catch { }
            sounds[id] = null;
        }
    }
    public class Sound : IDEComponent
    {
        //Sprite Data
        public string path;
        public int id;
        public string name;
        [JsonIgnore]
        public TreeNode node;

        /// <summary>
        /// Creates a new game sound
        /// </summary>
        /// <param name="path">The path of the new sound</param>
        /// <param name="name">The name of the new sound</param>
        /// <param name="form">A reference to the main form of the application</param>
        public Sound(string path=null, string name=null, MainForm form=null)
        {
            this.Type = ComponentType.Sound;
            if (path != null && name != null && form != null)
            {
                this.path = path;
                this.id = Sounds.amount;
                Sounds.amount++;
                this.name = name + "" + this.id;
                this.node = new TreeNode(this.name);
                this.node.Name = "" + this.id;
                form.AddViewNodeChild("Sounds", this.node);
            }
        }
    }
}
