using System;

namespace Library.Data.Models
{
    public class Hold
    {
        public int ID { get; private set; }
        public virtual LibraryAsset LibraryAsset { get; set; }
        public virtual LibraryCard LibraryCard { get; set; }
        public DateTime HoldPlaced { get; set; }
    }
}
