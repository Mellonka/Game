using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace magicWorld
{
    public class Map
    {

        readonly int[,] map;
        public readonly int Width;
        public readonly int Height;

        public static readonly Image sprite = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\карта.png");

        public static readonly Dictionary<int, Rectangle> elements = new Dictionary<int, Rectangle>
        {
            {0, new Rectangle(new Point(32*3, 48*3), new Size(16*3, 16*3)) },
            {1, new Rectangle(new Point(32*3, 32*3), new Size(16*3, 16*3)) },
            {2, new Rectangle(new Point(32*3, 64*3), new Size(16*3, 16*3)) },
            {3, new Rectangle(new Point(48*3, 48*3), new Size(16*3, 16*3)) },
            {4, new Rectangle(new Point(48*3, 32*3), new Size(16*3, 16*3)) },
            {5, new Rectangle(new Point(48*3, 64*3), new Size(16*3, 16*3)) },

            {6, new Rectangle(new Point(0,0), new Size(28*3, 22*3)) },
            {7, new Rectangle(new Point(32*3,0), new Size(34*3, 23*3)) },
            {8, new Rectangle(new Point(80*3,0), new Size(33*3, 34*3)) },
            {9, new Rectangle(new Point(0,32*3), new Size(17*3, 12*3)) },
        };

        public Map()
        {
            map = new int[,]
            {
                { 4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4,4 },
                { 3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3,3 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0 },
                { 2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,2,},
                { 5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5,5 }
            };
            Width = map.GetLength(1);
            Height = map.GetLength(0);
        }

        public void DrawMap(Graphics g)
        {
            for (int x = 0; x < Width; x++)
                for (int y = 0; y < Height; y++)
                {
                    g.DrawImage(sprite, x * 48, y * 48,   elements[map[y, x]], GraphicsUnit.Pixel);
                }
        }
    }
}
