using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Entity
{
    public partial class Book
    {
        public Book()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int BookId { get; set; }
        public string BookName { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public int Cost { get; set; }
        public string AvailableFor { get; set; }
        public int Quantity { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
