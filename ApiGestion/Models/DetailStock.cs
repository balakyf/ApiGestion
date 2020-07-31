using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class DetailStock
    {
        [Key]
        public Guid Id { get; set; }
    }
}
