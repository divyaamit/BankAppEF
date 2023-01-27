using BankAppEF.Data.Entities.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Transactions;

namespace BankAppEF.Datalayer.Models
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public int CustomerZipCode { get; set;}
        public string CustomerCountry { get; set; }
        public string CustomerAccountNo { get; set; }
        public float CustomerBalance { get; set; }
        public string CustomerIFSC { get; set; }
        public string CustomerSSN { get; set; }
        //public virtual Transaction Transaction { get; set; }

        public List<Data.Entities.Models.Transaction> Transactions { get; set; }
        //public virtual ICollection<Transaction> ReceiverId { get; set; }
    }
}
