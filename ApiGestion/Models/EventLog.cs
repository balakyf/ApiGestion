using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class EventLog
    {
        [Key]
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public Guid OperateurId { get; set; }
        public Guid EvenementId { get; set; }
        public Boolean Statut { get; set; }
        
        [ForeignKey(nameof(EvenementId))]
        public Evenement Evenement { get; set; }

        [ForeignKey(nameof(OperateurId))]
        public Operateur Operateur { get; set; }
    }
}
