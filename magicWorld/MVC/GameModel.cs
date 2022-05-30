using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MagicWorld
{
    public class GameModel
    {
        readonly List<IEnemy> enemies;
        public readonly List<ISpell> activeSpells;
        Point spawnPoint;

        public Icon Icon;

        public Controller Controller;
        public Timer TimerSpawn;
        public Timer TimerMove;
        public Hero Player;
        public Map Map;

        public GameModel()
        {
            TimerSpawn = new Timer { Interval = 8000 };
            TimerSpawn.Tick += SpawnEnemy;

            TimerMove = new Timer { Interval = 40 };
            TimerMove.Tick += MovePlayer;
            TimerMove.Tick += MoveEnemies;
            TimerMove.Tick += MoveSpells;


            enemies = new List<IEnemy>();
            activeSpells = new List<ISpell>();


            Controller = new Controller(this);
            Player = new Hero(150, 210);
            Map = new Map(MapsInfo.Map1);

            Icon = new Icon(Map.Width, Map.Height);
            
        }

        public void Start(Point spawnPoint)
        {
            this.spawnPoint = spawnPoint;
            TimerMove.Start();
            TimerSpawn.Start();
        }

        public void AddSpell(Elements element)
        {
            Player.Attack(element);
            activeSpells.Add(Player.currentSpell);
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


            g.DrawImage(Icon.SpriteSheet, Icon.Location.X, Icon.Location.Y,
                new Rectangle(new Point(Icon.Size.Width * (int)Icon.currentElement, 0), Icon.Size), GraphicsUnit.Pixel);
        }
        private void MoveSpells(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                foreach (var spell in activeSpells)
                {
                    lock (spell)
                    {
                        spell.Move();
                    }
                }
            });
        }

        private void MoveEnemies(object sender, EventArgs e)
        {
            Task.Run(() =>
            {
                foreach (var enemy in enemies)
                {
                    enemy.FindPlayer(Player.Location);
                    lock (enemy)
                    {
                        enemy.Move();
                    }
                }
            });
        }

        private void MovePlayer(object sender, EventArgs e)
        {
            if (Player.isMoving)
                Player.Move();
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            var enemy = new Slime(spawnPoint.X, spawnPoint.Y);
            enemies.Add(enemy);
        }
    }
}
