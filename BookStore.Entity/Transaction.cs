using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Entity
{
    public partial class Transaction
    {
        public int TransactionId { get; set; }
        public int BookId { get; set; }
        public int UserId { get; set; }
        public int Quantity { get; set; }
        public string AvailedAs { get; set; }

        public virtual Book Book { get; set; }
        public virtual User User { get; set; }
    }
}
