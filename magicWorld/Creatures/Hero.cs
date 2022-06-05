using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicWorld
{
    public class Hero : Entity
    {
        Timer timerForManna;
        public Spell currentSpell;

        public Hero(int posX, int posY) : base(posX, posY)
        {
            RunAnimations = EntityInfo.RunAnimationsHero;
            AttackAnimations = EntityInfo.AttackAnimationsHero;
            StayAnimations = EntityInfo.StayAnimationsHero;
            SpriteSheet = EntityInfo.SpriteSheetHero;
            Size = EntityInfo.SizeHero;
            TakeDamageAnimations = 5;
            healthBar = new HealthBar(EntityInfo.HPHero, Size.Width - 30, 10, new Point(Location.X, Location.Y + Size.Height - 33));
            mannaBar = new MannaBar(EntityInfo.MPHero, Size.Width - 30, new Point(Location.X, Location.Y + Size.Height - 23));
            timerForManna = new Timer { Interval = 1000 };
            timerForManna.Tick += (s, e) => Task.Run(() => mannaBar.Value += 100);
            timerForManna.Start();
        }

        public override void SetAttackAnimation()
        {
            currentAnimation += currentAnimation == AttackAnimations ? 0 : 1;
        }

        public void Launch(Point target)
        {
            if (currentSpell != null)
            {
                mannaBar.Value -= currentSpell.Cost;
                currentSpell.Launch(target);
                IsAttacking = false;
            }
        }


        public void Attack(Elements element)
        {

            IsAttacking = true;
            currentAnimation = 0;
            switch (element)
            {
                case Elements.Fire:
                    currentSpell = new Fireball(Location);
                    break;
                case Elements.Water:
                    currentSpell = new Waterball(Location);
                    break;
                case Elements.Earth:
                    currentSpell = new StoneBullet(Location);
                    break;
                case Elements.Wind:
                    currentSpell = new WindBlade(Location);
                    break;
            }
            if (mannaBar.Value - currentSpell.Cost <= 0)
            {
                currentSpell = null;
                IsAttacking = false;
            }
        }
    }
}
