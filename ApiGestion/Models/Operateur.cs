using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Operateur
    {
        [Key]
        public Guid Id { get; set; }
        public string Nom { get; set; }
        public string Prenom { get; set; }
        public Sexe Sexe { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public Guid RoleId { get; set; }
        public string Telephone { get; set; }

        [ForeignKey(nameof(RoleId))]
        public Role Role { get; set; }
    }
}
