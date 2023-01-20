using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Entities.Model
{
    public class TransactionsModel
    {
        public int TransactionId { get; set; }
        public string TransactionType { get; set; }
        public string TransactionAmount { get; set; }
        public DateTime TransactionDate { get; set; }
    }
}
