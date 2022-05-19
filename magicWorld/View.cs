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

namespace MagicWorld
{
    public partial class Form1 : Form
    {
        public Image spriteHero;
        public Entity player;
        public static Map map;

        public Form1()
        {
            InitializeComponent();
            timer1.Interval = 40;
            timer1.Tick += new EventHandler(Update);
            timer1.Start();
            KeyUp += new KeyEventHandler(OnKeyUp);
            KeyDown += new KeyEventHandler(OnPress);
            Paint += OnPaint;
            MouseClick += att;
            Init();
        }

        Fireball Spell;
        private void att(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Spell = new Fireball(e.Location, player.Location);
            }
        }

        void Init()
        {
            map = new Map(MapsInfo.Map1);
            spriteHero = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\гг.png");
            Width = map.Width * MapsInfo.CellSize.Width;
            Height = (map.Height + 1) * MapsInfo.CellSize.Height;
            player = new Hero(new Point(50, 50), spriteHero, new Size(33 * 3, 43 * 3), 9, 3, 2);
            
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            player.Dx = 0;
            player.Dy = 0;
            player.isMoving = false;
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    player.Dy = -5;
                    player.isMoving = true;
                    break;

                case Keys.A:
                    player.Dx = -5;
                    player.isMoving = true;
                    break;

                case Keys.S:
                    player.Dy = 5;
                    player.isMoving = true;
                    break;

                case Keys.D:
                    player.Dx = 5;
                    player.isMoving = true;
                    break;
            }
        }

        public void Update(object sender, EventArgs e)
        {
            if (player.isMoving)
                player.Move();
            if (Spell != null)
                Spell.Move();
            Invalidate();
        }


        private void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            map.DrawMap(g);
            
            player.PlayAnimation(g);

            if (Spell != null)
                Spell.PlayAnimation(g);
        }
    }
}
