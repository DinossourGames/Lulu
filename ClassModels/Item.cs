using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassModels
{
    public class Item
    {
        public String URL { get; set; }
        public String Id { get; set; }
        public string Nome { get; set; }
        public string Description { get; set; }
        public int Durability { get; set; }
        public Atributos StatBonus { get; set; }
        public int price { get; set; }
        public bool isLootBox { get; set; }
        public Item()
        {
        }

        public Item(String url, String id, string nome, string description, int durability, Atributos statBonus)
        {
            URL = url;
            this.Id = id;
            Nome = nome;
            Description = description;
            Durability = durability;
            StatBonus = statBonus;
        }
    }
}
