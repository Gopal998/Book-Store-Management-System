using System;
using System.Collections.Generic;

#nullable disable

namespace BookStore.Entity
{
    public partial class User
    {
        public User()
        {
            Transactions = new HashSet<Transaction>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; }
        public string EmailId { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Transaction> Transactions { get; set; }
    }
}
