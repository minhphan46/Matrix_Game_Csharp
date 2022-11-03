using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuyenTap
{
    internal class Board
    {
        public int xItem = 0;
        public int yItem = 0;

        public const int DEFAULT_SQUARE_HEIGHT = 50;
        public const int DEFAULT_SQUARE_WIDTH = 50;

        public const int DEFAULT_NUM_OF_SQUARE = 10;

        public Color COLOR_WALL = Color.DarkBlue;
        public Color COLOR_BACKROUND = Color.LightSkyBlue;
        public Color COLOR_ITEM = Color.PaleGoldenrod;
        public Color COLOR_GOAD = Color.LightPink;

        protected int _squareHeight;
        protected int _squareWidth;
        public int SquareHeight { get { return _squareHeight; } set { _squareHeight = value; } }
        public int SquareWidth { get { return _squareWidth; } set { _squareWidth = value; } }

        protected Form _parentForm;

        protected int _numOfSquare = DEFAULT_NUM_OF_SQUARE;
        public Form ParentForm
        {
            get { return _parentForm; }
        }
        protected Square[,] _squares;
        public Square[,] Squares
        {
            get { return _squares; }
            set { _squares = value; }
        }

        List<KeyValuePair<int, int>> _squaresWall = new List<KeyValuePair<int, int>>();
        public Board(Form parentForm, int squareHeight = DEFAULT_SQUARE_HEIGHT, int squareWidth = DEFAULT_SQUARE_WIDTH)
        {
            _parentForm = parentForm;
            _squareHeight = squareHeight;
            _squareWidth = squareWidth;

            _squares = new Square[_numOfSquare, _numOfSquare];

            Init();
            InitWall();
            parentForm.KeyDown += new KeyEventHandler(MyKeyDow);
        }

        private void MyKeyDow(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.KeyCode == Keys.Down)
                {
                    if (xItem < _numOfSquare - 1 && CheckHitWall(xItem+1,yItem) == false)
                    {
                        _squares[xItem, yItem].Color = COLOR_BACKROUND;
                        xItem++;
                        _squares[xItem, yItem].Color = COLOR_ITEM;
                    }

                }
                if (e.KeyCode == Keys.Up )
                {
                    if (xItem > 0 && CheckHitWall(xItem-1, yItem) == false)
                    {
                        _squares[xItem, yItem].Color = COLOR_BACKROUND;
                        xItem--;
                        _squares[xItem, yItem].Color = COLOR_ITEM;
                    }
                }
                if (e.KeyCode == Keys.Left)
                {
                    if (yItem > 0 && CheckHitWall(xItem, yItem-1) == false)
                    {
                        _squares[xItem, yItem].Color = COLOR_BACKROUND;
                        yItem--;
                        _squares[xItem, yItem].Color = COLOR_ITEM;
                    }
                }
                if (e.KeyCode == Keys.Right)
                {
                    if (yItem < _numOfSquare - 1 && CheckHitWall(xItem, yItem+1) == false)
                    {
                        _squares[xItem, yItem].Color = COLOR_BACKROUND;
                        yItem++;
                        _squares[xItem, yItem].Color = COLOR_ITEM;
                    }
                }

                if(xItem == _numOfSquare-1 && yItem == _numOfSquare - 1)
                {
                    DialogResult result = MessageBox.Show("YOU WIN");
                    if(result == DialogResult.OK)
                    {
                        xItem = 0;
                        yItem = 0;
                        _squares[xItem, yItem].Color = COLOR_ITEM;
                        _squares[_numOfSquare - 1, _numOfSquare - 1].Color = COLOR_GOAD;
                    }
                }
            }
            catch { }
        }

        public void Init()
        {
            int left = 0;
            int top = 0;
            for (int i = 0; i < _numOfSquare; i++)
            {
                left = 0;
                for (int j = 0; j < _numOfSquare; j++)
                {
                    Square sq = new Square(this, left, top, _squareHeight, _squareWidth, i, j, COLOR_BACKROUND);

                    _squares[i, j] = sq;
                    _parentForm.Controls.Add(sq);
                    left += _squareWidth;
                }
                top += _squareHeight;
            }

            _squares[xItem, yItem].Color = COLOR_ITEM;
        }

        public bool CheckHitWall(int x, int y)
        {
            foreach (KeyValuePair<int, int> item in _squaresWall)
            {
                if(item.Key == x && item.Value == y)
                {
                    return true;
                }
            }
            return false;
        }

        public void InitWall()
        {
            for (int i = 0; i < _numOfSquare; i++)
            {
                for (int j = 0; j < _numOfSquare; j++)
                {
                    if (i == 1 && j != 9)
                        _squaresWall.Add(new KeyValuePair<int, int>(i, j));
                    if (i == 3 && j != 0)
                        _squaresWall.Add(new KeyValuePair<int, int>(i, j));
                    if (i == 5 && j != 9)
                        _squaresWall.Add(new KeyValuePair<int, int>(i, j));
                    if (i == 7 && j != 0)
                        _squaresWall.Add(new KeyValuePair<int, int>(i, j));
                    if (i == 9 && j != 9)
                        _squaresWall.Add(new KeyValuePair<int, int>(i, j));
                }
            }
            foreach(KeyValuePair<int, int> item in _squaresWall)
            {
                _squares[item.Key, item.Value].Color = COLOR_WALL;
            }
            _squares[_numOfSquare-1, _numOfSquare-1].Color = COLOR_GOAD;
        }
    }
}
