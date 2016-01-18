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
using System.IO;
using System.Windows.Forms;
using System.Linq;
namespace JSGameIDE
{
    public static class IDEConfig
    {
        public const int IDEVersion = 4;

        public static List<string> CodeEditors = new List<string>();
        public static int CodeEditorIndex = 0;
        public static List<string> RecentProjectNames = new List<string>();
        public static List<string> RecentProjectPaths = new List<string>();


        public static readonly string ConfigPath = Application.StartupPath + @"\userprefs.ini";

        public static bool IsDefaultEditor
        {
            get
            {
                return CodeEditors[CodeEditorIndex].Equals("Default");
            }
            set { }
        }

        public static void RecentProjectAdd(string name, string path)
        {
            bool found = false;
            foreach (string p in RecentProjectPaths)
            {
                if (p.Equals(path))
                {
                    found = true;
                    break;
                }
            }
            if (!found)
            {
                if (RecentProjectNames.Count < 4)
                {
                    RecentProjectNames.Add("");
                    RecentProjectPaths.Add("");
                }
                try
                {
                    RecentProjectNames[3] = RecentProjectNames[2];
                    RecentProjectPaths[3] = RecentProjectPaths[2];
                }
                catch { }
                try
                {
                    RecentProjectNames[2] = RecentProjectNames[1];
                    RecentProjectPaths[2] = RecentProjectPaths[1];
                }
                catch { }
                try
                {
                    RecentProjectNames[1] = RecentProjectNames[0];
                    RecentProjectPaths[1] = RecentProjectPaths[0];
                }
                catch { }
                RecentProjectNames[0] = name;
                RecentProjectPaths[0] = path;
                Save();
            }
        }

        public static List<string>[] CheckIfRecentProjectsExist(List<string> names, List<string> paths)
        {
            List<string> rNames = names.ToArray().ToList();
            List<string> rPaths = paths.ToArray().ToList();
            for (int i = 0; i < names.Count; i++)
            {
                if (!File.Exists(paths[i]))
                {
                    rPaths.Remove(paths[i]);
                    rNames.Remove(names[i]);
                }
            }
            return new List<string>[] { rNames, rPaths };
        }

        public static void Reset()
        {
            CodeEditors.Clear();
            CodeEditors.Add("Default");
            CodeEditorIndex = 0;
            RecentProjectNames.Clear();
            RecentProjectPaths.Clear();
            if (File.Exists(ConfigPath))
                Load();
            else
                Save();
            List<string>[] result = CheckIfRecentProjectsExist(RecentProjectNames, RecentProjectPaths);
            RecentProjectNames = result[0];
            RecentProjectPaths = result[1];
        }

        public static void Save()
        {
            //General
            string output = "[General]" + Environment.NewLine;
            output += "CodeEditorIndex=" + CodeEditorIndex + Environment.NewLine;
            //Code Editor
            output += "[CodeEditor]" + Environment.NewLine;
            for(int i=0; i<CodeEditors.Count; i++)
                output += i + "=" + CodeEditors[i] + Environment.NewLine;
            //Recent Name
            output += "[RecentName]" + Environment.NewLine;
            for (int i = 0; i < RecentProjectNames.Count; i++)
                output += i + "=" + RecentProjectNames[i] + Environment.NewLine;
            //Recent Path
            output += "[RecentPath]" + Environment.NewLine;
            for (int i = 0; i < RecentProjectPaths.Count; i++)
                output += i + "=" + RecentProjectPaths[i] + Environment.NewLine;

            using (StreamWriter w = new StreamWriter(ConfigPath))
            {
                w.Write(output);
            }
        }
        public static void Load()
        {
            string[] input = File.ReadAllLines(ConfigPath);
            string group = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (input[i].IndexOfAny(new char[] { '[', ']' }) != -1)
                    group = input[i].Replace("[", "").Replace("]", "").Trim();
                else
                {
                    string[] keyPair = input[i].Split('=');
                    switch (group)
                    {
                        case "General":
                            switch (keyPair[0])
                            {
                                case "CodeEditorIndex":
                                    CodeEditorIndex = int.Parse(keyPair[1]);
                                    break;
                            }
                            break;
                        case "CodeEditor":
                            if (!keyPair[1].Equals("Default"))
                                CodeEditors.Add(keyPair[1]);
                            break;
                        case "RecentName":
                            RecentProjectNames.Add(keyPair[1]);
                            break;
                        case "RecentPath":
                            RecentProjectPaths.Add(keyPair[1]);
                            break;
                    }
                }
            }
        }
    }
}
