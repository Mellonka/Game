using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Hero : Entity
    {
        float mp;

        public Spell currentSpell;

        public Hero(int posX, int posY) : base(posX, posY)
        {
            RunAnimations = EntityInfo.RunAnimationsHero;
            AttackAnimations = EntityInfo.AttackAnimationsHero;
            StayAnimations = EntityInfo.StayAnimationsHero;
            SpriteSheet = EntityInfo.SpriteSheetHero;
            Size = EntityInfo.SizeHero;
            HP = EntityInfo.HPHero;
            mp = EntityInfo.MPHero;
        }
        public void Launch(Point target)
        {
            currentSpell.Launch(target);
            isAttacking = false;
        }

        public void Attack(Elements element)
        {
            isAttacking = true;
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

        }
    }
}
