using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicWorld
{
    public class Controls
    {
        readonly GameModel game;

        public Controls(GameModel game)
        {
            this.game = game;
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.Player.Dy = -5;
                    game.Player.isMoving = true;
                    break;

                case Keys.A:
                    game.Player.Dx = -5;
                    game.Player.isMoving = true;
                    break;

                case Keys.S:
                    game.Player.Dy = 5;
                    game.Player.isMoving = true;
                    break;

                case Keys.D:
                    game.Player.Dx = 5;
                    game.Player.isMoving = true;
                    break;
            }
        }

        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            game.Player.Dx = 0;
            game.Player.Dy = 0;
            game.Player.isMoving = false;
        }

    }
}
