using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class PizzaSkladnik
    {
        public int PizzaIdPizza { get; set; }
        public int SkladnikIdSkladnik { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Skladnik SkladnikIdSkladnikNavigation { get; set; }
    }
}
