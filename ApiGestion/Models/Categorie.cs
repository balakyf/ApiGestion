using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Categorie
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string CategorieMere { get; set; }
    }
}
