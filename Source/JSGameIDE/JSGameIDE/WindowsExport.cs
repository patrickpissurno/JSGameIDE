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
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    public static class WindowsExport
    {
        public static string Path = null;
        public static void Find()
        {
            if (Path == null)
            {
                string path = @"C:\Windows\Microsoft.NET\Framework";
                string[] dirs = Directory.GetDirectories(path);
                path = null;
                foreach (string dir in dirs)
                {
                    if (dir.IndexOf("v4") != -1)
                    {
                        path = dir;
                        break;
                    }
                }
                if (path != null)
                {
                    path += @"\msbuild.exe";
                    if (File.Exists(path))
                        Path = path;
                }
                else
                    MessageBox.Show("Can't find MSBuild");
            }
        }
        public static void Build()
        {
            try
            {
                Find();
                if (Path != null)
                {
                    if (Builder.Build(true, GameConfig.path + @"\Build\Win\Resources"))
                    {
                        string SDKPath = Application.StartupPath + @"\SDK";

                        //Meta information
                        string temp = File.ReadAllText(SDKPath + @"\JSGameIDE-Player\Properties\AssemblyInfo.cs");
                        temp = MetaInfoChanger(temp, "[assembly: AssemblyTitle(\"", "\")]", GameConfig.name);
                        temp = MetaInfoChanger(temp, "[assembly: AssemblyDescription(\"", "\")]", GameConfig.name);
                        temp = MetaInfoChanger(temp, "[assembly: AssemblyProduct(\"", "\")]", GameConfig.name);
                        temp = MetaInfoChanger(temp, "[assembly: AssemblyCompany(\"", "\")]", GameConfig.author);
                        temp = MetaInfoChanger(temp, "[assembly: AssemblyCopyright(\"", "\")]", GameConfig.copyright);

                        //Copy the icon
                        try
                        {
                            File.Copy(GameConfig.path + @"\Resources\icon.ico", SDKPath + @"\JSGameIDE-Player\icon.ico", true);
                        }
                        catch { }

                        using (StreamWriter w = new StreamWriter(SDKPath + @"\JSGameIDE-Player\Properties\AssemblyInfo.cs"))
                        {
                            w.Write(temp);
                        }

                        System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                        info.FileName = Path;
                        info.Arguments = @"/p:Platform=x86 JSGameIDE-Player.sln";
                        info.WorkingDirectory = SDKPath;
                        info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                        System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
                        process.WaitForExit();
                        DirectoryExtension.Copy(SDKPath + @"\JSGameIDE-Player\bin\x86\Debug", GameConfig.path + @"\Build\Win", true);

                        //Cleans some trash
                        File.Delete(GameConfig.path + @"\Build\Win\JSGameIDE-Player.exe.config");
                        File.Delete(GameConfig.path + @"\Build\Win\JSGameIDE-Player.pdb");
                        File.Delete(GameConfig.path + @"\Build\Win\CefSharp.Core.xml");
                        File.Delete(GameConfig.path + @"\Build\Win\CefSharp.WinForms.xml");
                        File.Delete(GameConfig.path + @"\Build\Win\CefSharp.xml");
                        File.Delete(GameConfig.path + @"\Build\Win\devtools_resources.pak");
                        try
                        {
                            File.Move(GameConfig.path + @"\Build\Win\JSGameIDE-Player.exe", GameConfig.path + @"\Build\Win\" + GameConfig.name.Replace(' ', '-') + ".exe");
                        }
                        catch { }
                        Directory.Delete(SDKPath + @"\JSGameIDE-Player\bin\x86", true);
                        MessageBox.Show("Built");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Build failure. Please ensure the SDK is properly installed.");
            }
        }

        public static string MetaInfoChanger(string text, string start, string end, string value)
        {
            int startPos = text.IndexOf(start);
            return text.Replace(text.Substring(startPos, text.IndexOf(end, startPos) + end.Length - startPos), start + value + end);
        }
    }
}
