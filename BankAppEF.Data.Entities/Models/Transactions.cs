using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Data.Entities.Models
{
    public class Transactions
    {
        [Key]
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionAmount { get; set;}
        public DateTime TransactionDate { get; set;}

    }
}
