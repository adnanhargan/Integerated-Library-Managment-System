using System;
using System.Collections.Generic;

namespace Library.Data.Models
{
    public class LibraryCard
    {
        public int ID { get; private set; }
        public decimal Fees { get; set; }
        public DateTime Created { get; set; }
        public virtual IEnumerable<Checkout> Checkouts { get; set; }
    }
}
