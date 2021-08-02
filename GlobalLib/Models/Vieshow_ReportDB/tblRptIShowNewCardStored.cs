using System;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblRptIShowNewCardStored
    {
        public string CinOperator_strCode { get; set; }
        public DateTime cSearchDate { get; set; }
        public int? NewCardStoredValue { get; set; }
        public decimal? NewCardStoredDeposit { get; set; }
    }
}
