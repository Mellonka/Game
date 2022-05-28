using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicWorld
{
    public class GameModel
    {
        readonly List<IEnemy> enemies;
        readonly List<ISpell> activeSpells;
        Point spawnPoint;

        public Controls Controls;
        public Timer TimerSpawn;
        public Timer TimerMove;
        public Hero Player;
        public Map Map;


        public GameModel()
        {
            TimerSpawn = new Timer { Interval = 5000 };
            TimerSpawn.Tick += SpawnEnemy;

            TimerMove = new Timer { Interval = 40 };
            TimerMove.Tick += MovePlayer;
            TimerMove.Tick += MoveEnemies;

            enemies = new List<IEnemy>();
            activeSpells = new List<ISpell>();


            Controls = new Controls(this);
            Player = new Hero(150, 200);
            Map = new Map(MapsInfo.Map1);

            Init();
        }
        public void Start(Point spawnPoint)
        {
            this.spawnPoint = spawnPoint;
            TimerMove.Start();
            TimerSpawn.Start();
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Map.DrawMap(g);
            Player.PlayAnimation(g);
            foreach (var enemy in enemies)
                enemy.PlayAnimation(g);
            foreach (var spell in activeSpells)
                spell.PlayAnimation(g);
        }


        private void MoveEnemies(object sender, EventArgs e)
        {
            foreach (var enemy in enemies)
            {
                enemy.FindPlayer(Player.Location);
                enemy.Move();
            }
        }

        private void MovePlayer(object sender, EventArgs e)
        {
            if (Player.isMoving)
                Player.Move();
        }

        void Init()
        {

        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            var enemy = new Slime(spawnPoint.X, spawnPoint.Y);
            enemies.Add(enemy);
        }
    }
}
