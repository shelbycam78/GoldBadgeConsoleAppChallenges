using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KomodoCafe.POCO
{
    public class CafeItemPoco
    {
        public int Number { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public string Info { get; set; }


        public List<string> Ingredients = new List<string>();       

        public CafeItemPoco() { }
        public CafeItemPoco(string name, decimal cost, string info, List<string> ingredients)
        {
            Name = name;
            Cost = cost;
            Info = info;
            Ingredients = ingredients;           
        }
    }
}

