using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Configuration
    {
        [Key]
        public Guid Id { get; set; }
        public string Devise { get; set; }
        public int ImprimanteTicketId { get; set; }
        public int ImprimannetFactureId { get; set; }
        public string AdresseServeurBD { get; set; }
        public string NomServeurBD { get; set; }
        public string UserBD { get; set; }
        public string PasswordDB { get; set; }
        public string TypeDeFormat { get; set; }
        public string LecteurCodeBarre { get; set; }
        public int TVA { get; set; }
    }
}
