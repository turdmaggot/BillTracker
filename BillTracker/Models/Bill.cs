using System;
using SQLite;

namespace BillTracker.Models
{
    [Table("bills")]
    public class Bill
    {
        [PrimaryKey, AutoIncrement, Column("_id")]
        public int BillId { get; set; }

        // Foreign key to Biller
        public int BillerId { get; set; }

        public DateTime DateDue { get; set; }

        public double MinAmount { get; set; }

        public double TotalAmount { get; set; }

        public bool IsPaid { get; set; }

        public DateTime DatePaid { get; set; }
    }
}

