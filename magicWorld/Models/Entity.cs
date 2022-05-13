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
        public int PosX;
        public int PosY;
        public int Dx;
        public int Dy;
        public bool isMoving;
        public int currentFrame;
        public int currentAnimation;
        public int runFrames;
        public Size Size { get; set; }

        public int Direction = 1;
        public Image SpriteSheet;

        public Entity(int posX, int posY, Image spriteSheet)
        {
            PosX = posX;
            PosY = posY;
            SpriteSheet = spriteSheet;
            Size = new Size(33 * 3, 40 * 3);
            currentFrame = 0;
            currentAnimation = 0;
            runFrames = 4;

        }
        
        public void PlayAnimation(Graphics graphics)
        {
            SetAnimation();
            graphics.DrawImage(SpriteSheet, PosX, PosY, new Rectangle(new Point(currentAnimation * 33 * 3, 0), Size), GraphicsUnit.Pixel);
        }
        
        private void SetAnimation()
        {
            if (isMoving && currentAnimation < 3)
                currentAnimation++;
            else
                currentAnimation = 0;
        }

        public void Move()
        {
            PosX += Dx;
            PosY += Dy;
        }

    }
}
