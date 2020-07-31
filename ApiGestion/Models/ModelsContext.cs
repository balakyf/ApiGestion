using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace ApiGestion.Models
{
    public class ModelsContext : IdentityDbContext
    {
        public ModelsContext(DbContextOptions<ModelsContext> options)
            : base(options)
        {
        }

        public DbSet<Categorie> Categorie { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<Configuration> Configuration { get; set; }
        public DbSet<DetailStock> DetailStock { get; set; }
        public DbSet<Etablissement> Etablissement { get; set; }
        public DbSet<Evenement> Evenement { get; set; }
        public DbSet<EventLog> EventLog { get; set; }
        public DbSet<Operateur> Operateu { get; set; }
        public DbSet<Panier> Panier { get; set; }
        public DbSet<Produit> Produit { get; set; }
        public DbSet<Role> Role { get; set; }
        public DbSet<Stock> Stock { get; set; }
        public DbSet<TypeOperation> TypeOperation { get; set; }
        public DbSet<Vente> Vente { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<ApplicationUser>().Property(p => p.Id).ValueGeneratedOnAdd();
        }

    }
}
