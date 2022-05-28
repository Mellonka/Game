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
        public Image SpriteSheet { get; set; }
        public Size Size { get; set; }
        public Point Direction { get; set; }
        public Point Target { get; set; }
        public Point Location { get; set; }

        public int currentAnimation;
        public int currentFrame;
        public int RunAnimations { get; set; }
        public int AttackAnimations { get; set; }
        public int StayAnimations { get; set; }


        public Spell(Point location, Point target)
        {
            Location = location;
            Target = target;
        }



        public virtual void Explore()
        {

        }

        public void PlayAnimation(Graphics g)
        {

        }

        public void SetAnimation()
        {

        }
    }
}
