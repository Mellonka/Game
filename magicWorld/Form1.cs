using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace magicWorld
{
    public partial class Form1 : Form
    {
        public Image spriteHero;

        public Entity hero;

        public Form1()
        {
            InitializeComponent();
            Size = new Size(96*15, 54*15);

            timer1.Interval = 25;
            timer1.Tick += new EventHandler(Update);
            KeyUp += new KeyEventHandler(OnKeyUp);

            KeyDown += new KeyEventHandler(OnPress);
            
            Init();
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            hero.dX = 0;
            hero.dY = 0;
            hero.isMoving = false;
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    hero.dY = -3;
                    break;
                case Keys.A:
                    if (hero.direction == 1)
                        hero.sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                    hero.direction = -1;
                    hero.dX = -3;
                    break;
                case Keys.S:
                    hero.dY = 3;
                    break;
                case Keys.D:
                    if (hero.direction == -1)
                        hero.sprite.RotateFlip(RotateFlipType.Rotate180FlipY);
                    hero.direction = 1;
                    hero.dX = 3;
                    break;
            }
            hero.isMoving = true;
        }

        public void Update(object sender, EventArgs e)
        {
            if (hero.isMoving)
                hero.Move();
            Invalidate();
        }
  

        void Init()
        {
            spriteHero = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Wizard.png"));
            hero = new Entity(50, 50, spriteHero);
            
            Paint += OnPaint;
            timer1.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            graphics.DrawImage(hero.sprite, hero.posX, hero.posY);
        }
    }


    
}
