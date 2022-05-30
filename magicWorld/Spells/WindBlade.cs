using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    class WindBlade : Spell
    {
        public static float Damage = 100;


        public WindBlade(Point location) : base(location) 
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\ветер.png");
            Size = new Size(13 * 3, 18 * 3);
            heightSprite = 48 * 3;

            PreparingAnimations = 1;
            FlyingAnimations = 1;
            ExploreAnimations = 2;
        }

        public override void Explore()
        {
            base.Explore();
        }
    }
}
