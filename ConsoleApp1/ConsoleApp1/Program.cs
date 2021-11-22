using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using var context = new PropertyReportContext();
context.Database.EnsureCreated();


Section section1 = new Section() { Id = Guid.NewGuid(), Title = "Section 1" };
for (var i = 0; i < 3; i++)
{
    Paragraph paragraph = new Paragraph(); 
    paragraph.Id = Guid.NewGuid();
    paragraph.ParagraphText = $"This is Paragraph {i}";

    section1.Paragraphs.Add(paragraph);
}

PropertyReport propReport = new PropertyReport();
propReport.Id = Guid.NewGuid(); 
propReport.Sections.Add(section1);

context.PropertyReport.Add(propReport);
context.SaveChanges();


public class PropertyReportContext : DbContext
{

    public DbSet<PropertyReport> PropertyReport { get; set;  }
    //public DbSet<Section> Sections { get; set; }   
    //public DbSet<Paragraph> Paragraphs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "PropertyReport");

        base.OnConfiguring(optionsBuilder);
    }
}




