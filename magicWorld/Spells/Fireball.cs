using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Fireball : Spell
    {
        public static float Damage = 100;


        public Fireball(Point location, Point target)
            : base(location, target) { }

        public override void Explore()
        {
            base.Explore();
        }
    }
}
