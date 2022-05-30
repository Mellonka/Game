using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public class Icon
    {
        public Image SpriteSheet = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\иконки.png");

        public Elements currentElement = 0;
        public static Size Size = new Size(210, 210);
        public static Point Location;
        public Icon(int width, int height)
        {
            Location = new Point(width * MapsInfo.CellSize - Size.Width - 30, height * MapsInfo.CellSize - Size.Height - 10);
        }
        public void ChangeElement(int number)
        {
            currentElement = (Elements)number;
        }
    }
}
