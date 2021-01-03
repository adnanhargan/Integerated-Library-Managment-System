using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Status
    {
        public int ID { get; private set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public String Description { get; set; }

    }
}
