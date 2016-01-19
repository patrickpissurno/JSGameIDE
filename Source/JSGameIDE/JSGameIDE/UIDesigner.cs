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
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CefSharp;
using CefSharp.WinForms;

namespace JSGameIDE
{
    public partial class UIDesigner : Form
    {
        public int width;
        public int height;
        public int id;
        public UIDesigner form;

        public static List<ComponentTemplate> templates = null;

        public List<UIComponent> Components = new List<UIComponent>();
        public List<CustomButton> cButtons = new List<CustomButton>();

        #region RenderScript Core
        public ChromiumWebBrowser browser;

        public const string FAKE_ADDR = "http://rendering/";

        public delegate void Callback(Image img);
        public List<string> queueScript = new List<string>();
        public List<Callback> queueCallback = new List<Callback>();
        #endregion

        public UIDesigner(int id)
        {
            this.id = id;
            this.width = UIs.uis[id].width;
            this.height = UIs.uis[id].height;

            form = this;
            InitializeComponent();
            UIPanel.Size = new Size(width, height);

            #region RenderScript Core
            browser = new ChromiumWebBrowser("");
            
            form.Controls.Add(browser);
            browser.Dock = DockStyle.Fill;

            browser.LoadingStateChanged += (object s, LoadingStateChangedEventArgs er) =>
            {
                if(!er.IsLoading && browser.Address != FAKE_ADDR)
                {
                    if(queueCallback.Count > 0)
                    {
                        queueCallback[0](Crop(new Bitmap(Base64ToImage(browser.Address.Replace("data:image/png;base64,", "")))));
                        queueCallback.RemoveAt(0);
                        if (queueScript.Count > 0)
                        {
                            browser.LoadHtml(queueScript[0], FAKE_ADDR);
                            queueScript.RemoveAt(0);
                        }
                    }
                }
            };
            #endregion

            form.Activated += Form_Activated;

            //Load the templates
            if(templates == null)
            {
                templates = new List<ComponentTemplate>();
                if(Directory.Exists(Application.StartupPath + @"\Resources\Templates"))
                {
                    string[] files = Directory.GetFiles(Application.StartupPath + @"\Resources\Templates", "*.js");
                    foreach(string file in files)
                    {
                        ComponentTemplate cT = new ComponentTemplate();
                        cT.Name = Path.GetFileNameWithoutExtension(file);
                        cT.Path = file;
                        cT.Data = File.ReadAllText(file);
                        RenderScript(cT.Data, (Image i) => {
                            cT.Image = i;
                            ReloadImages();
                        });
                        templates.Add(cT);
                    }
                }
            }

            //Create Buttons
            for(int i=0; i<templates.Count; i++)
            {
                ComponentTemplate t = templates[i];
                Button btn = new Button();
                btn.Size = new Size(80, 30);
                btn.Text = t.Image == null ? t.Name : "";
                if (t.Image != null)
                {
                    btn.BackgroundImage = t.Image;
                    btn.FlatStyle = FlatStyle.Flat;
                    btn.FlatAppearance.BorderSize = 0;
                    btn.Text = "";
                    btn.Size = t.Image.Size;
                    if (t.Image.Size.Width > splitContainer1.Panel1.Width)
                    {
                        if (t.Image.Size.Width <= 200)
                            splitContainer1.SplitterDistance = t.Image.Size.Width + 6;
                        else
                            splitContainer1.SplitterDistance = 200;
                    }
                }
                btn.Parent = flowLayoutPanel1;
                btn.BackColor = Color.Transparent;
                btn.Tag = i.ToString();
                t.button = btn;
                flowLayoutPanel1.Controls.Add(btn);
            }

            //Align
            FlowCenter();
            UICenter();
            ResetFocus();

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
                                    cButtons.Add(b);
                                    if (b.Component == null)
                                    {
                                        UIComponent comp = new UIComponent();
                                        comp.x = b.Location.X;
                                        comp.y = b.Location.Y;
                                        comp.data = templates[int.Parse(b.Tag.ToString())].Data;
                                        comp.id = Components.Count;
                                        Components.Add(comp);
                                        b.Component = comp;

                                        using (StreamWriter w = new StreamWriter(GameConfig.path + @"\Codes\UIs\ui" + form.id + @"\components\component" + comp.id + ".js"))
                                        {
                                            w.Write(comp.data);
                                        }
                                    }
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
                            b.Component.data = CodeEditor.Open("Code Editor: " + UIs.uis[form.id].name + " - " + GetScriptName(b.Component.data),
                IDEComponent.ComponentType.UIComponent, b.Component.data, b.Component.id, null);
                        };
                    };
                }
            }
        }

        //Reload Stuff
        private void Form_Activated(object sender, EventArgs e)
        {
            if (browser.IsBrowserInitialized)
            {
                browser.Stop();
                queueCallback.Clear();
                queueScript.Clear();
                foreach (CustomButton b in cButtons)
                {
                    if (!IDEConfig.IsDefaultEditor)
                    {
                        string path = GameConfig.path + @"\Codes\UIs\ui" + form.id + @"\components\component" + b.Component.id + ".js";
                        if (File.Exists(path))
                            b.Component.data = File.ReadAllText(path);
                    }
                    RenderScript(b.Component.data, (Image i) =>
                    {
                        b.BackgroundImage = i;
                        ReloadImages();
                    });
                }
                ReloadImages();
            }
        }

        public void ReloadImages()
        {
            if (this.InvokeRequired)
            {
                try
                {
                    this.Invoke(new MethodInvoker(() => { ReloadImages(); }));
                }
                catch { }
            }
            else
            {
                for (int i = 0; i < templates.Count; i++)
                {
                    ComponentTemplate t = templates[i];
                    Button btn = t.button;
                    if (t.Image != null)
                    {
                        btn.BackgroundImage = t.Image;
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Size = t.Image.Size;
                        if (t.Image.Size.Width > splitContainer1.Panel1.Width)
                        {
                            if (t.Image.Size.Width <= 200)
                                splitContainer1.SplitterDistance = t.Image.Size.Width + 6;
                            else
                                splitContainer1.SplitterDistance = 200;
                        }
                        btn.Text = "";
                    }
                }
                for (int i = 0; i < cButtons.Count; i++)
                {
                    CustomButton btn = cButtons[i];
                    if (btn.BackgroundImage != null)
                    {
                        btn.FlatStyle = FlatStyle.Flat;
                        btn.FlatAppearance.BorderSize = 0;
                        btn.Size = btn.BackgroundImage.Size;
                        btn.Text = "";
                    }
                }
                FlowCenter();
                ResetFocus();
            }
        }

        public void ResetFocus()
        {
            Button p = new Button();
            form.Controls.Add(p);
            p.Focus();
            form.Controls.Remove(p);
            p.Dispose();
        }

        public void RenderScript(string script, Callback callback)
        {
            Builder.PreprocessorDefine();
            string str = "<canvas id=gameCanvas width=800 height=800></canvas><script>var Box2D = null;" + Environment.NewLine;
            str += Builder.BuildHeader() + Environment.NewLine;
            str += "var roomManager = {actual:{camera:{x:0, y:0}}}" + Environment.NewLine;
            str += script + Environment.NewLine;
            str += "window.onload = function() {" + Environment.NewLine + 
                "var a = new " + GetScriptName(script) +"();" + Environment.NewLine + 
                "if(a.draw!=null)" + Environment.NewLine + 
                "a.draw(); " + Environment.NewLine + 
                " window.location = canvas.toDataURL('image / png');" + Environment.NewLine + "}</script>";
            str = str.Replace("addEventListener", "//");
            if (queueCallback.Count == 0)
            {
                browser.LoadHtml(str, FAKE_ADDR);
            }
            else
                queueScript.Add(str);
            queueCallback.Add(callback);
            Clipboard.SetText(str);
        }

        public string GetScriptName(string script)
        {
            string[] lines = script.Split('\n');
            foreach(string line in lines)
            {
                int f = line.IndexOf("= function(");
                int v = line.IndexOf("var");
                if (f != -1 && v != -1)
                    return line.Substring(v + 4, f - (v + 4)).Trim();
            }
            return null;
        }

        #region RenderScript Core
        public Image Base64ToImage(string base64String)
        {
            // Convert Base64 String to byte[]
            byte[] imageBytes = Convert.FromBase64String(FixBase64ForImage(base64String));
            MemoryStream ms = new MemoryStream(imageBytes, 0,
              imageBytes.Length);

            // Convert byte[] to Image
            ms.Write(imageBytes, 0, imageBytes.Length);
            Image image = Image.FromStream(ms, true);
            return image;
        }

        public string FixBase64ForImage(string Image)
        {
            System.Text.StringBuilder sbText = new System.Text.StringBuilder(Image, Image.Length);
            sbText.Replace("\r\n", String.Empty); sbText.Replace(" ", String.Empty);
            return sbText.ToString();
        }

        public static Bitmap Crop(Bitmap bmp)
        {
            int w = bmp.Width;
            int h = bmp.Height;

            Func<int, bool> allWhiteRow = row =>
            {
                for (int i = 0; i < w; ++i)
                    if (bmp.GetPixel(i, row).A == 255)
                        return false;
                return true;
            };

            Func<int, bool> allWhiteColumn = col =>
            {
                for (int i = 0; i < h; ++i)
                    if (bmp.GetPixel(col, i).A == 255)
                        return false;
                return true;
            };

            int topmost = 0;
            for (int row = 0; row < h; ++row)
            {
                if (allWhiteRow(row))
                    topmost = row;
                else break;
            }

            int bottommost = 0;
            for (int row = h - 1; row >= 0; --row)
            {
                if (allWhiteRow(row))
                    bottommost = row;
                else break;
            }

            int leftmost = 0, rightmost = 0;
            for (int col = 0; col < w; ++col)
            {
                if (allWhiteColumn(col))
                    leftmost = col;
                else
                    break;
            }

            for (int col = w - 1; col >= 0; --col)
            {
                if (allWhiteColumn(col))
                    rightmost = col;
                else
                    break;
            }

            if (rightmost == 0) rightmost = w; // As reached left
            if (bottommost == 0) bottommost = h; // As reached top.

            int croppedWidth = rightmost - leftmost;
            int croppedHeight = bottommost - topmost;

            if (croppedWidth == 0) // No border on left or right
            {
                leftmost = 0;
                croppedWidth = w;
            }

            if (croppedHeight == 0) // No border on top or bottom
            {
                topmost = 0;
                croppedHeight = h;
            }

            try
            {
                var target = new Bitmap(croppedWidth, croppedHeight);
                using (Graphics g = Graphics.FromImage(target))
                {
                    g.DrawImage(bmp,
                      new RectangleF(0, 0, croppedWidth, croppedHeight),
                      new RectangleF(leftmost, topmost, croppedWidth, croppedHeight),
                      GraphicsUnit.Pixel);
                }
                return target;
            }
            catch (Exception ex)
            {
                throw new Exception(
                  string.Format("Values are topmost={0} btm={1} left={2} right={3} croppedWidth={4} croppedHeight={5}", topmost, bottommost, leftmost, rightmost, croppedWidth, croppedHeight),
                  ex);
            }
        }
        #endregion

        private CustomButton CloneButton(Button btn)
        {
            CustomButton b = new CustomButton();
            b.Text = btn.Text;
            b.Width = btn.Width;
            b.Height = btn.Height;
            b.Tag = btn.Tag;
            b.BackgroundImage = btn.BackgroundImage;
            b.FlatStyle = btn.FlatStyle;
            b.FlatAppearance.BorderSize = btn.FlatAppearance.BorderSize;
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
                    c.Margin = new Padding(flowLayoutPanel1.Width/2 - c.Width/2 + (flowLayoutPanel1.VerticalScroll.Visible ? -7 : 0), c.Margin.Top, c.Margin.Right, c.Margin.Bottom);
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
        public UIComponent Component = null;
        public CustomButton()
        {
            SetStyle(ControlStyles.StandardClick | ControlStyles.StandardDoubleClick, true);
        }
    }

    public class ComponentTemplate
    {
        public string Name;
        public string Path;
        public string Data;
        public Image Image = null;
        public Button button = null;
    }
}
