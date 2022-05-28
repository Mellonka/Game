using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public interface IEntity : IAnimation
    {
        void Move();
        void Attack();

    }
}
