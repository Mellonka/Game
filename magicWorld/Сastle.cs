using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Castle
    {
        public Image SpriteSheet;
        public Point Location;
        public HealthBar HealthBar;
        public Rectangle Rectangle;
        public Size Size;
        public bool isDestruct;

        public Castle()
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\стена.png");
            Location = new Point(-100, -6);
            HealthBar = new HealthBar(50000000000, 700, 30, new Point(400,20));
            Size = new Size(47 * 6, 183 * 6);
            Rectangle = new Rectangle(new Point(0, 0), Size);
            isDestruct = false;
        }

        public void TakeDamage(int damage)
        {
            HealthBar.Value -= damage;
            if (HealthBar.Value <= 0)
                isDestruct = true;
        }

        public void OnPaint(Graphics g)
        {
            HealthBar.OnPaint(g);
            g.DrawImage(SpriteSheet, Location.X, Location.Y, Rectangle, GraphicsUnit.Pixel);
        }
    }
}
