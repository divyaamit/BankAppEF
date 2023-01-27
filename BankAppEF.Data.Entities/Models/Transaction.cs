using BankAppEF.Datalayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Data.Entities.Models
{
    public class Transaction
    {        
        [Key]
        public int TransactionId { get; set; }
        //[ForeignKey(Customer)]
        //public int CustomerTransactionID { get; set; }

        //[ForeignKey("Sender"), Column(Order = 0)]
        //public int SenderId { get; set; }
        //[ForeignKey("Receiver"), Column(Order = 1)]
        //public int ReceiverId { get; set; }
        public int? SenderId { get; set; }
        public string ContactNo { get; set; }
        public string TransactionType { get; set; }
        public string TransactionAmount { get; set;}
        public DateTime TransactionDate { get; set;}
        public string Remarks { get; set; }

        public Customer Customer { get; set; }
        
        //public virtual Customer CustomerId { get; set; }
    }
}
