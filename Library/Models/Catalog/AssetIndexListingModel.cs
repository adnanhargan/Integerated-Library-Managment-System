﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Library.Models.Catalog
{
    public class AssetIndexListingModel
    {
        public int Id { get; set; }
        public string ImgUrl { get; set; }
        public string Title { get; set; }
        public string AuthorOrDirector { get; set; }
        public string Type { get; set; }
        public String DeweyCallNumber { get; set; }
        public string NoOfCopies { get; set; }
    }
}