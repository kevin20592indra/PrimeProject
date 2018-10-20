using System;

namespace PrimeProject.Business.Entity
{
    public class Transaction
    {
        public Guid Id { get; set; }
        public DateTime TransactionTime { get; set; }
        public string Type { get; set; }
        public string Parameters { get; set; }
        public virtual Item Item { get; set; }
    }
}
