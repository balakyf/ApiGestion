using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace ApiGestion.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(nullable: true),
                    NormalizedUserName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    NormalizedEmail = table.Column<string>(nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Categorie",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    CategorieMere = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categorie", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Client",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenon = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    TypeClient = table.Column<int>(nullable: false),
                    SecteurActivite = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Client", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Configuration",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Devise = table.Column<string>(nullable: true),
                    ImprimanteTicketId = table.Column<int>(nullable: false),
                    ImprimannetFactureId = table.Column<int>(nullable: false),
                    AdresseServeurBD = table.Column<string>(nullable: true),
                    NomServeurBD = table.Column<string>(nullable: true),
                    UserBD = table.Column<string>(nullable: true),
                    PasswordDB = table.Column<string>(nullable: true),
                    TypeDeFormat = table.Column<string>(nullable: true),
                    LecteurCodeBarre = table.Column<string>(nullable: true),
                    TVA = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Configuration", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "DetailStock",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DetailStock", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Etablissement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomLong = table.Column<string>(nullable: true),
                    NomCourt = table.Column<string>(nullable: true),
                    Telephone = table.Column<string>(nullable: true),
                    Adresse = table.Column<string>(nullable: true),
                    Fax = table.Column<string>(nullable: true),
                    NIF = table.Column<string>(nullable: true),
                    NumeroDeCompte = table.Column<int>(nullable: false),
                    Logo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Etablissement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Evenement",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    LIbelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Evenement", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TypeOperation",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Libelle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TypeOperation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Produit",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    NomArticle = table.Column<string>(nullable: true),
                    CategorieId = table.Column<Guid>(nullable: false),
                    CodeBarre = table.Column<string>(nullable: true),
                    QuantiteEnStock = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produit", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produit_Categorie_CategorieId",
                        column: x => x.CategorieId,
                        principalTable: "Categorie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Operateu",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Nom = table.Column<string>(nullable: true),
                    Prenom = table.Column<string>(nullable: true),
                    Sexe = table.Column<int>(nullable: false),
                    Login = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    RoleId = table.Column<Guid>(nullable: false),
                    Telephone = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Operateu", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Operateu_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventLog",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    OperateurId = table.Column<Guid>(nullable: false),
                    EvenementId = table.Column<Guid>(nullable: false),
                    Statut = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventLog", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EventLog_Evenement_EvenementId",
                        column: x => x.EvenementId,
                        principalTable: "Evenement",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventLog_Operateu_OperateurId",
                        column: x => x.OperateurId,
                        principalTable: "Operateu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Stock",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrixAchat = table.Column<int>(nullable: false),
                    PrixVente = table.Column<int>(nullable: false),
                    TypeOperationId = table.Column<Guid>(nullable: false),
                    OperateurId = table.Column<Guid>(nullable: false),
                    Date = table.Column<DateTime>(nullable: false),
                    StockSeuil = table.Column<int>(nullable: false),
                    DetailStockId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Stock", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Stock_DetailStock_DetailStockId",
                        column: x => x.DetailStockId,
                        principalTable: "DetailStock",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_Operateu_OperateurId",
                        column: x => x.OperateurId,
                        principalTable: "Operateu",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Stock_TypeOperation_TypeOperationId",
                        column: x => x.TypeOperationId,
                        principalTable: "TypeOperation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    OperationId = table.Column<Guid>(nullable: false),
                    OperateurId = table.Column<Guid>(nullable: false),
                    DateOperation = table.Column<DateTime>(nullable: false),
                    PrixVenteTotal = table.Column<int>(nullable: false),
                    PanierId = table.Column<Guid>(nullable: false),
                    ReferenceTransaction = table.Column<int>(nullable: false),
                    ReferenceClient = table.Column<int>(nullable: false),
                    Remise = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vente", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Panier",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    ProduitId = table.Column<Guid>(nullable: false),
                    VenteId = table.Column<Guid>(nullable: false),
                    PrixVente = table.Column<int>(nullable: false),
                    PrixAchat = table.Column<int>(nullable: false),
                    Quantite = table.Column<int>(nullable: false),
                    Remise = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Panier", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Panier_Produit_ProduitId",
                        column: x => x.ProduitId,
                        principalTable: "Produit",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Panier_Vente_VenteId",
                        column: x => x.VenteId,
                        principalTable: "Vente",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_EvenementId",
                table: "EventLog",
                column: "EvenementId");

            migrationBuilder.CreateIndex(
                name: "IX_EventLog_OperateurId",
                table: "EventLog",
                column: "OperateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Operateu_RoleId",
                table: "Operateu",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_ProduitId",
                table: "Panier",
                column: "ProduitId");

            migrationBuilder.CreateIndex(
                name: "IX_Panier_VenteId",
                table: "Panier",
                column: "VenteId");

            migrationBuilder.CreateIndex(
                name: "IX_Produit_CategorieId",
                table: "Produit",
                column: "CategorieId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_DetailStockId",
                table: "Stock",
                column: "DetailStockId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_OperateurId",
                table: "Stock",
                column: "OperateurId");

            migrationBuilder.CreateIndex(
                name: "IX_Stock_TypeOperationId",
                table: "Stock",
                column: "TypeOperationId");

            migrationBuilder.CreateIndex(
                name: "IX_Vente_PanierId",
                table: "Vente",
                column: "PanierId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vente_Panier_PanierId",
                table: "Vente",
                column: "PanierId",
                principalTable: "Panier",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Produit_ProduitId",
                table: "Panier");

            migrationBuilder.DropForeignKey(
                name: "FK_Panier_Vente_VenteId",
                table: "Panier");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "Client");

            migrationBuilder.DropTable(
                name: "Configuration");

            migrationBuilder.DropTable(
                name: "Etablissement");

            migrationBuilder.DropTable(
                name: "EventLog");

            migrationBuilder.DropTable(
                name: "Stock");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Evenement");

            migrationBuilder.DropTable(
                name: "DetailStock");

            migrationBuilder.DropTable(
                name: "Operateu");

            migrationBuilder.DropTable(
                name: "TypeOperation");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Produit");

            migrationBuilder.DropTable(
                name: "Categorie");

            migrationBuilder.DropTable(
                name: "Vente");

            migrationBuilder.DropTable(
                name: "Panier");
        }
    }
}
