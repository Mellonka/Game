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

        public override void Attack()
        {
            base.Attack();
        }
    }
}
