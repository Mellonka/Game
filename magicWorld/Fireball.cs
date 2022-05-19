using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Fireball
    {
        public float Damage { get; }
        public Point Location;
        public Point Target;
        public Size Size;
        public Image SpriteSheet;


        int dx;
        int dy;
        int currentAnimation;
        int currentFrame;

        public Fireball(Point target, Point location)
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\огонь.png");
            Target = target;
            Location = location;
            var vector = new Point(target.X - Location.X, target.Y - Location.Y);
            var k = vector.Y / (double)vector.X;
            dx = 5;
            dy = (int)Math.Ceiling(k * dx * 5);
            Size = new Size(24*3, 17*3);
            currentAnimation = 0;
            currentFrame = 0;
        }


        public void Explore()
        {

        }

        public void PlayAnimation(Graphics g)
        {
            SetAnimation();
            g.DrawImage(SpriteSheet, Location.X, Location.Y,
                new Rectangle(new Point(0, 48*3), Size),
                GraphicsUnit.Pixel);
        }

        public void Move()
        {
            Location.X += dx * 5;
            Location.Y += dy;
        }

        void SetAnimation()
        {
            
        }


    }
}
