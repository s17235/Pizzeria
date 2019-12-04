using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class MenuDodatek
    {
        public int MenuIdMenu { get; set; }
        public int DodatekIdDodatek { get; set; }

        public virtual Dodatek DodatekIdDodatekNavigation { get; set; }
        public virtual Menu MenuIdMenuNavigation { get; set; }
    }
}
