using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Rozmiar
    {
        public Rozmiar()
        {
            RozmiarNapoj = new HashSet<RozmiarNapoj>();
            RozmiarPizza = new HashSet<RozmiarPizza>();
        }

        public int IdRozmiar { get; set; }
        public int Nazwa { get; set; }

        public virtual ICollection<RozmiarNapoj> RozmiarNapoj { get; set; }
        public virtual ICollection<RozmiarPizza> RozmiarPizza { get; set; }
    }
}
