using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblSpecialWeekByYear
    {
        [Required]
        public DateTime AimDate { get; set; }
        public int AimYear { get; set; }
        public int AimWeek { get; set; }
    }
}
