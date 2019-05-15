using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Monster
    {
        public int Hp { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Monster(int x, int y)
        {
            X = x;
            Y = y;
        }
    }
}
