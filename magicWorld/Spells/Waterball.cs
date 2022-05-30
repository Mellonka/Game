using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Waterball : Spell
    {
        public static float Damage = 100;


        public Waterball(Point location) : base(location) 
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\вода.png");
            Size = new Size(14 * 3, 17 * 3);
            heightSprite = 32 * 3;

            PreparingAnimations = 1;
            FlyingAnimations = 1;
            ExploreAnimations = 2;
        }

        public override void SetSize()
        {
            switch (currentFrame)
            {
                case 1:
                    Size = new Size(63, 54);
                    break;
                case 2:
                    Size = new Size(63, 126);
                    break;
            }
        }

        public override void Explore()
        {
            base.Explore();
        }
    }
}
