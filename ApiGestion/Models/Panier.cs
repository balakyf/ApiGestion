using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Panier
    {
        [Key]
        public Guid Id { get; set; }
        public Guid ProduitId { get; set; }
        public Guid VenteId { get; set; }
        public int PrixVente { get; set; }
        public int PrixAchat { get; set; }
        public int Quantite { get; set; }
        public int Remise { get; set; }

   
        [ForeignKey(nameof(ProduitId))]
        public Produit Produit { get; set; }

        [ForeignKey(nameof(VenteId))]
        public Vente Vente { get; set; }

    }
}
