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


        public StoneBullet(Point location) : base(location) 
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\земля.png");
            Size = new Size(11 * 4, 10 * 4);
            heightSprite = 32 * 4;

            PreparingAnimations = 0;
            FlyingAnimations = 1;
            ExploreAnimations = 3;
            Damage = 500;
            speed = 35;
            Cost = 120;
            element = Elements.Earth;

        }

        public override void SetSize()
        {
            if (currentFrame == 1)
                Size = new Size(16 * 4, 12 * 4);
            else if (currentFrame == 2)
                Size = new Size(30 * 4, 27 * 4);
        }

        public override void Explore()
        {
            base.Explore();
            SetSize();
        }

    }
}
