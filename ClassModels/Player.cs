using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Player
    {
        public int Hp { get; set; }
        public int Atk { get;  set; }
        public int Def { get;  set; }
        public int X { get;  set; }
        public int Y { get;  set; }

        public Player()
        {

        }

        public Player(int hp, int atk, int def, int x, int y)
        {
            Hp = hp;
            Atk = atk;
            Def = def;
            X = x;
            Y = y;
        }
    }
}
