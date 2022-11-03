using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuyenTap
{
    internal class Square : PictureBox
    {
        protected Color _color = new Color();
        public Color Color
        {
            get { return _color; }
            set { 
                _color = value;
                BackColor = _color;
            }
        }
        protected int _squareHeight;
        protected int _squareWidth;

        protected Board _board;

        protected int _x;
        protected int _y;
        public Square(Board board,int l, int t, int squareHeight, int squareWidth, int a, int b, Color c)
        {
            _squareHeight = squareHeight;
            _squareWidth = squareWidth;
            _board = board;
            _x = a;
            _y = b;
            Color = c;
            this.BorderStyle = BorderStyle.FixedSingle;
            this.Left = l;
            this.Top = t;
            this.Size = new System.Drawing.Size(squareWidth, squareHeight);
            //this.Location = new System.Drawing.Point(x, y);

            this.Paint += new PaintEventHandler(square_paint);
        }

        private void square_paint(object sender, PaintEventArgs e)
        {
            using (Font myFont = new Font("Arial", 14))
            {
                //e.Graphics.DrawString(_x.ToString() + " " + _y.ToString(), myFont, Brushes.Green, new Point(2, 2));
            }
        }
    }
}
