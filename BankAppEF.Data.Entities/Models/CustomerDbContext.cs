using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BankAppEF.Data.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace BankAppEF.Datalayer.Models
{
    public class CustomerDbContext : DbContext
    {
        public CustomerDbContext(DbContextOptions<CustomerDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Executive> Executives { get; set; }

    }
}
