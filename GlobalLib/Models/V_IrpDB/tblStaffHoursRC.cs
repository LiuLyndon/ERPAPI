using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblStaffHoursRC
    {
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public DateTime cMovieDate { get; set; }
        public decimal Outfield { get; set; }
        public decimal Insidefield { get; set; }
        public decimal Training { get; set; }
        public decimal Total { get; set; }
    }
}
