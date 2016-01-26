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

using System.IO;
using System.Media;
using System.Threading;
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
            Find();
            if (!string.IsNullOrWhiteSpace(Path) && File.Exists(Path))
            {
                using (LoadingForm buildForm = new LoadingForm("Build in progress: ", "%"))
                {
                    Thread buildThread = new Thread(() =>
                    {
                        int steps = 10;
                        try
                        {
                            Directory.Delete(GameConfig.path + @"\Build\Win", true);
                        }
                        catch { }
                        LoadingForm.ProgressStep(steps, buildForm);
                        if (Builder.Build(true, GameConfig.path + @"\Build\Win\Resources"))
                        {
                            try
                            {
                                LoadingForm.ProgressStep(steps, buildForm);
                                string SDKPath = Application.StartupPath + @"\SDK";

                                //Meta information
                                string temp = File.ReadAllText(SDKPath + @"\JSGameIDE-Player\Properties\AssemblyInfo.cs");
                                temp = MetaInfoChanger(temp, "[assembly: AssemblyTitle(\"", "\")]", GameConfig.name);
                                temp = MetaInfoChanger(temp, "[assembly: AssemblyDescription(\"", "\")]", GameConfig.name);
                                temp = MetaInfoChanger(temp, "[assembly: AssemblyProduct(\"", "\")]", GameConfig.name);
                                temp = MetaInfoChanger(temp, "[assembly: AssemblyCompany(\"", "\")]", GameConfig.author);
                                temp = MetaInfoChanger(temp, "[assembly: AssemblyCopyright(\"", "\")]", GameConfig.copyright);
                                LoadingForm.ProgressStep(steps, buildForm);

                                //Copy the icon
                                try
                                {
                                    File.Copy(GameConfig.path + @"\Resources\icon.ico", SDKPath + @"\JSGameIDE-Player\icon.ico", true);
                                }
                                catch { }
                                LoadingForm.ProgressStep(steps, buildForm);
                                using (StreamWriter w = new StreamWriter(SDKPath + @"\JSGameIDE-Player\Properties\AssemblyInfo.cs"))
                                {
                                    w.Write(temp);
                                }
                                LoadingForm.ProgressStep(steps, buildForm);

                                System.Diagnostics.ProcessStartInfo info = new System.Diagnostics.ProcessStartInfo();
                                info.FileName = Path;
                                info.Arguments = @"/p:Platform=x86 JSGameIDE-Player.sln";
                                info.WorkingDirectory = SDKPath;
                                info.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
                                System.Diagnostics.Process process = System.Diagnostics.Process.Start(info);
                                process.WaitForExit();
                                LoadingForm.ProgressStep(steps, buildForm);
                                DirectoryExtension.Copy(SDKPath + @"\JSGameIDE-Player\bin\x86\Debug", GameConfig.path + @"\Build\Win", true);
                                LoadingForm.ProgressStep(steps, buildForm);

                                //Cleans some trash
                                File.Delete(GameConfig.path + @"\Build\Win\JSGameIDE-Player.exe.config");
                                File.Delete(GameConfig.path + @"\Build\Win\JSGameIDE-Player.pdb");
                                File.Delete(GameConfig.path + @"\Build\Win\CefSharp.Core.xml");
                                File.Delete(GameConfig.path + @"\Build\Win\CefSharp.WinForms.xml");
                                File.Delete(GameConfig.path + @"\Build\Win\CefSharp.xml");
                                File.Delete(GameConfig.path + @"\Build\Win\devtools_resources.pak");
                                LoadingForm.ProgressStep(steps, buildForm);
                                try
                                {
                                    File.Move(GameConfig.path + @"\Build\Win\JSGameIDE-Player.exe", GameConfig.path + @"\Build\Win\" + GameConfig.name.Replace(' ', '-') + ".exe");
                                }
                                catch { }
                                LoadingForm.ProgressStep(steps, buildForm);
                                Directory.Delete(SDKPath + @"\JSGameIDE-Player\bin\x86", true);
                                LoadingForm.ProgressStep(steps, buildForm);

                                Thread.Sleep(200);

                                buildForm.SafeClose();
                                SystemSounds.Beep.Play();
                                MessageBox.Show("Build success", "Windows Builder", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            catch
                            {
                                buildForm.SafeClose();
                                SystemSounds.Exclamation.Play();
                                MessageBox.Show("Build failure", "Windows Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                        else
                        {
                            buildForm.SafeClose();
                            SystemSounds.Exclamation.Play();
                            MessageBox.Show("Build failure", "Windows Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    });
                    buildThread.Start();
                    buildForm.ShowDialog();
                }
            }
            else
            {
                SystemSounds.Asterisk.Play();
                MessageBox.Show("Build failure. Please ensure that the SDK is properly installed.", "Windows Builder", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static string MetaInfoChanger(string text, string start, string end, string value)
        {
            int startPos = text.IndexOf(start);
            return text.Replace(text.Substring(startPos, text.IndexOf(end, startPos) + end.Length - startPos), start + value + end);
        }
    }
}
