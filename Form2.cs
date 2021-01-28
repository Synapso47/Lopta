using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lopta
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        Lopta[] l = new Lopta[15];
        int n = 15;
        bool[] pomeranje = new bool[15];
        Random r = new Random();
        private void Form2_Load(object sender, EventArgs e)
        {
            for(int i = 0; i < n; i++)
            {
                int p = r.Next(10, 30);
                int x = r.Next(p, ClientRectangle.Width - p);
                int y = r.Next(p, ClientRectangle.Height - p);
                Color boja = Color.FromArgb(150, r.Next(256), r.Next(256), r.Next(256));
                l[i] = new Lopta(new Point(x, y), p, boja);
            }
        }

        private void Form2_Paint(object sender, PaintEventArgs e)
        {
            for (int i = 0; i < n; i++)
                l[i].Boji(e.Graphics);
        }
        int x0, y0;
        private void Form2_MouseDown(object sender, MouseEventArgs e)
        {
            x0 = e.X;
            y0 = e.Y;
            Point a = new Point(e.X, e.Y);
            for(int i = 0; i < n; i++)
            {
                if (l[i].SadrziTacku(a))
                    pomeranje[i] = true;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e)
        {
            int dx = e.X - x0;
            int dy = e.Y - y0;
            for(int i = 0; i < n; i++)
            {
                if (pomeranje[i])
                {
                    l[i].Pokreni(dx, dy);
                    l[i].Pomeri();
                }
            }
            Refresh();
            x0 = e.X;
            y0 = e.Y;
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e)
        {
            for (int i = 0; i < n; i++)
                pomeranje[i] = false;
        }
    }
}
