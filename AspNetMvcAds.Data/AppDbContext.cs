using AspNetMvcAds.Data.Entity;
using Microsoft.EntityFrameworkCore;

namespace AspNetMvcAds.Data;

public class AppDbContext : DbContext
{
    public DbSet<Advert> Adverts { get; set; }
    public DbSet<AdvertComment> AdvertComments { get; set; }
    public DbSet<AdvertImage> AdvertImages { get; set; }
    public DbSet<Category> Categories { get; set; }
    public DbSet<Setting> Settings { get; set; }
    public DbSet<User> Users { get; set; }
    public DbSet<Page> Pages { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder)
    {
        string connectionString = "Data Source=(LocalDb)\\MSSQLLocalDB; Initial Catalog=AspNetMvcAds; Integrated Security=SSPI;";

        builder.UseSqlServer(connectionString);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {

    }
}