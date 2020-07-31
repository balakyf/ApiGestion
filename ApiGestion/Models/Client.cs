using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Client
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenon { get; set; }
        public string Telephone { get; set; }
        public string Adresse { get; set; }
        public TypeClient TypeClient { get; set; }
        public string SecteurActivite { get; set; }
    }
}
