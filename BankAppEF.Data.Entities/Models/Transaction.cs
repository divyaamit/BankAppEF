using BankApp.Data.Entities.Models;
using BankAppEF.Datalayer.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAppEF.Data.Entities.Models
{
    public class Transaction
    {        
        [Key]
        public int Id { get; set; }
        public string SenderAccNo { get; set; }
        public string RecevierAccNo { get; set; }
        public string ContactNo { get; set; }
        public string Type { get; set; }
        public float Amount { get; set;}
        public DateTime Date { get; set;}
        public string Remarks { get; set; }
        public Status status { get; set; } 
        public Account Transactions_Account { get; set; }
        public Account Transactions_Receiver_Account { get; set; }

        public enum Status
        {
            Success,
            Failure,
            Aborted,
            Timedout
        }
    }
}
