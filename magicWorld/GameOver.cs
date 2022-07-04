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
    public partial class GameOver : Form
    {
        public GameOver()
        {
            InitializeComponent();

            Size = new Size(800, 600);
            StartPosition = FormStartPosition.CenterScreen;

            var label = new Label();
            label.Text = "Game over!";
            label.Size = new Size(300, 50);
            label.Location = new Point(Size.Width / 2 - label.Size.Width / 2, label.Size.Height * 2);
            label.Font = new Font("Arial", 38);
            Controls.Add(label);

            var buttonRetry = new Button();
            buttonRetry.Text = "Retry";
            buttonRetry.Font = new Font("Arial", 25);
            buttonRetry.Size = new Size(200, 50);
            buttonRetry.Location = new Point(Size.Width / 2 - buttonRetry.Size.Width / 2, Size.Height / 2 - buttonRetry.Size.Height / 2);
            buttonRetry.Click += ButtonRetry;
            Controls.Add(buttonRetry);
        }

        private void ButtonRetry(object sender, EventArgs e)
        {
            var menu = Owner as Menu;
            menu.Retry();
            Close();
        }
    }
}
