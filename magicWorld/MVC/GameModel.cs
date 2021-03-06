using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace MagicWorld
{
    public delegate void CheckGameOver();
    public class GameModel
    {
        readonly List<Enemy> enemies;
        public readonly List<Spell> activeSpells;
        public Icon Icon;
        readonly int widthForm;
        readonly int heightForm;
        public Controller Controller;
        public Timer TimerSpawn;
        public Timer TimerMove;
        public Timer TimerClearEnemies;
        public Timer TimerClearSpells;
        public Castle Castle;

        public event CheckGameOver GameOverEvent;

        public GameOver gameOver { get; set; }

        public Hero Player;
        public Map Map;

        public GameModel()
        {
            TimerSpawn = new Timer { Interval = 3000 };
            TimerSpawn.Tick += SpawnEnemy;
            TimerMove = new Timer { Interval = 20 };
            TimerMove.Tick += MovePlayer;
            TimerMove.Tick += MoveEnemies;
            TimerMove.Tick += MoveAndHitSpells;
            TimerMove.Tick += CheckGameOver;



            TimerClearEnemies = new Timer { Interval = 3000 };
            TimerClearEnemies.Tick += ClearEnemies;

            TimerClearSpells = new Timer { Interval = 500 };
            TimerClearSpells.Tick += ClearSpells;

            GameOverEvent += () =>
            {
                gameOver.Show();
                StopGame();
            };

            enemies = new List<Enemy>();
            activeSpells = new List<Spell>();

            Controller = new Controller(this);
            Player = new Hero(65, 490);
            Map = new Map(MapsInfo.Map1);
            Castle = new Castle();
            widthForm = MapsInfo.CellSize * Map.Width;
            heightForm = MapsInfo.CellSize * Map.Height;
            Icon = new Icon(Map.Width, Map.Height);
        }

        public void StopGame()
        {
            TimerSpawn.Stop();
            TimerMove.Stop();
            TimerClearSpells.Stop();
            TimerClearEnemies.Stop();

            Controller = null;
        }

        public void Start()
        {
            TimerMove.Start();
            TimerSpawn.Start();
            TimerClearEnemies.Start();
            TimerClearSpells.Start();
        }

        private void ClearSpells(object sender, EventArgs e)
        {
            for (var i = 0; i < activeSpells.Count; i++)
            {
                var spell = activeSpells[i];
                if (spell.Location.X > widthForm || spell.Location.X < 0 || spell.Location.Y > heightForm || spell.Location.Y < 0
                    || spell.isExplore)
                {
                    activeSpells.RemoveAt(i);
                    i--;
                }
            }
        }

        private void ClearEnemies(object sender, EventArgs e)
        {

            for (int i = 0; i < enemies.Count; i++)
            {
                var enemy = enemies[i];

                if (enemy.IsDead)
                {
                    enemies.RemoveAt(i);
                    i--;
                }
            }
        }

        public void AddSpell(Elements element)
        {
            Player.Attack(element);
            if (Player.currentSpell != null)
                activeSpells.Add(Player.currentSpell);
        }

        public void OnPaint(object sender, PaintEventArgs e)
        {
            var g = e.Graphics;
            Map.DrawMap(g);
            Castle.OnPaint(g);
            Player.PlayAnimation(g);
            foreach (var enemy in enemies)
                enemy.PlayAnimation(g);
            foreach (var spell in activeSpells)
                spell.PlayAnimation(g);
            g.DrawImage(Icon.SpriteSheet, Icon.Location.X, Icon.Location.Y,
                new Rectangle(new Point(Icon.Size.Width * (int)Icon.currentElement, 0), Icon.Size), GraphicsUnit.Pixel);
        }

        public void CheckGameOver(object sender, EventArgs e)
        {
            if (Castle.isDestruct || Player.IsDead)
                GameOverEvent.Invoke();
        }


        private void MoveAndHitSpells(object sender, EventArgs e)
        {
            foreach (var spell in activeSpells)
            {
                if (spell.isExplore && (spell.element == Elements.Earth || spell.element == Elements.Water))
                    continue;
                foreach (var enemy in enemies)
                {
                    if (!enemy.IsDead && enemy.HitTarget(spell))
                    {
                        if (!spell.isExplore)
                            spell.Explore();

                        if (spell.element == Elements.Water)
                            enemy.Move(spell.Dx * 3, spell.Dy * 3);
                        enemy.TakeDamage(spell.Damage);

                        if (spell.element == Elements.Earth)
                            break;
                    }
                }
                if (!spell.isExplore)
                    spell.Move();
            }
        }



        private void MoveEnemies(object sender, EventArgs e)
        {
            foreach (var enemy in enemies)
            {
                enemy.FindPlayerOrCastle(Player.Location, Castle.Location.X, Castle.Size.Width);
                enemy.Move();
            }
        }

        private void MovePlayer(object sender, EventArgs e)
        {
            if (Player.IsMoving)
                Player.Move();
        }

        private void SpawnEnemy(object sender, EventArgs e)
        {
            var random = new Random();
            for (var i = 0; i < 6; i++)
            {
                var enemy = new Slime(widthForm + 50, random.Next(100, 950));
                enemy.AttackingPlayer += Player.TakeDamage;
                enemy.AttackingCastle += Castle.TakeDamage;
                enemies.Add(enemy);
            }
            if (random.Next() % 8 == 0)
            {
                var enemy = new Slime(random.Next(700) + 500, -5);
                enemy.AttackingPlayer += Player.TakeDamage;
                enemy.AttackingCastle += Castle.TakeDamage;
                enemies.Add(enemy);
            }
            if (random.Next() % 8 == 0)
            {
                var enemy = new Slime(random.Next(700) + 500, heightForm + 5);
                enemy.AttackingPlayer += Player.TakeDamage;
                enemy.AttackingCastle += Castle.TakeDamage;
                enemies.Add(enemy);
            }
        }
    }
}
