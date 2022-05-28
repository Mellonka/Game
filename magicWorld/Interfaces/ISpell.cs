using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    interface ISpell : IAnimation
    {
        Point Target { get; set; }
        Point Location { get; set; }

        Point Direction { get; set; }

        void Explore();
    }
}
