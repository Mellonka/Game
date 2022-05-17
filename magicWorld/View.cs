﻿using System;
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
        public Entity player;
        private Map map;
        #region
        private Timer timer1;
        #endregion


        public Form1()
        {
            InitializeComponent();
            Size = new Size(96 * 15, 54 * 15);
            timer1 = new Timer();
            timer1.Interval = 40;
            timer1.Tick += new EventHandler(Update);
            KeyUp += new KeyEventHandler(OnKeyUp);
            KeyDown += new KeyEventHandler(OnPress);
            Init();
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
                    player.Direction = -1;
                    player.Dx = -5;
                    player.isMoving = true;

                    break;
                case Keys.S:
                    player.Dy = 5;
                    player.isMoving = true;

                    break;
                case Keys.D:
                    player.Direction = 1;
                    player.Dx = 5;
                    player.isMoving = true;
                    break;
            }
            
        }

        public void Update(object sender, EventArgs e)
        {
            if (player.isMoving)
                player.Move();
            Invalidate();
        }

        void Init()
        {
            spriteHero = new Bitmap(Path.Combine(
                new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\гг.png"));
            map = new Map();
            Width = (map.Width) * 48;
            Height = (map.Height + 1) * 47;
            player = new Entity(50, 50, spriteHero);
            Paint += OnPaint;
            timer1.Start();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;
            map.DrawMap(graphics);
            player.PlayAnimation(graphics);
        }
    }
}
