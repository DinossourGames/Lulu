using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Player
    {
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Luck { get; set; }
        public int X { get;  set; }
        public int Y { get;  set; }
        public int Speed { get; set; }
        public int Range { get; set; }

        public Player()
        {

        }

        public Player(int maxhp, int hp, int atk, int def, int x, int y, int speed, int range, int luck)
        {
            MaxHp = maxhp;
            Hp = hp;
            Atk = atk;
            Def = def;
            X = x;
            Y = y;
            Speed = speed;
            Range = range;
            Luck = luck;
        }
    }
}
