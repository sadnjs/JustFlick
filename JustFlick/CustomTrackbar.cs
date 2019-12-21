using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 봉순봇
{
    public partial class CustomTrackbar : UserControl
    {
        int x = 0;
        bool iskeypress = false;
        static SolidBrush brush1 = new SolidBrush(Color.FromArgb(28, 35, 43)), brush2 = new SolidBrush(Color.FromArgb(255, 255, 255));

        [Category("Trackbar"), Description("트랙바의 최소값")]
        public int Min { get; set; } = 1;
        [Category("Trackbar"), Description("트랙바의 최대값")]
        public int Max { get; set; } = 1000;
        [Category("Trackbar"), Description("트랙바의 현재값")]
        public int Value { get; set; } = 1;

        public CustomTrackbar()
        {
            InitializeComponent();
        }

        private void CustomTrackbar_MouseWheel(object sender, MouseEventArgs e)
        {
            if (e.Delta > 0 && Value < Max)
            {
                Value++;
            }
            else if (e.Delta < 0 && Value > Min)
            {
                Value--;
            }
            Invalidate();
        }

        private void CustomTrackbar_Paint(object sender, PaintEventArgs e)
        {
            if (!iskeypress)
            {
                x = (int)Math.Round((Value - Min) / ((double)(Max - Min) / (Width - Height - 1)));
            }
            var g = e.Graphics;
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
            g.FillRectangle(brush1, Rectangle.FromLTRB(1, Height / 3, Width, Height - (Height / 3)));
            g.FillRectangle(brush2, Rectangle.FromLTRB(1, Height / 3, Height + x, Height - (Height / 3)));
            Value = (int)Math.Round(Min + (((double)(Max - Min) / (Width - Height - 1)) * x));
        }

        private void CustomTrackbar_MouseDown(object sender, MouseEventArgs e)
        {
            iskeypress = true;
            Invalidate();
        }

        private void CustomTrackbar_MouseMove(object sender, MouseEventArgs e)
        {
            if (iskeypress)
            {
                if (x >= 0 && x <= Width - Height - 1)
                {
                    x = e.X - (Height >> 1);
                    Invalidate();
                }
                if (x < 0)
                {
                    x = 0;
                }
                if (x > Width - Height - 1)
                {
                    x = Width - Height - 1;
                }
            }
        }

        private void CustomTrackbar_MouseUp(object sender, MouseEventArgs e)
        {
            iskeypress = false;
        }
    }
}
