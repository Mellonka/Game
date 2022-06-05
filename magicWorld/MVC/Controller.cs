using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicWorld
{
    public class Controller
    {
        readonly GameModel game;
        public Controller(GameModel game)
        {
            this.game = game;
        }

        public void MouseDown(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    game.AddSpell(game.Icon.currentElement);
                    break;
            }
        }

        public void MouseUp(object sender, MouseEventArgs e)
        {
            switch (e.Button)
            {
                case MouseButtons.Left:
                    game.Player.Launch(e.Location);
                    break;
            }
        }

        public void OnPress(object sender, KeyEventArgs e)
        {
            switch (e.KeyCode)
            {
                case Keys.W:
                    game.Player.Dy = -8;
                    game.Player.IsMoving = true;
                    break;
                case Keys.A:
                    game.Player.Dx = -8;
                    game.Player.IsMoving = true;
                    break;
                case Keys.S:
                    game.Player.Dy = 8;
                    game.Player.IsMoving = true;
                    break;
                case Keys.D:
                    game.Player.Dx = 8;
                    game.Player.IsMoving = true;
                    break;
                case Keys.D1:
                    game.Icon.ChangeElement(0);
                    break;
                case Keys.D2:
                    game.Icon.ChangeElement(1);
                    break;
                case Keys.D3:
                    game.Icon.ChangeElement(2);
                    break;
                case Keys.D4:
                    game.Icon.ChangeElement(3);
                    break;
            }

        }
        public void OnKeyUp(object sender, KeyEventArgs e)
        {
            game.Player.Dx = 0;
            game.Player.Dy = 0;
            game.Player.IsMoving = false;
        }

    }
}
