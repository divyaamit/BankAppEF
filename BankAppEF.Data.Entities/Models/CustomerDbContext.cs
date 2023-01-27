using BankAppEF.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BankAppEF.Datalayer.Models
{
    public class AppDbContext : DbContext
    {
        //private static IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
        //                                                           .SetBasePath(Directory.GetCurrentDirectory())
        //                                                           .AddJsonFile($"appsettings.json", optional: false);



        //private static IConfiguration configuration = configurationBuilder.Build();
        public AppDbContext()
        { }
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Data Source=TL542;Initial Catalog=BankNew;Integrated Security=True; TrustServerCertificate=True");
        //}

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transaction>()
                .HasOne(b => b.Customer)
                .WithMany(bu => bu.Transactions)
                .HasForeignKey(b => b.SenderId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                //.HasPrincipalKey(b => b.CustomerId);
                //.HasConstraintName("ForeignKey_Customer_Transaction");

        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Executive> Executives { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Admin> Admin { get; set; }

      
    }
}
