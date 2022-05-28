using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public interface IEnemy : IEntity
    {

        void FindPlayer(Point playerLocation);




    }
}
