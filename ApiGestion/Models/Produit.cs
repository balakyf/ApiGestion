using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ApiGestion.Models
{
    public class Produit
    {
        [Key]
        public Guid Id { get; set; }
        public string NomArticle { get; set; }
        public Guid CategorieId { get; set; }
        public string CodeBarre { get; set; }
        public int QuantiteEnStock { get; set; }

        [ForeignKey(nameof(CategorieId))]
        public Categorie Categorie { get; set; }

    }
}
