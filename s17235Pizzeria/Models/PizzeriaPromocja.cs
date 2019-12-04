using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class PizzeriaPromocja
    {
        public int PizzeriaIdPizzeria { get; set; }
        public int PromocjaIdPromocja { get; set; }

        public virtual Pizzeria PizzeriaIdPizzeriaNavigation { get; set; }
        public virtual Promocja PromocjaIdPromocjaNavigation { get; set; }
    }
}
