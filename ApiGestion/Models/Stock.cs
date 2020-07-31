using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Stock
    {
        [Key]
        public Guid Id { get; set; }
        public int PrixAchat { get; set; }
        public int PrixVente { get; set; }
        public Guid TypeOperationId { get; set; }
        public Guid OperateurId { get; set; }
        public DateTime Date { get; set; }
        public int StockSeuil { get; set; }
        public Guid DetailStockId { get; set; }

        [ForeignKey(nameof(TypeOperationId))]
        public TypeOperation TypeOperation { get; set; }

        [ForeignKey(nameof(DetailStockId))]
        public DetailStock DetailStock { get; set; }

        [ForeignKey(nameof(OperateurId))]
        public Operateur Operateur { get; set; }
    }
}
