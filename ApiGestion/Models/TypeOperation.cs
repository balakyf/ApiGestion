using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class TypeOperation
    {
        [Key]
        public Guid Id { set; get; }
        public string Libelle { set; get; }
    }
}
