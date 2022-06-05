using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Mannequin : Enemy
    {
        public Mannequin(int posX, int posY) : base(posX, posY)
        {
            RunAnimations = EntityInfo.RunAnimationsMannequin;
            AttackAnimations = EntityInfo.AttackAnimationsMannequin;
            StayAnimations = EntityInfo.StayAnimationsMannequin;
            SpriteSheet = EntityInfo.SpriteSheetMannequin;
            Size = EntityInfo.SizeMannequin;
            Speed = 0;

            healthBar = new HealthBar(EntityInfo.HPMannequin, Size.Width - 30, 10, new Point(posX + 15, posY + Size.Height - 16));
        }
    }
}
