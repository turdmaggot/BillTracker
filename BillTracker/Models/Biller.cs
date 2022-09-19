using System;
using SQLite;

namespace BillTracker.Models
{
    [Table("billers")]
    public class Biller
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int BillerId { get; set; }

        [MaxLength(250)]
        public string BillerName { get; set; }

        [MaxLength(250)]
        public string BillerReferenceNo { get; set; }

        [MaxLength(250)]
        public string BillerType { get; set; }

        public DateTime DateAdded { get; set; }
    }
}

