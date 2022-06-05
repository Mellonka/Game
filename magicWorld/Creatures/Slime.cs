using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows.Forms;

namespace MagicWorld
{
    public class Slime : Enemy
    {
        public Slime(int posX, int posY) : base(posX, posY)
        {
            RunAnimations = EntityInfo.RunAnimationsSlime;
            AttackAnimations = EntityInfo.AttackAnimationsSlime;
            StayAnimations = EntityInfo.StayAnimationsSlime;
            Size = EntityInfo.SizeSlime;
            Damage = EntityInfo.DamageSlime;
            SpriteSheet = EntityInfo.SpriteSheetSlime;
            TakeDamageAnimations = EntityInfo.TakeDamageAnimationsSlime;
            var random = new Random();
            Speed = random.Next(2,8);
            healthBar = new HealthBar(random.Next(200, 600), Size.Width - 30, 10, new Point(Location.X, Location.Y + Size.Height - 12));
        }
    }
}
