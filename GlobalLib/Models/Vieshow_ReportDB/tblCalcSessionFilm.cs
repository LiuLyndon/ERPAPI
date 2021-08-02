using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblCalcSessionFilm
    {
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public DateTime cRealShowDate { get; set; }
        public short? ScreenCount { get; set; }
        public short? Seats { get; set; }
        public short? Admits { get; set; }
        [Key]
        public string Film_strCode { get; set; }
        public string Film_strTitle { get; set; }
        public string Film_strTitleAlt { get; set; }
        public string Film_strCensor { get; set; }
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
