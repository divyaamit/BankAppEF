using BankAppEF.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Data.Entities.Models
{
    public class Account
    {
        [Key]
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public float Balance { get; set; }
        public string IFSC { get; set; }
        public string SSN { get; set; }
        public int Id { get; set; }
        public Customer Customer { get; set; }
        public List<Transaction> Transaction { get; set; }
    }
}
