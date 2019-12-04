using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class RozmiarNapoj
    {
        public int RozmiarIdRozmiar { get; set; }
        public int NapojIdNapoj { get; set; }

        public virtual Napoj NapojIdNapojNavigation { get; set; }
        public virtual Rozmiar RozmiarIdRozmiarNavigation { get; set; }
    }
}
