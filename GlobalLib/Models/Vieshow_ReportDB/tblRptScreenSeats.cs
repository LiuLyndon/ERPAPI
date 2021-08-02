using System;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblRptScreenSeats
    {
        public string CinOperator_strCode { get; set; }
        public DateTime? cRealShowDate { get; set; }
        public byte? Screen_bytNum { get; set; }
        public short? Session_intSeatsAvail { get; set; }
        public short? Session_intSeatsSold { get; set; }
        public short? Session_intSeatsHouse { get; set; }
        public short? Session_intSeats { get; set; }
        public short? Session_intSeatsCrisscross { get; set; }
    }
}
