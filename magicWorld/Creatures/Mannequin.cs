using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Mannequin : Entity, IEnemy
    {



        public Mannequin(int posX, int posY) : base(posX, posY)
        {
            RunAnimations = EntityInfo.RunAnimationsMannequin;
            AttackAnimations = EntityInfo.AttackAnimationsMannequin;
            StayAnimations = EntityInfo.StayAnimationsMannequin;
            SpriteSheet = EntityInfo.SpriteSheetMannequin;
            HP = EntityInfo.HPMannequin;
            Size = EntityInfo.SizeMannequin;
        }

        public void FindPlayer(Point playerLocation)
        {

            throw new NotImplementedException();
        }
    }
}
