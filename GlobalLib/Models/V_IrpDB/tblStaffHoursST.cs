using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblStaffHoursST
    {
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public DateTime cMovieDate { get; set; }
        public decimal TicketBox { get; set; }
        public decimal ShoesCollection { get; set; }
        public decimal CommodityBooth { get; set; }
        public decimal CandyBar { get; set; }
        public decimal SnowArea { get; set; }
        public decimal Bio { get; set; }
        public decimal Total { get; set; }
    }
}
