using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Zamowienie
    {
        public Zamowienie()
        {
            DodatekZamowienie = new HashSet<DodatekZamowienie>();
            NapojZamowienie = new HashSet<NapojZamowienie>();
            PizzaZamowienie = new HashSet<PizzaZamowienie>();
        }

        public int IdZamowienie { get; set; }
        public int PromocjaIdPromocja { get; set; }
        public DateTime DataZamowienia { get; set; }
        public string AdresDostawy { get; set; }

        public virtual Promocja PromocjaIdPromocjaNavigation { get; set; }
        public virtual ICollection<DodatekZamowienie> DodatekZamowienie { get; set; }
        public virtual ICollection<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
