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

using System.Collections.Generic;
namespace JSGameIDE
{
    public static class IDEConfig
    {
        public const int IDEVersion = 1;
        public static List<string> CodeEditors = new List<string>();
        public static int CodeEditorIndex = 0;
        public static bool IsDefaultEditor
        {
            get
            {
                return CodeEditors[CodeEditorIndex].Equals("Default");
            }
            set { }
        }

        public static void Reset()
        {
            CodeEditors.Clear();
            CodeEditors.Add("Default");
            CodeEditorIndex = 0;
        }
        public enum ComponentType
        {
            Object,
            Room,
            Script,
            Sprite
        }
    }
}
