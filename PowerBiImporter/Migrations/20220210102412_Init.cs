using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PowerBiImporter.Migrations
{
    public partial class Init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Type = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fournisseurs",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Code = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fournisseurs", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Achats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: true),
                    FournisseurId = table.Column<int>(type: "int", nullable: true),
                    NumFacture = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateReception = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateSouhaute = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateLancement = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumCmd = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QteRecu = table.Column<int>(type: "int", nullable: true),
                    QteDemande = table.Column<int>(type: "int", nullable: true),
                    ValeurAchatSansTransport = table.Column<decimal>(type: "decimal(18,2)", nullable: true),
                    ValeurAchatAvecTransport = table.Column<decimal>(type: "decimal(18,2)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Achats", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Achats_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Achats_Fournisseurs_FournisseurId",
                        column: x => x.FournisseurId,
                        principalTable: "Fournisseurs",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Achats_ArticleId",
                table: "Achats",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_Achats_FournisseurId",
                table: "Achats",
                column: "FournisseurId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Achats");

            migrationBuilder.DropTable(
                name: "Articles");

            migrationBuilder.DropTable(
                name: "Fournisseurs");
        }
    }
}
