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
        public int dX;
        public int dY;
        public bool isMoving;
        public int direction = 1;

        public Image sprite;

        public Entity(int posX, int posY, Image sprite)
        {
            this.posX = posX;
            this.posY = posY;
            this.sprite = sprite;

        }

        public void Move()
        {
            posX += dX;
            posY += dY;
        }

    }
}
