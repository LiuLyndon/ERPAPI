using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblCalcCRChannelAnalysis
    {
        [Key]
        public int CinemaID { get; set; }
        public string DBName { get; set; }
        [Key]
        public string Abbr { get; set; }
        [Key]
        public DateTime cRealConsumptionDate { get; set; }
        public int? POSAdmissions { get; set; }
        public int? APPAdmissions { get; set; }
        public int? WWWAdmissions { get; set; }
        public int? KIOSKAdmissions { get; set; }
        public int? OTHERAdmissions { get; set; }
        public decimal? POSBoxOfficeNet { get; set; }
        public decimal? APPBoxOfficeNet { get; set; }
        public decimal? WWWBoxOfficeNet { get; set; }
        public decimal? KIOSKBoxOfficeNet { get; set; }
        public decimal? OTHERBoxOfficeNet { get; set; }
        public decimal? POSConcessionRevenuesNet { get; set; }
        public decimal? APPConcessionRevenuesNet { get; set; }
        public decimal? WWWConcessionRevenuesNet { get; set; }
        public decimal? KIOSKConcessionRevenuesNet { get; set; }
        public decimal? OTHERConcessionRevenuesNet { get; set; }
        public int? POSTransactions { get; set; }
        public int? APPTransactions { get; set; }
        public int? WWWTransactions { get; set; }
        public int? KIOSKTransactions { get; set; }
        public int? OTHERTransactions { get; set; }
    }
}
