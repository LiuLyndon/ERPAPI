using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRefundScanCheck
    {
        [Key]
        public DateTime RefundScanDate { get; set; }
        [Key]
        public DateTime SDate { get; set; }
        [Key]
        public DateTime EDate { get; set; }
        public bool? bCheck { get; set; }
    }
}
