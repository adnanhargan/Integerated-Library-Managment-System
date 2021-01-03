﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class Checkout
    {
        public int ID { get; set; }

        [Required]
        public LibraryAsset LibraryAsset { get; set; }
        public LibraryCard LibraryCard { get; set; }
        public DateTime Since { get; set; }
        public DateTime Until { get; set; }
    }
}