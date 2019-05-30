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
        public int Atk { get; set; }
        public int X { get; set; }
        public int Y { get; set; }

        public Monster(int hp, int atk,int x, int y)
        {
            Hp = hp;
            Atk = atk;
            X = x;
            Y = y;
        }

        public Player Attack(Player p)
        {
            Random r = new Random();
            if (Convert.ToInt32(r.Next(1, 6) * (Atk / (p.Def+p.ItemAtual.StatBonus.Def))) <= 0)
                p.Hp -= 1;
            else
                p.Hp -=Convert.ToInt32(r.Next(1,6) * (Atk/ (p.Def + p.ItemAtual.StatBonus.Def)));
            
            return p;
        }
    }
}
