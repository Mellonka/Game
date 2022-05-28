using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Slime : Entity, IEnemy
    {
        public float Damage;
        
        public Slime(int posX, int posY) : base(posX, posY)
        {
            RunAnimations = EntityInfo.RunAnimationsSlime;
            AttackAnimations = EntityInfo.AttackAnimationsSlime;
            StayAnimations = EntityInfo.StayAnimationsSlime;
            Size = EntityInfo.SizeSlime;
            Damage = EntityInfo.DamageSlime;
            SpriteSheet = EntityInfo.SpriteSheetSlime;
            HP = EntityInfo.HPSlime;

        }


        public override void Attack()
        {
            base.Attack();
        }

        public void FindPlayer(Point playerLocation)
        {
            var difX = playerLocation.X - Location.X;
            var difY = playerLocation.Y - Location.Y;
            if (difX == 0 && difY == 0)
            {
                isMoving = false;
            }
            else
            {
                Dx = difX > 0 ? 3 : difX == 0 ? 0 : -3;
                Dy = difY > 0 ? 3 : difY == 0 ? 0 : -3;
                isMoving = true;
            }
        }
    }
}
