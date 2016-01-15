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
    //User-defined functions data
    public static class Scripts
    {
        public static List<Script> scripts = new List<Script>();
        public static int amount = 0;

        /// <summary>
        /// Deletes all the user-defined functions and resets any data
        /// </summary>
        public static void Reset()
        {
            foreach (Script scr in scripts)
            {
                if (scr != null)
                    scr.node.Remove();
            }
            amount = 0;
            scripts = new List<Script>();
        }

        /// <summary>
        /// Changes the name of a given script
        /// </summary>
        /// <param name="id">The id of the script</param>
        /// <param name="name">The new name</param>
        public static void SetName(int id, string name)
        {
            if (scripts[id] != null)
            {
                scripts[id].name = name;
                scripts[id].node.Text = name;
            }
        }

        /// <summary>
        /// Permanently deletes the script from the project
        /// </summary>
        /// <param name="id">The index of the script to be removed</param>
        public static void Delete(int id)
        {

            //Deletes all the files related to the script
            try
            {
                string _dir = GameConfig.path + @"\Codes\Scripts\script" + id + ".js";
                if (File.Exists(_dir))
                    File.Delete(_dir);
            }
            catch { }
            scripts[id] = null;
        }
    }

    public class Script : IDEComponent
    {
        public int id;
        public string name;
        [JsonIgnore]
        public string data = "";
        [JsonIgnore]
        public TreeNode node;
        /// <summary>
        /// Creates a new script
        /// </summary>
        /// <param name="name">The name of the new script</param>
        /// <param name="form">A reference to the main form of the application</param>
        public Script(string name = null, MainForm form=null)
        {
            this.Type = ComponentType.Script;
            if (name != null && form != null)
            {
                this.id = Scripts.amount;
                Scripts.amount++;
                this.name = name + "" + this.id;
                this.node = new TreeNode(this.name);
                this.node.Name = "" + this.id;

                //Generates the default code
                this.data = "function " + this.name + "()" + Environment.NewLine;
                this.data += "{" + Environment.NewLine;
                this.data += "}";

                form.AddViewNodeChild("Scripts", this.node);
            }
        }
    }
}
