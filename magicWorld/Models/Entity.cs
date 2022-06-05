using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace MagicWorld
{
    public abstract class Entity
    {
        public HealthBar healthBar;
        public MannaBar mannaBar;
        
        public Point Location;
        public int Dx;
        public int Dy;
        public int Speed;

        public bool IsMoving;
        public bool IsAttacking;
        public bool IsTakeDamage;
        public bool IsDead { get => healthBar.Value <= 0; }

        public int currentAnimation;
        public int currentFrame;
        public int RunAnimations { get; set; }
        public int TakeDamageAnimations { get; set; }
        public int AttackAnimations { get; set; }
        public int StayAnimations { get; set; }
        public Size Size { get; set; }
        public Image SpriteSheet { get; set; }

        public Entity(int posX, int posY)
        {
            Location = new Point(posX, posY);

            currentFrame = 1;
            currentAnimation = 0;
        }

        public void PlayAnimation(Graphics g)
        {
            SetAnimation();
            if (!IsDead)
            {
                healthBar.OnPaint(g);
                mannaBar?.OnPaint(g);
            }
            g.DrawImage(SpriteSheet, Location.X, Location.Y,
                new Rectangle(new Point(currentAnimation * Size.Width, -currentFrame * Size.Height), Size),
                GraphicsUnit.Pixel);
        }

        public void TakeDamage(int damage)
        {
            if (!IsDead)
            {
                IsTakeDamage = true;
                healthBar.Value -= damage;
            }
        }

        public virtual void SetAttackAnimation()
        {
            if (currentAnimation < AttackAnimations)
                currentAnimation++;
            else
                currentAnimation=0;
        }

        public void SetAnimation()
        {

            if (!IsMoving && !IsAttacking && !IsTakeDamage && !IsDead && currentAnimation < StayAnimations)
            {
                currentAnimation++;
                currentFrame = 1;
            }
            else if (IsMoving && !IsAttacking && !IsTakeDamage && !IsDead && currentAnimation < RunAnimations)
            {
                currentFrame = 2;
                currentAnimation++;
            }
            else if (IsAttacking && !IsTakeDamage && !IsDead)
            {
                currentFrame = 3;
                SetAttackAnimation();
            }
            else if (IsTakeDamage && !IsDead && currentAnimation < TakeDamageAnimations)
            {
                currentFrame = 4;
                currentAnimation++;
            }
            else if (IsDead)
            {
                currentAnimation = 0;
                currentFrame = 5;
            }
            else
            {
                IsTakeDamage = false;
                currentAnimation = 0;
            }
        }

        public void Move(int dx, int dy)
        {

            if (!IsDead)
            {
                healthBar.Move(dx, dy);
                mannaBar?.Move(dx, dy);
                Location.X += dx;
                Location.Y += dy;
                Dx = 0;
                Dy = 0;
            }
        }

        public void Move()
        {
            if (!IsAttacking && !IsDead)
            {
                healthBar.Move(Dx, Dy);
                mannaBar?.Move(Dx, Dy);
                Location.X += Dx;
                Location.Y += Dy;
            }
        }
    }
}