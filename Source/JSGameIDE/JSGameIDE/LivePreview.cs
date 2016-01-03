﻿/*
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

namespace JSGameIDE
{
    public static class LivePreview
    {
        public static ChromiumWebBrowser Browser;
        public static readonly string BuildPath = Application.StartupPath + @"\Temp\LivePreview";
        public static readonly string PlaceholderPath = Application.StartupPath + @"\Resources\livePreview.html";
        private static MainForm mainForm;
        public static void Init(MainForm form, Control dock)
        {
            mainForm = form;
            Cef.Initialize(new CefSettings());
            Browser = new ChromiumWebBrowser(PlaceholderPath);
            dock.Controls.Add(Browser);
            Browser.Dock = DockStyle.Fill;
        }
        public static void Reload()
        {
            if(FileManager.ProjectLoaded)
            {
                //Cleans the temporary files from previous build
                string dir = Path.GetDirectoryName(BuildPath);
                try
                {
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
}
