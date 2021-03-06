// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PowerBiImporter.Services;

#nullable disable

namespace PowerBiImporter.Migrations
{
    [DbContext(typeof(MyDbContext))]
    [Migration("20220210144954_ToDecimal")]
    partial class ToDecimal
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("PowerBiImporter.Models.Achat", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int?>("ArticleId")
                        .HasColumnType("int");

                    b.Property<DateTime>("DateLancement")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateReception")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DateSouhaute")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FournisseurId")
                        .HasColumnType("int");

                    b.Property<string>("NumCmd")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NumFacture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("QteDemande")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("QteRecu")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ValeurAchatAvecTransport")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal?>("ValeurAchatSansTransport")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Id");

                    b.HasIndex("ArticleId");

                    b.HasIndex("FournisseurId");

                    b.ToTable("Achats");
                });

            modelBuilder.Entity("PowerBiImporter.Models.Article", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Articles");
                });

            modelBuilder.Entity("PowerBiImporter.Models.Fournisseur", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Code")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Fournisseurs");
                });

            modelBuilder.Entity("PowerBiImporter.Models.Achat", b =>
                {
                    b.HasOne("PowerBiImporter.Models.Article", "Article")
                        .WithMany()
                        .HasForeignKey("ArticleId");

                    b.HasOne("PowerBiImporter.Models.Fournisseur", "Fournisseur")
                        .WithMany()
                        .HasForeignKey("FournisseurId");

                    b.Navigation("Article");

                    b.Navigation("Fournisseur");
                });
#pragma warning restore 612, 618
        }
    }
}
