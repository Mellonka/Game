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
        Image SpriteSheet { get; set; }
        void SetAnimation();
        void Move();
        void PlayAnimation(Graphics g);
    }
}
