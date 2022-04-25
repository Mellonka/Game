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

        public Form1()
        {
            InitializeComponent();
            Size = new Size(960, 540);
            Init();
        }

        void Init()
        {
            spriteHero = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\Wizard.png"));

            var player = new Entity(0, 0, spriteHero);

            Paint += OnPaint;
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            var graphics = e.Graphics;

            graphics.DrawImage(spriteHero, new Point(100, 100));

        }
    }


    
}
