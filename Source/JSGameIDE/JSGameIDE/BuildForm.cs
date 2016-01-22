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
using System.Threading;
using System.Windows.Forms;

namespace JSGameIDE
{
    public partial class BuildForm : Form
    {
        public float step = 0;
        private Thread uiUpdateThread;

        public BuildForm()
        {
            InitializeComponent();
            uiUpdateThread = new Thread(() => {
                while (progressBar1.Value < 100)
                {
                    ProgressUpdate();
                    Thread.Sleep(100);
                }
            });
            uiUpdateThread.IsBackground = true;
        }

        public static void ProgressStep(int total, BuildForm form)
        {
            if (form != null)
            {
                if (form.InvokeRequired)
                    form.Invoke(new MethodInvoker(() => { ProgressStep(total, form); }));
                else
                {
                    if (form != null)
                    {
                        form.step += 100 / total;
                        form.step = form.step > 100 ? 100 : form.step;
                    }
                }
            }
        }

        public void ProgressUpdate()
        {
            if (this.InvokeRequired)
                this.Invoke(new MethodInvoker(() => { ProgressUpdate(); }));
            else
            {
                int val = (int)Math.Round(LinearLerp(progressBar1.Value, step, .7f));
                progressBar1.Value = val;
                Text = "Build in progress: " + val.ToString() + "%";
            }
        }

        float LinearLerp(float a, float b, float f)
        {
            return (a * (1.0f - f)) + (b * f);
        }

        private void BuildForm_Load(object sender, EventArgs e)
        {
            uiUpdateThread.Start();
        }
    }
}
