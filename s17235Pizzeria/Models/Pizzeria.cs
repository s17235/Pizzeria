using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Pizzeria
    {
        public Pizzeria()
        {
            Menu = new HashSet<Menu>();
            PizzeriaPromocja = new HashSet<PizzeriaPromocja>();
        }

        public int IdPizzeria { get; set; }
        public string Opis { get; set; }
        public string Adres { get; set; }

        public virtual ICollection<Menu> Menu { get; set; }
        public virtual ICollection<PizzeriaPromocja> PizzeriaPromocja { get; set; }
    }
}
