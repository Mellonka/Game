using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public delegate void Attacking(int damage);

    public class Enemy : Entity
    {
        public event Attacking AttackingPlayer;
        public event Attacking AttackingCastle;

        public int Damage { get; set; }
        public Enemy(int posX, int posY) 
            : base(posX, posY) { }

        public void PlayerAttacking()
        {
            if (!IsDead)
            {
                IsAttacking = true;
                AttackingPlayer.Invoke(Damage);
            }
        }
        public void CastleAttacking()
        {
            if (!IsDead)
            {
                IsAttacking = true;
                AttackingCastle.Invoke(Damage);
            }
        }

        public void FindPlayerOrCastle(Point playerLocation, int castlePosX, int castleWidth)
        {
            IsAttacking = false;
            if (Speed == 0)
                return;

            
            var castleDifX = castlePosX - Location.X + castleWidth;
            var castleDifY = 0;
            if (Location.Y < MapsInfo.CellSize * 3)
                castleDifY = MapsInfo.CellSize * 3 - Location.Y;
            else if (Location.Y > MapsInfo.CellSize * 19)
                castleDifY = MapsInfo.CellSize * 19 - Location.Y;
            var castleNorma = Math.Sqrt(castleDifY * castleDifY + castleDifX * castleDifX);

            var playerDifX = playerLocation.X - Location.X;
            var playerDifY = playerLocation.Y - Location.Y;
            var playerNorma = Math.Sqrt(playerDifY * playerDifY + playerDifX * playerDifX);

            double norma;
            int difX;
            int difY;
            var isPlayerChosen = false;
            if (playerNorma > castleNorma)
            {
                norma = castleNorma;
                difX = castleDifX;
                difY = castleDifY;
            }
            else
            {
                isPlayerChosen = true;
                norma = playerNorma;
                difX = playerDifX;
                difY = playerDifY;
            }

            if (Math.Abs(difX) < Size.Width / 12 && Math.Abs(difY) < -Size.Height / 12)
            {
                if (isPlayerChosen)
                    PlayerAttacking();
                else
                    CastleAttacking();
            }
            else
            {
                Dx = difX * Speed / (int)Math.Round(norma);
                Dy = difY * Speed / (int)Math.Round(norma);
                IsMoving = true;
            }
        }

        public bool HitTarget(Spell spell)
        {
            var difX = Location.X + Size.Width / 2 - spell.Location.X - spell.Size.Width / 2;
            var difY = Location.Y + Size.Height / 2 - spell.Location.Y - spell.Size.Height / 2;
            /* if (Math.Abs(difX) <= Size.Width / (double)2.5 + spell.Size.Width / (double)2.5)
                 if (Math.Abs(difY) <= -Size.Height / (double)2.5 + spell.Size.Height / (double)2.7)
                 {
                     //if ((delta.X < 0 && dx > 0) || (delta.Y < 0 && dy > 0) || (delta.X > 0 && dx < 0) || (delta.Y > 0 && dy < 0))
                     return true;
                 }*/
            return Math.Abs(difX) <= Size.Width / (double)2.5 + spell.Size.Width / (double)2.5 
                && Math.Abs(difY) <= -Size.Height / (double)2.5 + spell.Size.Height / (double)2.7;
        }
    }
}
