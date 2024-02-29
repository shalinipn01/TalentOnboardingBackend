using Microsoft.EntityFrameworkCore;

namespace TalentOnboardingBackend.Models
{
    public partial class TalentDbContext : DbContext
    {
        public TalentDbContext(DbContextOptions<TalentDbContext> options) : base(options) { }

        public virtual DbSet<Customer> Customers { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Store> Stores { get; set; }
        public virtual DbSet<Sale> Sales{ get; set; }

       /* //connection for SQLite
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("Datasource=talentonboardingbackend.db");
        }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);

    }
}
