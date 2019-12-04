using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Dodatek
    {
        public Dodatek()
        {
            DodatekZamowienie = new HashSet<DodatekZamowienie>();
            MenuDodatek = new HashSet<MenuDodatek>();
        }

        public int IdDodatek { get; set; }
        public string Nazwa { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<DodatekZamowienie> DodatekZamowienie { get; set; }
        public virtual ICollection<MenuDodatek> MenuDodatek { get; set; }
    }
}
