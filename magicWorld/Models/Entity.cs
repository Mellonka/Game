using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace MagicWorld
{
    public abstract class Entity : IEntity
    {
        public float HP;

        public Point Location;
        public int Dx;
        public int Dy;
        public bool isMoving;
        public bool isAttacking;
        public bool isDead;

        public int currentAnimation;
        public int currentFrame;
        public int RunAnimations { get; set; }
        public int AttackAnimations { get; set; }
        public int StayAnimations { get; set; }
        public Size Size { get; set; }
        public Image SpriteSheet { get; set; }
        

        public Entity(int posX, int PosY)
        {
            Location = new Point(posX, PosY);

            currentFrame = 1;
            currentAnimation = 0;
        }

        public virtual void Attack()
        {
            throw new NotImplementedException();
            
        }

        public void PlayAnimation(Graphics g)
        {
            SetAnimation();
            g.DrawImage(SpriteSheet, Location.X, Location.Y,
                new Rectangle(new Point(currentAnimation * Size.Width, -currentFrame * Size.Height), Size),
                GraphicsUnit.Pixel) ;
        }

        public void SetAnimation()
        {
            if (!isMoving && !isAttacking && currentAnimation < StayAnimations )
            {
                currentAnimation++;
                currentFrame = 1;
            }            
            else if (isMoving && currentAnimation < RunAnimations)
            {
                currentFrame = 2;
                currentAnimation++;
            }
            else if (isAttacking && currentAnimation < AttackAnimations)
            {
                currentFrame = 3;
                currentAnimation++;
            }
            else if (isDead)
            {
                currentAnimation = 1;
                currentFrame = 5;
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
