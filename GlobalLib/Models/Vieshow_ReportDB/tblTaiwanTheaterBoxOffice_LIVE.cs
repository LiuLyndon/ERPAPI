using System;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblTaiwanTheaterBoxOffice_LIVE
    {
        public DateTime? RealShowDate { get; set; }
        public string TheaterName { get; set; }
        public decimal? BoxOffice { get; set; }
        public int? Admission { get; set; }
    }
}
