using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblTaiwanTheaterBoxOffice
    {
        [Key]
        public DateTime RealShowDate { get; set; }
        [Key]
        public string TheaterName { get; set; }
        public decimal? BoxOffice { get; set; }
        public int? Admission { get; set; }
    }
}
