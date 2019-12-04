using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class MenuNapoj
    {
        public int MenuIdMenu { get; set; }
        public int NapojIdNapoj { get; set; }

        public virtual Menu MenuIdMenuNavigation { get; set; }
        public virtual Napoj NapojIdNapojNavigation { get; set; }
    }
}
