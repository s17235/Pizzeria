using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Menu
    {
        public Menu()
        {
            MenuDodatek = new HashSet<MenuDodatek>();
            MenuNapoj = new HashSet<MenuNapoj>();
            MenuPizza = new HashSet<MenuPizza>();
        }

        public int IdMenu { get; set; }
        public int PizzeriaIdPizzeria { get; set; }

        public virtual Pizzeria PizzeriaIdPizzeriaNavigation { get; set; }
        public virtual ICollection<MenuDodatek> MenuDodatek { get; set; }
        public virtual ICollection<MenuNapoj> MenuNapoj { get; set; }
        public virtual ICollection<MenuPizza> MenuPizza { get; set; }
    }
}
