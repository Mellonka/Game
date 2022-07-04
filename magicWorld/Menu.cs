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
    public partial class Menu : Form
    {
        public View currentGame;
        public Menu()
        {
            InitializeComponent();
            StartPosition = FormStartPosition.CenterScreen;

            var start = new Button();
            start.Size = new Size(200, 60);
            start.Location = new Point(Size.Width / 2 - start.Size.Width / 2, Size.Height / 2 - start.Size.Height);
            start.Font = new Font("Arial", 25);
            start.Text = "Start";
            start.Click += Start;
            Controls.Add(start);

            var exit = new Button();
            exit.Size = new Size(200, 60);
            exit.Location = new Point(start.Location.X, start.Location.Y + start.Size.Height);
            exit.Font = new Font("Arial", 25);
            exit.Text = "Exit";
            exit.Click += (s, e) => Application.Exit();
            Controls.Add(exit);
        }

        private void Start(object sender, EventArgs e)
        {
            var game = new GameModel();
            game.gameOver = new GameOver();
            game.gameOver.Owner = this;
            var view = new View(game);
            currentGame = view;
            view.Show();
            view.Focus();
            view.Owner = this;
            Hide();
            Application.OpenForms["System.Windows.Forms.Form.GameOver"]?.Close(); 
        }

        public void Retry()
        {

            currentGame.Close();
            GC.Collect();
            Start(new object(), new EventArgs());
        }
    }
}
