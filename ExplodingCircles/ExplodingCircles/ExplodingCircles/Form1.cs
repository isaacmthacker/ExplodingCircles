using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExplodingCircles
{
    public partial class ExplodingCircles : Form
    {
        public ExplodingCircles()
        {
            DoubleBuffered = true;
            InitializeComponent();
        }
        public void ExplodingCircles_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            float x = ClientSize.Width / 2.0f;
            float y = ClientSize.Height / 2.0f;
            float r = Math.Min(ClientSize.Width / 2.0f, ClientSize.Height / 2.0f);

            Console.WriteLine(r.ToString());

            g.FillRectangle(Brushes.GhostWhite, new RectangleF(
                new PointF(x - r, y - r),
                new SizeF(2 * r, 2 * r)));




            //To get points in the middle cross, need an odd number that's a factor of the radius
            DrawCircles(g, x, y, r, 15);


            DrawCircles(g, 127, 83, 50, 25);
            DrawCircles(g, 111, 353, 50, 25);
            DrawCircles(g, 661, 68, 50, 25);
            DrawCircles(g, 664, 328, 50, 25);
            DrawCircles(g, 414, 191, 50, 25);
        }

        public void DrawCircles(Graphics g, float x, float y, float enclosingRadius, int num)
        {
            g.DrawEllipse(new Pen(Brushes.Black), new RectangleF(
                new PointF(x - enclosingRadius, y - enclosingRadius),
                new SizeF(2 * enclosingRadius, 2 * enclosingRadius)));


            //Get smaller circle diameter and radius
            float diameter = (2 * enclosingRadius) / num;
            float radius = diameter / 2;
            for (int i = 0; i < num; ++i)
            {
                //Start from top corner of square for big circle
                float xPos = (x - enclosingRadius) + radius + i * diameter;
                for (int j = 0; j < num; ++j)
                {
                    float yPos = (y - enclosingRadius) + radius + j * diameter;

                    double dist = (x - xPos) * (x - xPos) + (y - yPos) * (y - yPos);

                    if (dist <= (enclosingRadius - radius) * (enclosingRadius - radius))
                    {
                        g.DrawEllipse(new Pen(Brushes.Black), new RectangleF(
                            new PointF(xPos - radius, yPos - radius),
                            new SizeF(2 * radius, 2 * radius)));
                    }


                }
            }
        }
        public void ExplodingCircles_MouseClick(object sender, MouseEventArgs e)
        {
            Console.WriteLine(e.X.ToString() + "," + e.Y.ToString());
        }
    }
}
