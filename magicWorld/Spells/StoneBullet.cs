using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class StoneBullet : Spell
    {
        public static float Damage = 100;


        public StoneBullet(Point location) : base(location) 
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\земля.png");
            Size = new Size(14 * 3, 17 * 3);
            heightSprite = 32 * 3;

            PreparingAnimations = 2;
            FlyingAnimations = 2;
            ExploreAnimations = 3;
        }

        public override void Explore()
        {
            base.Explore();
        }

    }
}
