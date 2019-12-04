using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Napoj
    {
        public Napoj()
        {
            MenuNapoj = new HashSet<MenuNapoj>();
            NapojZamowienie = new HashSet<NapojZamowienie>();
            RozmiarNapoj = new HashSet<RozmiarNapoj>();
        }

        public int IdNapoj { get; set; }
        public string Nazwa { get; set; }
        public string Opis { get; set; }
        public decimal Cena { get; set; }

        public virtual ICollection<MenuNapoj> MenuNapoj { get; set; }
        public virtual ICollection<NapojZamowienie> NapojZamowienie { get; set; }
        public virtual ICollection<RozmiarNapoj> RozmiarNapoj { get; set; }
    }
}
