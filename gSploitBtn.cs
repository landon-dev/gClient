using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Kamils_Garden.Forms.Controls
{
    public enum RectangleCorners
    {
        None = 0, TopLeft = 1, TopRight = 2, BottomLeft = 4, BottomRight = 8,

        All = TopLeft | TopRight | BottomLeft | BottomRight,
        Top = TopLeft | TopRight,
        Bottom = BottomLeft | BottomRight,
        Left = TopLeft | BottomLeft,
        Right = TopRight | BottomRight
    }
    public class gSploitBtn : Button
    {
        protected override bool ShowFocusCues => false;

        public gSploitBtn()
        {
            FlatStyle = FlatStyle.Flat;
            FlatAppearance.BorderColor = BackColor;
            FlatAppearance.BorderSize = 0;

            SetStyle(ControlStyles.UserPaint, true);
            SetStyle(ControlStyles.OptimizedDoubleBuffer, true);
            SetStyle(ControlStyles.AllPaintingInWmPaint, true);
        }

        [DefaultValue(RectangleCorners.None)]
        public RectangleCorners Corners { get; set; } = RectangleCorners.None;

        [DefaultValue(30)]
        public int Radius { get; set; } = 30;

        public static GraphicsPath Create(int x, int y, int width, int height, int radius, RectangleCorners corners)
        {
            GraphicsPath p = new GraphicsPath();
            p.StartFigure();

            if ((RectangleCorners.TopLeft & corners) == RectangleCorners.TopLeft)
                p.AddArc(x, y, 2 * radius, 2 * radius, 180, 90);
            else
            {
                p.AddLine(x, y + radius, x, y);
                p.AddLine(x, y, x + radius, y);
            }

            p.AddLine(x + radius, y, x + width - radius, y);

            if ((RectangleCorners.TopRight & corners) == RectangleCorners.TopRight)
                p.AddArc(x + width - 2 * radius, y, 2 * radius, 2 * radius, 270, 90);
            else
            {
                p.AddLine(x + width - radius, y, x + width, y);
                p.AddLine(x + width, y, x + width, y + radius);
            }

            p.AddLine(x + width, y + radius, x + width, y + height - radius);

            if ((RectangleCorners.BottomRight & corners) == RectangleCorners.BottomRight)
                p.AddArc(x + width - 2 * radius, y + height - 2 * radius, 2 * radius, 2 * radius, 0, 90);
            else
            {
                p.AddLine(x + width, y + height - radius, x + width, y + height);
                p.AddLine(x + width, y + height, x + width - radius, y + height);
            }

            p.AddLine(x + width - radius, y + height, x + radius, y + height);

            if ((RectangleCorners.BottomLeft & corners) == RectangleCorners.BottomLeft)
                p.AddArc(x, y + height - 2 * radius, 2 * radius, 2 * radius, 90, 90);
            else
            {
                p.AddLine(x + radius, y + height, x, y + height);
                p.AddLine(x, y + height, x, y + height - radius);
            }

            p.AddLine(x, y + height - radius, x, y + radius);

            p.CloseFigure();
            return p;
        }

        private void RecreateRegion()
        {
            if (Corners is RectangleCorners.None) return;

            var bounds = ClientRectangle;
            bounds.Width--; bounds.Height--;

            using (var path = Create(bounds.X, bounds.Y, bounds.Width, bounds.Height, Radius, Corners)) Region = new Region(path);

            Invalidate();
        }

        protected override void OnSizeChanged(EventArgs ev)
        {
            base.OnSizeChanged(ev);

            if (Handle != null)
                RecreateRegion();
        }

    }
}
    
