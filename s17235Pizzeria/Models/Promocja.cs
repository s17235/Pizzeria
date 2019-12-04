using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            PizzeriaPromocja = new HashSet<PizzeriaPromocja>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        public int IdPromocja { get; set; }
        public string Opis { get; set; }

        public virtual ICollection<PizzeriaPromocja> PizzeriaPromocja { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
