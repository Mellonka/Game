using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public interface IAnimation
    {
        int RunAnimations { get; set; }
        int AttackAnimations { get; set; }
        int StayAnimations{ get; set; }
        Size Size { get; set; }
        Image SpriteSheet{ get; set; }

        void SetAnimation();

        void PlayAnimation(Graphics g);
}
}
