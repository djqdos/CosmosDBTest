using ConsoleApp1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;


//CreateData();
LoadData();


void LoadData()
{
    using(var context = new PropertyReportContext())
    {
        var stuff = context.PropertyReport
                        .Include(s => s.Sections)
                        .ThenInclude(p => p.Paragraphs).ToList();

        Console.WriteLine();
    }
}


void CreateData()
{
    // POPULATE SOME SHIZ
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
}

 

public class PropertyReportContext : DbContext
{

    public DbSet<PropertyReport> PropertyReport { get; set;  }
    public DbSet<Section> Sections { get; set; }
    public DbSet<Paragraph> Paragraphs { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseCosmos("https://localhost:8081", "C2y6yDjf5/R+ob0N8A7Cgv30VRDJIWEHLM+4QDU5DE2nQ9nDuVTqobD4b8mGGyPMbIZnqyMsEcaGQy67XIw/Jw==", "PropertyReport");

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<PropertyReport>().HasPartitionKey(x => x.Id);
        modelBuilder.Entity<Section>().HasPartitionKey(x => x.Id);
        modelBuilder.Entity<Paragraph>().HasPartitionKey(x => x.Id);
    }
}




