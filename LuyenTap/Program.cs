using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LuyenTap
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Form form = new Form();
            form.Width = 600;
            form.Height = 600;
            Board board = new Board(form);

            Application.Run(form);
        }
    }
}
