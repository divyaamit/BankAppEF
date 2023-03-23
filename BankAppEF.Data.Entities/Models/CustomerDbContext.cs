using BankApp.Data.Entities.Models;
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
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=TL542;Initial Catalog=BankNew;Integrated Security=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>()
                .HasOne(b => b.Customer)
                .WithMany(bu => bu.Accounts)
                .HasForeignKey(b => b.Id);

            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(b => b.Transactions_Account)
                .WithMany(bu => bu.Transaction)
                .HasForeignKey(b => b.SenderAccNo);

            modelBuilder.Entity<Transaction>()
                .HasOne<Account>(b => b.Transactions_Receiver_Account)
                .WithMany()
                .HasForeignKey(b => b.RecevierAccNo)
                .OnDelete(DeleteBehavior.NoAction);
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Executive> Executives { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Account> Accounts { get; set; }


    }
}
