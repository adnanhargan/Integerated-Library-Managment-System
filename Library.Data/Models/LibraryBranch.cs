using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class LibraryBranch
    {
        public int ID { get; private set; }

        [Required]
        [StringLength(30, ErrorMessage = "Limit Branch Name to 30 characters.")]
        public string BranchName { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string Telephone { get; set; }
        public String Description { get; set; }
        public DateTime OpenDate { get; set; }

        public virtual IEnumerable<Patron> Patrons { get; set; }
        public virtual IEnumerable<LibraryAsset> LibraryAssets { get; set; }
        public string ImgUrl { get; set; }
    }
}
