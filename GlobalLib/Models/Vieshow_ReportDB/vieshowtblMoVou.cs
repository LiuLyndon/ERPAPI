using System;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class vieshowtblMoVou
    {
        public DateTime? cSearchDate { get; set; }
        public string Abbr { get; set; }
        public int? Admissions { get; set; }
        public decimal? BOGross { get; set; }
        public decimal? CRGross { get; set; }
        public decimal? FBCRGross { get; set; }
        public decimal? OtherCRGross { get; set; }
        public decimal? MoVouPay { get; set; }
        public decimal? FunPay { get; set; }
    }
}
