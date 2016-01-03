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

namespace JSGameIDE
{
    public static class GameConfig
    {
        //Game Configuration data
        public static string name = "";
        public static string path = "";
        public static int width = 800;
        public static int height = 600;
        public static int viewWidth = 800;
        public static int viewHeight = 600;
        public static bool obfuscate = true;
        public static int projectVersion = IDEConfig.IDEVersion;

        //Meta Information data
        public static string author = "Made with JSGameIDE";
        public static string copyright = "Copyright © 2016";

        //Room Editor Preferences
        public static int gridWidth = 32;
        public static int gridHeight = 32;
        public static bool gridEnabled = false;


        /// <summary>
        /// Resets all the data of the game
        /// </summary>
        public static void Reset()
        {
            name = "";
            path = "";
            width = 800;
            height = 600;
            viewWidth = 800;
            viewHeight = 600;
            gridEnabled = false;
            gridWidth = 32;
            gridHeight = 32;
            projectVersion = IDEConfig.IDEVersion;
            Sprites.Reset();
            Rooms.Reset();
            Objects.Reset();
            Scripts.Reset();
        }
    }
}
