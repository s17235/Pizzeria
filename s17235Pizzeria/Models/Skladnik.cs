using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Skladnik
    {
        public Skladnik()
        {
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
        }

        public int IdSkladnik { get; set; }
        public int Cena { get; set; }
        public string Nazwa { get; set; }
        public int RodzajIdRodzaju { get; set; }

        public virtual Rodzaj RodzajIdRodzajuNavigation { get; set; }
        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
    }
}
