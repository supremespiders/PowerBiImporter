namespace PowerBiImporter.Models;

public class Achat
{
    public int Id { get; set; }
    public Article? Article { get; set; }
    public int? ArticleId { get; set; }
    public Fournisseur? Fournisseur { get; set; }
    public int? FournisseurId { get; set; }
    public string? NumFacture { get; set; }
    public DateTime DateReception { get; set; }
    public DateTime DateSouhaute { get; set; }
    public DateTime DateLancement { get; set; }
    public string? NumCmd { get; set; }
    public decimal? QteRecu { get; set; }
    public decimal? QteDemande { get; set; }
    public decimal? ValeurAchatSansTransport { get; set; }
    public decimal? ValeurAchatAvecTransport { get; set; }
}