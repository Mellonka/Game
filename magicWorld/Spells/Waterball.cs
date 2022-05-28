using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Waterball : Spell
    {
        public static float Damage = 100;


        public Waterball(Point location, Point target)
            : base(location, target) { }

        public override void Explore()
        {
            base.Explore();
        }
    }
}
