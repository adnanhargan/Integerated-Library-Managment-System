using System;
using System.ComponentModel.DataAnnotations;

namespace Library.Data.Models
{
    public class BranchHours
    {
        public int ID { get; set; }
        public LibraryBranch LibraryBranch { get; set; }

        [Range(0, 6)]
        public int DayOfWeak { get; set; }

        [Range(0, 23)]
        public int OpenTime { get; set; }

        [Range(0, 23)]
        public int CloseTime { get; set; }
    }
}
