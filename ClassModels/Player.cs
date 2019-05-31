using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Player
    {
        public bool IsPlaying { get; set; }
        public int R { get; set; }
        public int MaxHp { get; set; }
        public int Hp { get; set; }
        public int Atk { get; set; }
        public int Def { get; set; }
        public int Luck { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public int Range { get; set; }
        public Item ItemAtual { get; set; }
        public Item PoolResult { get; set; }

        public Player()
        {

        }
        public Player(Player p)
        {
            MaxHp = p.MaxHp;
            Hp = p.Hp;
            Atk = p.Atk;
            Def = p.Def;
            X = p.X;
            Y = p.Y;
            Speed = p.Speed;
            Range = p.Range;
            Luck = p.Luck;
            ItemAtual = p.ItemAtual;
            PoolResult = p.PoolResult;
        }

        public Player(Player p, bool v)
        {
            if (v) // if v true then updates item
            {

                MaxHp = p.MaxHp;
                Hp = p.Hp;
                Atk = p.Atk;
                Def = p.Def;
                X = p.X;
                Y = p.Y;
                Speed = p.Speed;
                Range = p.Range;
                Luck = p.Luck;
                ItemAtual = p.PoolResult;
                PoolResult = null;
            }
            else //if v false then keeps the player item 
            {
                MaxHp = p.MaxHp;
                Hp = p.Hp;
                Atk = p.Atk;
                Def = p.Def;
                X = p.X;
                Y = p.Y;
                Speed = p.Speed;
                Range = p.Range;
                Luck = p.Luck;
                ItemAtual = p.ItemAtual;
                PoolResult = null;
            }
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
