using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MagicWorld
{
    public class Entity 
    {
        public float HP;
        public float MP;
        

        public Point Location;
        public int Dx;
        public int Dy;
        public bool isMoving;
        public bool isAttacking;
        public bool isDead;


        public int currentAnimation;
        public int currentFrame;

        public int runAnimations;
        public int attackAnimations;
        public int stayAnimations;
        public Fireball currentSpell;
        public Size Size { get; set; }

        public Image SpriteSheet;

        public Entity(Point location, Image spriteSheet, Size size,
            int stayAnimations, int runAnimations, int attackAnimations)
        {
            SpriteSheet = spriteSheet;
            Size = size;
            Location = location;

            currentFrame = 0;
            currentAnimation = 0;

            this.stayAnimations = stayAnimations;
            this.runAnimations = runAnimations;
            this.attackAnimations = attackAnimations;
        }

        public virtual void Attack(Fireball spell)
        {
            currentSpell = spell;
            


        }

        public void PlayAnimation(Graphics g)
        {
            SetAnimation();
            g.DrawImage(SpriteSheet, Location.X, Location.Y,
                new Rectangle(new Point(currentAnimation * Size.Width, currentFrame * Size.Height), Size),
                GraphicsUnit.Pixel);
        }

        public void SetAnimation()
        {
            if (!isMoving && !isAttacking && currentAnimation < stayAnimations )
            {
                currentAnimation++;
                currentFrame = 0;
            }            
            else if (isMoving && currentAnimation < runAnimations)
            {
                currentFrame = 1;
                currentAnimation++;
            }
            else if (isAttacking && currentAnimation < attackAnimations)
            {
                currentFrame = 2;
                currentAnimation++;
            }
            else if (isDead)
            {
                currentAnimation = 1;
                currentFrame = 4;
            }                
            else
            {
                currentAnimation = 0;
            }
        }

        public void Move()
        {
            Location.X += Dx;
            Location.Y += Dy;
        }

    }
}
