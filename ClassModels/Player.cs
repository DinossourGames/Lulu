using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Player
    {
        public int Hp { get; set; } = 10;
        public int Atk { get; set; } = 3;
        public int Def { get;  set; }
        public int X { get;  set; }
        public int Y { get;  set; }
        public int Speed { get; set; } = 5;
        public int Range { get; set; } = 3;

        public Player()
        {

        }

        public Player(int hp, int atk, int def, int x, int y, int speed, int range)
        {
            Hp = hp;
            Atk = atk;
            Def = def;
            X = x;
            Y = y;
            Speed = speed;
            Range = range;
        }
    }
}
