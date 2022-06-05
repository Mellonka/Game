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


        public WindBlade(Point location) : base(location) 
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\ветер.png");
            Size = new Size(9 * 4, 12 * 4);
            heightSprite = 48 * 4;
            PreparingAnimations = 0;
            FlyingAnimations = 1;
            ExploreAnimations = 0;
            Damage = 20;
            speed = 32;
            element = Elements.Wind;
            Cost = 50;
        }

        public override void SetSize()
        {
            if (currentFrame == 1)
                Size = new Size(20 * 4, 26 * 4);
            else if (currentFrame == 2)
                Size = new Size(14 * 4, 42 * 4);
        }

        public override void Explore()
        {

        }
    }
}
