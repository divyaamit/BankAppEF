namespace BankAppEF.Entities
{
    public class CustomerModel
    {
        //public int CustomerId { get; set; }
        public string CustomerFirstName { get; set; }
        public string CustomerLastName { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerContact { get; set; }
        public string CustomerAddress { get; set; }
        public string CustomerCity { get; set; }
        public string CustomerState { get; set; }
        public int CustomerZipCode { get; set; }
        public string CustomerCountry { get; set; }
        public string CustomerAccountNo { get; set; }
        public float CustomerBalance { get; set; }
        public string CustomerIFSC { get; set; }
        public string CustomerSSN { get; set; }
    }
}