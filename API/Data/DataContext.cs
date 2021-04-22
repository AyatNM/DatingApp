using API.Entities;
using Microsoft.EntityFrameworkCore;


namespace API.Data
{
    //dotnet ef migrations add UserPasswordAdded -o "Data/Migrations"
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>(e =>
            {
                e.ToTable("Users");
                e.HasKey(x => x.Id);
                e.Property(x=>x.Id).ValueGeneratedOnAdd();
                e.HasIndex(x => x.UserName).IsUnique(true);
            });
            base.OnModelCreating(modelBuilder);
        }
        public DbSet<AppUser> Users { get; set; }
    }
}