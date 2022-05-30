using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagicWorld
{
    public static class EntityInfo
    {
        // Slime
        public static int RunAnimationsSlime  = 9;
        public static int AttackAnimationsSlime = 3;
        public static int StayAnimationsSlime = 0;
        public static Size SizeSlime = new Size(104, -80);
        public static Image SpriteSheetSlime = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\слайм.png");
        public static float HPSlime = 300;
        public static float DamageSlime = 150;

        // Hero
        public static int RunAnimationsHero = 3;
        public static int AttackAnimationsHero = 2;
        public static int StayAnimationsHero = 9;
        public static Size SizeHero = new Size(111, -129);
        public static Image SpriteSheetHero = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\гг.png");
        public static float HPHero = 1500;
        public static float MPHero = 2000;


        // Mannequin
        public static int RunAnimationsMannequin = 0;
        public static int AttackAnimationsMannequin = 0;
        public static int StayAnimationsMannequin = 0;
        public static Size SizeMannequin = new Size(66, 90);
        public static Image SpriteSheetMannequin = new Bitmap(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString() + "\\Sprites\\манекен.png");
        public static float HPMannequin = 500;


    }
}
