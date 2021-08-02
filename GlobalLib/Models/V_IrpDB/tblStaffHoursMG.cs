using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblStaffHoursMG
    {
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public DateTime cMovieDate { get; set; }
        public decimal Kitchen { get; set; }
        public decimal KitchenTraining { get; set; }
        public decimal Outfield { get; set; }
        public decimal OutfieldTraining { get; set; }
        public decimal Bar { get; set; }
        public decimal Total { get; set; }
    }
}
