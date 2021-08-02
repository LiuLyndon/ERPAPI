using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblSellNameWorkstation
    {
        [Key]
        public DateTime RefundScanDate { get; set; }
        [Key]
        public DateTime SDate { get; set; }
        [Key]
        public string User_strFirstName { get; set; }
        [Key]
        public string Workstation { get; set; }
        public decimal? Boxoffice { get; set; }
        public int? Seats { get; set; }
    }
}
