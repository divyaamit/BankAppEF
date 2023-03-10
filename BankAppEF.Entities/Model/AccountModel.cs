using BankAppEF.Entities.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.Entities.Model
{
    public class AccountModel
    {
        public string AccountNo { get; set; }
        public string AccountType { get; set; }
        public float Balance { get; set; }
        public string IFSC { get; set; }
        public string SSN { get; set; }
        public int Id { get; set; }
        public List<TransactionsModel> Transaction { get; set; }
    }
}
