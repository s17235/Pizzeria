using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class PizzaZamowienie
    {
        public int PizzaIdPizza { get; set; }
        public int ZamowienieIdZamowienie { get; set; }

        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
