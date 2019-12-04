using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class NapojZamowienie
    {
        public int NapojIdNapoj { get; set; }
        public int ZamowienieIdZamowienie { get; set; }

        public virtual Napoj NapojIdNapojNavigation { get; set; }
        public virtual Zamowienie ZamowienieIdZamowienieNavigation { get; set; }
    }
}
