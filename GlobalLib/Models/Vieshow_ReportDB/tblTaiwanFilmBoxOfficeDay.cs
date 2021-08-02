using System;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblTaiwanFilmBoxOfficeDay
    {
        public string FilmNameTw { get; set; }
        public string FilmNameUs { get; set; }
        public short? CinemaNumber { get; set; }
        public int? Admission { get; set; }
        public int? BoxOffice { get; set; }
        public DateTime RealShowDate { get; set; }
        public short RegionSelected { get; set; }
    }
}
