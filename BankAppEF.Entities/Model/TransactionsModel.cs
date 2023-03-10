using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankAppEF.Entities.Model
{
    public class TransactionsModel
    {
        public int Id { get; set; }
        public string SenderAccNo { get; set; }
        public string RecevierAccNo { get; set; }
        public string ContactNo { get; set; }
        public string Type { get; set; }
        public float Amount { get; set; }   
        public DateTime Date { get; set; }
        public string Remarks { get; set; }

       
    }
}
