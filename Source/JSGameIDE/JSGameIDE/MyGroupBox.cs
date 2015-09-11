using System;
using System.Drawing;
using System.Windows.Forms;


namespace JSGameIDE
{
    public class RoomGroupBox : GroupBox
    {
        public Size GridSize = new Size(1, 1);

        public RoomGroupBox()
        {
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            Invalidate();
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            if(GridSize.Width > 1 && GridSize.Height > 1)
            {
                Pen pen = new Pen(Color.FromArgb(255, 34, 34, 34));

                int i_max = (int)Math.Round((double)(this.Size.Width / this.GridSize.Width));
                for (int i = 0; i <= i_max; i++)
                {
                    e.Graphics.DrawLine(pen, i * this.GridSize.Width - 1, 0, i * this.GridSize.Width - 1, this.Size.Height);
                }

                i_max = (int)Math.Round((double)(this.Size.Height / this.GridSize.Height));
                for (int i = 0; i <= i_max; i++)
                {
                    e.Graphics.DrawLine(pen, 0, i * this.GridSize.Height - 1, this.Size.Width, i * this.GridSize.Height - 1);
                }
            }
        }
    }
}
