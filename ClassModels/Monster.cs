using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Monster
    {
        public double Hp { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Monster(int hp,int x, int y)
        {
            Hp = hp;
            X = x;
            Y = y;
        }

        public Player Attack(Player p)
        {
            p.Hp --;
            
            return p;
        }
    }
}
