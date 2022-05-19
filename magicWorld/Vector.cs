using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MagicWorld
{
    class Vector
    {

        public readonly Point Start;
        public readonly Point End;
        public readonly Point Vector_;

        public Vector(Point start, Point end)
        {
            Start = start;
            End = end;
            Vector_ = new Point(end.X - start.X, end.Y - start.Y);

        }

    }
}
