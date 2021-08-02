using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRptSessionFilm
    {
        [Key]
        public int Session_lngSessionId { get; set; }
        public string CinOperator_strCode { get; set; }
        public DateTime? Session_dtmRealShow { get; set; }
        public DateTime? Session_dtmFeature { get; set; }
        public DateTime? Session_dtmFinish { get; set; }
        public DateTime? cRealShowDate { get; set; }
        public byte? Screen_bytNum { get; set; }
        public short? Session_intSeatsAvail { get; set; }
        public short? Session_intSeatsSold { get; set; }
        public short? Session_intSeatsHouse { get; set; }
        public string Session_strStatus { get; set; }
        public string Session_strStopSales { get; set; }
        public string Film_strCode { get; set; }
        public string Film_strTitle { get; set; }
        public string Film_strTitleAlt { get; set; }
        public string Film_strCensor { get; set; }
        public short? Film_intDuration { get; set; }
        public DateTime? Film_dtmOpeningDate { get; set; }
        public string Film_strHOFilmCode { get; set; }
        public byte? Film_bytSignSequence { get; set; }
        public string FilmCat_strCode { get; set; }
        public string FilmCat_strName { get; set; }
        public string FilmCat_strCode2 { get; set; }
        public string FilmCat_strName2 { get; set; }
        public string FilmCat_strCode3 { get; set; }
        public string FilmCat_strName3 { get; set; }
        public string Distrib_strCode { get; set; }
        public string Distrib_strName { get; set; }
    }
}
