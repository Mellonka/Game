using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Fireball : Spell
    {
        public Fireball(Point location) : base(location) 
        {
            SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\огонь.png");
            Size = new Size(13*3, 18*3);
            heightSprite = 48 * 3;
            PreparingAnimations = 2;
            FlyingAnimations = 2;
            ExploreAnimations = 3;
            Damage = 35;
            speed = 25;
            Cost = 60;
            element = Elements.Fire;
        }

        public override void SetSize()
        {
            if (currentFrame == 1)
                Size = new Size(24 * 3, 17 * 3);
            else if (currentFrame == 2)
                Size = new Size(48 * 3, 48 * 3);
        }

        public override void Explore()
        {
            base.Explore();
            SetSize();
        }
    }
}
