using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Vente
    {
        [Key]
        public Guid Id { get; set; }
        public Guid OperationId { get; set; }
        public Guid OperateurId { get; set; }
        public DateTime DateOperation { get; set; }
        public int PrixVenteTotal { get; set; }
        public Guid PanierId { get; set; }
        public int ReferenceTransaction { get; set; }
        public int ReferenceClient  { get; set; }
        public int Remise { get; set; }

        [ForeignKey(nameof(PanierId))]
        public Panier Panier { get; set; }
    }
}
