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
    public static class UIs
    {
        //UIs data
        public static int amount = 0;
        public static List<UI> uis = new List<UI>();

        /// <summary>
        /// Changes the name of a given UI
        /// </summary>
        /// <param name="id">The id of the UI</param>
        /// <param name="name">The new name</param>
        public static void SetName(int id, string name)
        {
            if (uis[id] != null)
            {
                uis[id].name = name;
                uis[id].node.Text = name;
            }
        }

        /// <summary>
        /// Deletes all the UIs and resets any data
        /// </summary>
        public static void Reset()
        {
            foreach (UI ui in uis)
            {
                if(ui!=null)
                    ui.node.Remove();
            }
            amount = 0;
            uis.Clear();
        }

        /// <summary>
        /// Permanently deletes the UI from the project
        /// </summary>
        /// <param name="id">The index of the UI to be removed</param>
        public static void Delete(int id)
        {
            //Deletes all the files related to the UI
            try
            {
                string _dir = GameConfig.path + @"\Codes\UIs\ui" + id;
                if (Directory.Exists(_dir))
                    Directory.Delete(_dir, true);
            }
            catch { }
            uis[id] = null;
        }
    }

    public class UI : IDEComponent
    {
        public enum UIAlignment
        {
            TOP_CENTER = 0,
            TOP_LEFT = 1,
            TOP_RIGHT = 2,
            CENTER_LEFT = 3,
            CENTER_CENTER = 4,
            CENTER_RIGHT = 5,
            BOT_LEFT = 6,
            BOT_CENTER = 7,
            BOT_RIGHT = 8,
            STRETCH_ALL = 9,
            STRETCH_HORIZONTAL = 10,
            STRETCH_VERTICAL = 11,
            FILL = 12
        }

        public int id;
        public string name;
        public int x = 0;
        public int y = 0;
        public int width = 500;
        public int height = 300;
        public bool movable = false;
        public UIAlignment align = UIAlignment.TOP_LEFT;

        [JsonIgnore]
        public TreeNode node;

        //UI Data
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
        public string onDestroy = "";
        public UIComponent[] components = null;

        /// <summary>
        /// Creates a new game UI
        /// </summary>
        /// <param name="name">The name of the new UI</param>
        /// <param name="form">A reference to the main form of the application</param>
        public UI(string name=null, MainForm form=null)
        {
            this.Type = ComponentType.UI;
            if (name != null && form != null)
            {
                this.id = UIs.amount;
                UIs.amount++;
                this.name = name + "" + this.id;
                this.node = new TreeNode(this.name);
                this.node.Name = "" + this.id;
                form.AddViewNodeChild("UIs", this.node);
            }
        }
    }

    public class UIComponent
    {
        public int id;
        public int x;
        public int y;

        [JsonIgnore]
        public string data;
        public UIComponent(int x = 0, int y = 0, int id = -1, string data = "")
        {
            this.x = x;
            this.y = y;
            this.id = id;
            this.data = data;
        }

        public UIComponent()
        {
            this.x = 0;
            this.y = 0;
            this.id = -1;
            this.data = "";
        }
    }
}
