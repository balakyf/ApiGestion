using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Etablissement
    {
        [Key]
        public Guid Id { get; set; }
        public string NomLong { get; set; }
        public string NomCourt { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public string Fax { get; set; }
        public string NIF { get; set; }
        public int NumeroDeCompte { get; set; }
        public Boolean Logo { get; set; }
    }
}
