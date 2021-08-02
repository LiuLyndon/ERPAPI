using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblFilm
    {
        [Key]
        public string Film_strCode { get; set; }
        public string Film_strTitle { get; set; }
        public string Film_strTitleAlt { get; set; }
        public string Film_strCensor { get; set; }
        public byte? Film_bytSignSequence { get; set; }
        public short? Film_intDuration { get; set; }
        public DateTime? Film_dtmOpeningDate { get; set; }
        public string Film_strHOFilmCode { get; set; }
        public string FilmCat_strCode { get; set; }
        public string FilmCat_strCode2 { get; set; }
        public string FilmCat_strCode3 { get; set; }
        public string Distrib_strCode { get; set; }
    }
}
