using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Spell : ISpell
    {
        public bool isPreparing;
        bool isExplore;

        int Dx;
        int Dy;
        public Image SpriteSheet { get; set; }
        public Size Size { get; set; }
        public int heightSprite;

        public Point Location;

        public int currentAnimation;
        public int currentFrame;

        public int PreparingAnimations;
        public int FlyingAnimations { get; set; }
        public int ExploreAnimations { get; set; }


        public Spell(Point location)
        {
            Location = new Point(location.X + 120, location.Y - 140);
            currentFrame = 0;
            currentAnimation = 0;
            isPreparing = true;
        }

        public void Launch(Point target)
        {
            isPreparing = false;
            SetDelta(target);
            currentFrame++;
            SetSize();
        }

        void SetDelta(Point target)
        {
            var difX = target.X - Location.X;
            var difY = target.Y - Location.Y;
            var norma = Math.Sqrt(difY * difY + difX * difX);

            Dx = difX * 20 / (int)Math.Round(norma);
            Dy = difY * 20 / (int)Math.Round(norma);
        }

        public virtual void SetSize() { }

        public void Move() 
        { 
            Location.X += Dx;
            Location.Y += Dy;
        }

        public virtual void Explore()
        {

        }

        public void PlayAnimation(Graphics g)
        {
            SetAnimation();

            g.DrawImage(SpriteSheet, Location.X, Location.Y, 
                new Rectangle(new Point(Size.Width * currentAnimation, currentFrame * heightSprite), Size),
                GraphicsUnit.Pixel);
        }

        public void SetAnimation()
        {
            if (isPreparing && currentAnimation < PreparingAnimations)
                currentAnimation++;
            else if (!isExplore && currentAnimation < FlyingAnimations)
                currentAnimation++;
            else if (isExplore && currentAnimation < ExploreAnimations)
                currentAnimation++;
            else
                currentAnimation = 0;
        }
    }
}
