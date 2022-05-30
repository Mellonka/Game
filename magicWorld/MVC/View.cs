using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicWorld
{
    public partial class View : Form
    {
        readonly GameModel game;
        readonly Controller controller;
        
        public View(GameModel game)
        {
            InitializeComponent();
            this.game = game;
            controller = game.Controller;
            game.TimerMove.Tick += (s, e) => Invalidate();

            KeyUp += controller.OnKeyUp;
            KeyDown += controller.OnPress;
            Paint += game.OnPaint;
            MouseDown += controller.MouseDown;
            MouseUp += controller.MouseUp; 

            Width = game.Map.Width * MapsInfo.CellSize;
            Height = (game.Map.Height + 1) * MapsInfo.CellSize;

            game.Start(new Point((Width + 50) - ((Width + 50) % 3), (Height / 2) - (Height / 2 % 3)));
        }

        
    }
}
