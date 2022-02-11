using Microsoft.EntityFrameworkCore;
using PowerBiImporter.Models;

namespace PowerBiImporter.Services;

public class MyDbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-UVALA1V;Initial Catalog=AchatDb;Integrated Security=True;");
    }

    public DbSet<Article> Articles { get; set; }
    public DbSet<Fournisseur> Fournisseurs { get; set; }
    public DbSet<Achat> Achats { get; set; }
}