using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Atributos
    {
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int MovSpeed { get; set; }
        public int AtkRange { get; set; }
        public int Luck { get; set; }

        public Atributos()
        {
        }

        public Atributos(int hp, int atk, int def, int movSpeed, int atkRange, int luck)
        {
            Hp = hp;
            Atk = atk;
            Def = def;
            MovSpeed = movSpeed;
            AtkRange = atkRange;
            Luck = luck;
        }
    }
}
