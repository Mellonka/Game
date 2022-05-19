using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Map
    {

        int[,] map;

        public readonly int Width;
        public readonly int Height;

        public Map(int[,] map)
        {
            this.map = map;
            Width = map.GetLength(1);
            Height = map.GetLength(0);
        }

        public void DrawMap(Graphics g)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    g.DrawImage(MapsInfo.SpriteSheet, x * 48, y * 48,   MapsInfo.Elements[map[y, x]], GraphicsUnit.Pixel);
            DrawSeed(g);
        }

        void DrawSeed(Graphics g)
        {
            g.DrawImage(MapsInfo.SpriteSheet, 10 * 48, 10 * 48, MapsInfo.Elements[6], GraphicsUnit.Pixel);

        }
    }
}
