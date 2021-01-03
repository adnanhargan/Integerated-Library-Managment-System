using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class LibraryAsset
    {
        public int ID { get; private set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public int Year { get; set; }

        [Required]
        public Status Status { get; set; }

        [Required]
        public decimal Cost { get; set; }
        public string ImgURL { get; set; }
        public int NoOfCopies { get; set; }
        public virtual LibraryBranch Location { get; set; }
    }
}
