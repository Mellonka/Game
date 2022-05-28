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
        readonly Controls controls;
        
        public View(GameModel game)
        {
            InitializeComponent();
            this.game = game;
            controls = game.Controls;
            game.TimerMove.Tick += (s, e) => Invalidate();

            KeyUp += controls.OnKeyUp;
            KeyDown += controls.OnPress;
            Paint += game.OnPaint;

            Init();
        }

        void Init()
        {
            Width = game.Map.Width * MapsInfo.CellSize.Width;
            Height = (game.Map.Height + 1) * MapsInfo.CellSize.Height;
            game.Start(new Point(Width + 50, Height / 2));
        }
    }
}
