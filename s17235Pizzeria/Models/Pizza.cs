using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Pizza
    {
        public Pizza()
        {
            MenuPizza = new HashSet<MenuPizza>();
            PizzaSkladnik = new HashSet<PizzaSkladnik>();
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
            RozmiarPizza = new HashSet<RozmiarPizza>();
        }

        public int IdPizza { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<MenuPizza> MenuPizza { get; set; }
        public virtual ICollection<PizzaSkladnik> PizzaSkladnik { get; set; }
        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
        public virtual ICollection<RozmiarPizza> RozmiarPizza { get; set; }
    }
}
