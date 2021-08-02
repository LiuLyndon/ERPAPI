using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblStaffHoursGC
    {
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public DateTime cMovieDate { get; set; }
        public decimal Hosting { get; set; }
        public decimal Training { get; set; }
        public decimal StockTake { get; set; }
        public decimal Meeting { get; set; }
        public decimal StaffMetting { get; set; }
        public decimal Kitchen { get; set; }
        public decimal KitchenSweet { get; set; }
        public decimal Vending { get; set; }
        public decimal Bar { get; set; }
        public decimal KitchenHelp { get; set; }
        public decimal MIA { get; set; }
        public decimal Other { get; set; }
        public decimal Total { get; set; }
    }
}
