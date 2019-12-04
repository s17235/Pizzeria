using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class MenuPizza
    {
        public int PizzaIdPizza { get; set; }
        public int MenuIdMenu { get; set; }

        public virtual Menu MenuIdMenuNavigation { get; set; }
        public virtual Pizza PizzaIdPizzaNavigation { get; set; }
    }
}
