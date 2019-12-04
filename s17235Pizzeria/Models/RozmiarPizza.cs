using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class RozmiarPizza
    {
        public int RozmiarIdRozmiar { get; set; }
        public int PizzaIdPizza { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Rozmiar RozmiarIdRozmiarNavigation { get; set; }
    }
}
