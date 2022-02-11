using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using OfficeOpenXml;
using PowerBiImporter.Models;
using PowerBiImporter.Services;

namespace PowerBiImporter
{
    public partial class Form1 : Form
    {
        private string _inputPath;
        private List<string>? _processedFiles;
        public Form1()
        {
            InitializeComponent();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private async void WorkButton_Click(object sender, EventArgs e)
        {
            _inputPath = inputPathI.Text;
            try
            {
                await ScheduleWork();
            }
            catch (KnownException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.ToString());
            }
        }

        void Log(string s)
        {
            if (LogBox.Text.Length > 450000)
                LogBox.Text = "";
            LogBox.AppendText(s + "\r\n");
        }

        async Task ScheduleWork()
        {
            var startDate = startDateI.Value;
            if (DateTime.Now > startDate)
                throw new KnownException($"Date can't be older than now");

            var timeToWait = (startDate - DateTime.Now).TotalMilliseconds;
            Log($"We will run in {(startDate - DateTime.Now).TotalMinutes:#0.00} minutes");
            await Task.Delay((int)timeToWait);

            do
            {
                try
                {
                    _ = Work();
                }
                catch (KnownException ex)
                {
                    Log(ex.Message);
                }
                catch (Exception exception)
                {
                    Log(exception.ToString());
                }
                Log($"Next run at : {DateTime.Now.AddDays(7):d} minutes");
                await Task.Delay(1000 * 60 * 60 * 24 * 7);
            } while (true);
        }

        async Task Work()
        {
            if (!File.Exists("processedFiles.json"))
            {
                _processedFiles = new List<string>();
            }
            else
            {
                _processedFiles = JsonConvert.DeserializeObject<List<string>>(await File.ReadAllTextAsync("processedFiles.json")) ?? new List<string>();
            }

            foreach (var file in Directory.GetFiles(_inputPath))
            {
                if (_processedFiles.Contains(file)) continue;
                try
                {
                    Log($"Working on {file}");
                    await WorkOnOneFile(file);
                    _processedFiles.Add(file);
                    await File.WriteAllTextAsync("processedFiles.json", JsonConvert.SerializeObject(_processedFiles,Formatting.Indented));
                }
                catch (KnownException ex)
                {
                    Log(ex.Message);
                }
                catch (Exception exception)
                {
                    Log(exception.ToString());
                }
            }
        }

        async Task WorkOnOneFile(string filePath)
        {
            var dbContext = new MyDbContext();
            var dbArticles = dbContext.Articles.ToList();
            var dbFournisseurs = dbContext.Fournisseurs.ToList();
            var package = new ExcelPackage(new FileInfo(filePath));
            var sheet = package.Workbook.Worksheets[0];
            for (int i = 1; i <= sheet.Dimension.End.Row; i++)
            {
                var fournisseurCode = sheet.Cells[i, 1].Value.ToString();
                var fournisseurName = sheet.Cells[i, 2].Value.ToString();
                var numFact = sheet.Cells[i, 4].Value.ToString();
                var dateReception = int.Parse(sheet.Cells[i, 5].Value?.ToString() ?? "0");
                var DateReception2 = new DateTime(1899, 12, 30).AddDays(dateReception);
                var codeArticle = sheet.Cells[i, 7].Value.ToString();
                var nameArticle = sheet.Cells[i, 8].Value.ToString();
                var dateSouhaite = int.Parse(sheet.Cells[i, 10].Value?.ToString() ?? "0");
                var dateSouhaite2 = new DateTime(1899, 12, 30).AddDays(dateSouhaite);
                var dateLancement = int.Parse(sheet.Cells[i, 12].Value?.ToString() ?? "0");
                var dateLancement2 = new DateTime(1899, 12, 30).AddDays(dateLancement);
                var numcmd = sheet.Cells[i, 15].Value.ToString();
                var qteRecu = decimal.Parse(sheet.Cells[i, 17].Value?.ToString() ?? "0.0");
                var qtedemande = decimal.Parse(sheet.Cells[i, 18].Value?.ToString() ?? "0.0");
                var valAchatAvecTrans = decimal.Parse(sheet.Cells[i, 19].Value?.ToString() ?? "0.0");
                var valAchatSansTrans = decimal.Parse(sheet.Cells[i, 20].Value?.ToString() ?? "0.0");

                //New Articles
                var article = dbArticles.FirstOrDefault(x => x.Code == codeArticle);
                if (article == null)
                {
                    article = new Article()
                    {
                        Code = codeArticle,
                        Name = nameArticle
                    };
                    dbContext.Articles.Add(article);
                    await dbContext.SaveChangesAsync();
                }

                var fournisseur = dbFournisseurs.FirstOrDefault(x => x.Code == fournisseurCode);
                if (fournisseur == null)
                {
                    fournisseur = new Fournisseur()
                    {
                        Code = fournisseurCode,
                        Name = fournisseurName
                    };
                    dbContext.Fournisseurs.Add(fournisseur);
                    await dbContext.SaveChangesAsync();
                }

                var achat = new Achat()
                {
                    Fournisseur = fournisseur,
                    Article = article,
                    NumCmd = numcmd,
                    QteDemande = qtedemande,
                    NumFacture = numFact,
                    QteRecu = qteRecu,
                    ValeurAchatAvecTransport = valAchatAvecTrans,
                    ValeurAchatSansTransport = valAchatSansTrans,
                    DateLancement = dateLancement2,
                    DateReception = DateReception2,
                    DateSouhaute = dateSouhaite2
                };
                dbContext.Achats.Add(achat);
            }
            Debug.WriteLine("Saving change");
            await dbContext.SaveChangesAsync();
            Log($"{filePath} completed");
        }

        private async void ClearDbButton_Click(object sender, EventArgs e)
        {
            var dbContext = new MyDbContext();
            await dbContext.Database.ExecuteSqlRawAsync("TRUNCATE TABLE Achats;");
            await dbContext.Database.ExecuteSqlRawAsync("delete from Fournisseurs;");
            await dbContext.Database.ExecuteSqlRawAsync("delete from Articles;");


            MessageBox.Show("Db Cleared");
        }
    }
}