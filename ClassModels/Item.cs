using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    class Item
    {
        public int id { get; set; }
        public string Nome { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public Atributos StatBonus { get; set; }

        public Item(int id, string nome, string description, int durability, Atributos statBonus)
        {
            this.id = id;
            Nome = nome;
            Description = description;
            Durability = durability;
            StatBonus = statBonus;
        }
    }
}
