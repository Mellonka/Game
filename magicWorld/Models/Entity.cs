using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;


namespace magicWorld
{
    public class Entity
    {
        public int posX;
        public int posY;

        private Image sprite;

        public Entity(int posX, int posY, Image sprite)
        {
            this.posX = posX;
            this.posY = posY;
            this.sprite = sprite;

        }

        public void Move(int dX, int dY)
        {
            posX += dX;
            posY += dY;
        }

    }
}
