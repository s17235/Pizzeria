using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

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

        [Required(ErrorMessage = "Data dostawy jest wymagana")]
        public DateTime DataZamowienia { get; set; }

        [Required(ErrorMessage="Adres dostawy jest wymagany")]
        public string AdresDostawy { get; set; }

        public virtual Promocja PromocjaIdPromocjaNavigation { get; set; }
        public virtual ICollection<DodatekZamowienie> DodatekZamowienie { get; set; }
        public virtual ICollection<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual ICollection<PizzaZamowienie> PizzaZamowienie { get; set; }
    }
}
