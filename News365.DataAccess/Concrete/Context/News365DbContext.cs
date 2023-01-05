using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using News365.Entities.Concrete;

namespace News365.DataAccess.Concrete.Context;

public class News365DbContext : DbContext
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        const string ConnetDeveloper = "server=localhost ;port=3306;database=News365Db;user=root;password=0987654321;Charset=utf8;";
        optionsBuilder.UseLazyLoadingProxies()
            .UseMySql(ConnetDeveloper, ServerVersion.AutoDetect(ConnetDeveloper))
            .EnableSensitiveDataLogging()
            .ConfigureWarnings(warnings =>
            {
                warnings.Ignore(CoreEventId.LazyLoadOnDisposedContextWarning);
            });
    }

    public DbSet<Category> Categories { get; set; }
    public DbSet<NewsModel> News { get; set; }
    public DbSet<Document> Documents { get; set; }
}

