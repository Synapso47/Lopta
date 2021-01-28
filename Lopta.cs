using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
namespace Lopta
{
    class Lopta
    {
        private Point o;
        private int r, vx, vy;
        private Color boja;
        public Lopta(Point _o)
        {
            o = _o;
            r = 10;
            boja = Color.Black;
        }
        public Lopta(Point _o,int _r, Color _boja)
        {
            if (r >= 0)
            {
             o = _o;
             r = _r;
             boja = _boja;
            }
            else
            {
                throw new Exception("treba: poluprecnik>=0");
            }
        }
        public Lopta(Point _o, int _r, Color _boja,int _vx,int _vy)
        {
            if (r >= 0)
            {
                o = _o;
                r = _r;
                boja = _boja;
                vx = _vx;
                vy = _vy;
            }
            else
            {
                throw new Exception("treba: poluprecnik>=0");
            }            
        }
        public void Crtaj(Graphics g)
        {
            Pen p = new Pen(boja);
            g.DrawEllipse(p, o.X - r, o.Y - r, 2 * r, 2 * r);

        }
        public void Boji(Graphics g)
        {
            SolidBrush b = new SolidBrush(boja);
            g.FillEllipse(b, o.X - r, o.Y - r, 2 * r, 2 * r);
        }
        public void Pomeri()
        {
            o.X += vx;
            o.Y += vy;
        }
        public void Pokreni(int _vx, int _vy)
        {
            vx = _vx;
            vy = _vy;
        }
        public void Stani()
        {
            vx = vy = 0;
        }
        public void OdbijanjeX()
        {
            vx *= -1;
        }
        public void OdbijanjeY()
        {
            vy *= -1;
        }
        public bool UdarilaGoreDole(int granica)
        {
            return (o.Y + r > granica || o.Y - r < 0);
        }
        public bool UdarilaLevoDesno(int granica)
        {
            return (o.X + r > granica || o.X - r < 0);
        }
        public bool SadrziTacku(Point a)
        {
            if ((o.X - a.X) * (o.X - a.X) + (o.Y - a.Y) * (o.Y - a.Y) < r * r)
                return true;
            else return false;
        }
        public bool UdarilaLoptu(Lopta l1)
        {
            int d = (int)(Math.Pow(o.X - l1.o.X, 2) + Math.Pow(o.Y - l1.o.Y, 2));
            return d < (r + l1.r) * (r + l1.r);
        }
    }
    
}

        
