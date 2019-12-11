using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace s17235Pizzeria.Models
{
    public partial class Promocja
    {
        public Promocja()
        {
            PizzeriaPromocja = new HashSet<PizzeriaPromocja>();
            Zamowienie = new HashSet<Zamowienie>();
        }

        [Required]
        public int IdPromocja { get; set; }

        [Required(ErrorMessage = "Opis promocji jest wymagany")]
        public string Opis { get; set; }

        public virtual ICollection<PizzeriaPromocja> PizzeriaPromocja { get; set; }
        public virtual ICollection<Zamowienie> Zamowienie { get; set; }
    }
}
