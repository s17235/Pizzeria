using System;
using System.Collections.Generic;

namespace s17235Pizzeria.Models
{
    public partial class Rodzaj
    {
        public Rodzaj()
        {
            Skladnik = new HashSet<Skladnik>();
        }

        public int IdRodzaju { get; set; }
        public string Nazwa { get; set; }

        public virtual ICollection<Skladnik> Skladnik { get; set; }
    }
}
