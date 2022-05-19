﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Hero : Entity
    {
        public Hero(Point location, Image spriteSheet, Size size, int stayAnimations, int runAnimations, int attackAnimations)    
                                : base(location, spriteSheet, size, stayAnimations, runAnimations, attackAnimations)
        { }

        public override void Attack(Fireball spell)
        {
            base.Attack(spell);
        }
    }
}
