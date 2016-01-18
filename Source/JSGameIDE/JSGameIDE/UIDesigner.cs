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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace JSGameIDE
{
    public partial class UIDesigner : Form
    {
        public int width = 500;
        public int height = 400;
        public UIDesigner form;

        public UIDesigner()
        {
            form = this;
            InitializeComponent();
            UIPanel.Size = new Size(width, height);
            FlowCenter();
            UICenter();
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (typeof(Button) == c.GetType())
                {
                    c.MouseDown += (object sender, MouseEventArgs e) => {
                        CustomButton b = CloneButton((Button)c);
                        b.Parent = form;
                        b.BringToFront();

                        b.Focus();
                        b.Moving = true;
                        Point _mp = form.PointToClient(Cursor.Position);
                        b.Location = new Point(_mp.X - b.Size.Width / 2, _mp.Y - b.Size.Height / 2);

                        b.MouseDown += (object _sender, MouseEventArgs _e) =>
                        {
                            b.Moving = true;
                        };
                        b.MouseUp += (object _sender, MouseEventArgs _e) =>
                        {
                            if (b.Parent != UIPanel)
                            {
                                Point bL = b.Parent.PointToScreen(b.Location);
                                Point UIL = UIPanel.Parent.PointToScreen(UIPanel.Location);
                                if (bL.X > UIL.X && bL.X < UIL.X + UIPanel.Size.Width &&
                                bL.Y > UIL.Y && bL.Y < UIL.Y + UIPanel.Size.Height)
                                {
                                    b.Parent = UIPanel;
                                    b.Location = UIPanel.PointToClient(bL);
                                }
                                else
                                {
                                    b.Parent.Controls.Remove(b);
                                    b.Dispose();
                                }
                            }
                            b.Moving = false;
                        };
                        b.MouseMove += (object _sender, MouseEventArgs _e) =>
                        {
                            Point mp = b.Parent.PointToClient(Cursor.Position);
                            if (b.Moving)
                                b.Location = new Point(mp.X - b.Size.Width/2, mp.Y - b.Size.Height / 2);
                            this.Refresh();
                        };
                        b.MouseLeave += (object _sender, EventArgs _e) =>
                        {
                            if (b.Moving)
                            {
                                Point mp = b.Parent.PointToClient(Cursor.Position);
                                b.Location = new Point(mp.X - b.Size.Width / 2, mp.Y - b.Size.Height / 2);
                                b.Focus();
                            }
                        };
                        b.DoubleClick += (object _sender, EventArgs _e) =>
                        {
                            MessageBox.Show(b.Text);
                        };
                    };
                }
            }
        }

        private CustomButton CloneButton(Button btn)
        {
            CustomButton b = new CustomButton();
            b.Text = btn.Text;
            b.Width = btn.Width;
            b.Height = btn.Height;
            b.Tag = btn.Tag;
            return b;
        }

        private void flowLayoutPanel1_Resize(object sender, EventArgs e)
        {
            FlowCenter();
        }

        private void FlowCenter()
        {
            foreach (Control c in flowLayoutPanel1.Controls)
            {
                if (c != null)
                {
                    c.Anchor = AnchorStyles.None;
                    c.Margin = new Padding(flowLayoutPanel1.Width/2 - c.Width/2, c.Margin.Top, c.Margin.Right, c.Margin.Bottom);
                }
            }
        }

        private void UICenter()
        {
            UIPanel.Location = new Point(UIPanel.Parent.Size.Width/2 - UIPanel.Size.Width/2, UIPanel.Parent.Size.Height / 2 - UIPanel.Size.Height/2);
        }

        private void splitContainer1_Panel2_Resize(object sender, EventArgs e)
        {
            UICenter();
        }
    }
    public class CustomButton : Button
    {
        public bool Moving = false;
        public CustomButton()
        {
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }
}
