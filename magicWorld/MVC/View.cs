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

            FormClosed += (s, e) =>
            {
                game.gameOver.Close();
                GC.Collect();
                Owner.Show();
            };

            ClientSize = new Size(game.Map.Width * MapsInfo.CellSize, game.Map.Height * MapsInfo.CellSize);

            game.Start();
        }

    }
}
