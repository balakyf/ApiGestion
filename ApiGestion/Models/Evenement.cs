using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Evenement
    {
        [Key]
        public Guid Id { get; set; }
        public string LIbelle { get; set; }
    }
}
