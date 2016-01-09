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
using CefSharp;
using CefSharp.WinForms;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Threading;

namespace JSGameIDE
{
    public static class LivePreview
    {
        public static ChromiumWebBrowser Browser;
        public static readonly string BuildPath = Application.StartupPath + @"\Temp\LivePreview";
        public static readonly string PlaceholderPath = Application.StartupPath + @"\Resources\livePreview.html";
        private static MainForm mainForm;
        public static bool ConsoleOpen = false;
        public static ChromiumWebBrowser DebugBrowser;
        private static Control DebugDock;
        private static TableLayoutPanel MainDock;
        private const int RPORT = 8698;

        public static void Init(MainForm form, Control dock, Control debugDock, TableLayoutPanel mainDock)
        {
            mainForm = form;
            CefSettings settings = new CefSettings { RemoteDebuggingPort = RPORT };
            Cef.Initialize(settings);

            Browser = new ChromiumWebBrowser(PlaceholderPath);
            dock.Controls.Add(Browser);
            Browser.Dock = DockStyle.Fill;
            Browser.BrowserSettings.BackgroundColor = ColorExt.ToUint(Color.FromArgb(255,71,72,75));
            Browser.LoadingStateChanged += Browser_LoadingStateChanged;

            DebugBrowser = new ChromiumWebBrowser("http://localhost:" + RPORT);
            DebugBrowser.LoadingStateChanged += DebugBrowser_LoadingStateChanged;
            debugDock.Controls.Add(DebugBrowser);
            DebugBrowser.Dock = DockStyle.Fill;
            DebugDock = debugDock;
            MainDock = mainDock;
        }

        static void DebugBrowser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading && DebugBrowser.Address.IndexOf(":" + RPORT) != -1)
            {
                string str = "var a = document.getElementsByTagName('A'); for(var i=0; i<a.length; i++){if(a[i].title=='" + GameConfig.name + "'){location.href=a[i].href;}}";
                DebugBrowser.EvaluateScriptAsync(str);
                //Thread t = new Thread(() => { Thread.Sleep(100); DebugBrowser.EvaluateScriptAsync(str); });
                //t.IsBackground = true;
                //t.Start();
            }
        }

        public static void ShowDebug(bool bl)
        {
            if (DebugDock.InvokeRequired)
            {
                DebugDock.Invoke(new MethodInvoker(() => { ShowDebug(bl); }));
            }
            else
            {
                if (bl)
                {
                    DebugDock.Show();
                    MainDock.RowStyles[0] = new RowStyle(SizeType.Percent, .75f);
                    MainDock.RowStyles[1] = new RowStyle(SizeType.Percent, .25f);
                }
                else
                {
                    DebugDock.Hide();
                    MainDock.RowStyles[0] = new RowStyle(SizeType.Percent, 1f);
                    MainDock.RowStyles[1] = new RowStyle(SizeType.Percent, 0f);
                }
            }
        }

        static void Browser_LoadingStateChanged(object sender, LoadingStateChangedEventArgs e)
        {
            if (!e.IsLoading && Browser.Address.Replace("file:///", "").Replace('/', '\\').Equals(PlaceholderPath))
            {
                Reload();
            }
        }
        public static void Reload()
        {
            if(FileManager.ProjectLoaded)
            {
                //Cleans the temporary files from previous build
                string dir = Path.GetDirectoryName(BuildPath);
                try
                {
                    if(Directory.Exists(dir))
                        Directory.Delete(dir, true);
                }
                catch { }
                Directory.CreateDirectory(dir);

                //Build the Preview
                if (Builder.Build(true, BuildPath))
                {
                    //Loads the page
                    if (File.Exists(BuildPath + @"\index.html"))
                        Browser.Load(BuildPath + @"\index.html");
                    else
                        Browser.Load(PlaceholderPath);
                }
                else
                    Browser.Load(PlaceholderPath);
            }
        }

        public static void Shutdown()
        {
            try
            {
                Directory.Delete(Path.GetDirectoryName(BuildPath), true);
            }
            catch { }
            Cef.Shutdown();
        } 
        
    }
    public static class ColorExt
    {
        public static uint ToUint(this Color c)
        {
            return (uint)(((c.A << 24) | (c.R << 16) | (c.G << 8) | c.B) & 0xffffffffL);
        }
        public static Color ToColor(this uint value)
        {
            return Color.FromArgb((byte)((value >> 24) & 0xFF),
                   (byte)((value >> 16) & 0xFF),
                   (byte)((value >> 8) & 0xFF),
                   (byte)(value & 0xFF));
        }
    }
}
