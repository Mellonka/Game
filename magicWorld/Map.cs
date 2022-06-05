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

        readonly int[,] map;

        public readonly int Width;
        public readonly int Height;
        Image spriteSheet;
        Dictionary<int, Rectangle> mapObj;

        public Map(int[,] map)
        {
            this.map = map;
            Width = map.GetLength(1);
            Height = map.GetLength(0);
            spriteSheet = MapsInfo.SpriteSheet;
            mapObj = MapsInfo.MapObjects;
        }

        public void DrawMap(Graphics g)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                    g.DrawImage(spriteSheet, x * 48, y * 48, mapObj[map[y, x]], GraphicsUnit.Pixel);
        }
    }
}
