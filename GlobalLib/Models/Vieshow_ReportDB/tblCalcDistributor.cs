using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblCalcDistributor
    {
        [Key]
        public DateTime cRealShowDate { get; set; }
        [Key]
        public decimal TransT_curFullPrice { get; set; }
        public short? TransT_intNoOfSeats { get; set; }
        public decimal? TicketPrice { get; set; }
        public decimal? TicketTaxAmount { get; set; }
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public string TType_strHOCode { get; set; }
        public string TType_strDescription { get; set; }
        public string TType_strDescriptionAlt { get; set; }
        [Key]
        public string Film_strCode { get; set; }
        public string Film_strTitle { get; set; }
        public string Film_strTitleAlt { get; set; }
        public string Film_strCensor { get; set; }
        [Key]
        public string FilmCat_strName { get; set; }
        [Key]
        public string Distrib_strName { get; set; }
        [Key]
        public string BookingH_strSource { get; set; }
        public string _2D3D { get; set; }
        public string IMAX { get; set; }
        public string _4DX { get; set; }
        public string MovieVersionType { get; set; }
    }
}
