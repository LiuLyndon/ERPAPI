using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRTAdmissionTimes
    {
        [Key]
        public int SessionID { get; set; }
        public string FilmCname { get; set; }
        public string FilmEname { get; set; }
        public short? FilmDuration { get; set; }
        public byte? ScreenNO { get; set; }
        public short? SeatsAvail { get; set; }
        public short? SeatsSold { get; set; }
        public short? SeatsHeld { get; set; }
        public DateTime? FilmShowTime { get; set; }
        public DateTime? FeatureTime { get; set; }
        public DateTime? FilmFinishTime { get; set; }
        public DateTime? BusinessDate { get; set; }
        public string CinOperator { get; set; }
        public DateTime? FilmPreviousFinishTime { get; set; }
        public bool? ShowStatus { get; set; }
        public bool? OpenAdmissionTimes { get; set; }
    }
}
