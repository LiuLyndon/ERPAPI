using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblCalcCandybarItem
    {
        [Key]
        public DateTime cRealConsumptionDate { get; set; }
        public decimal? TransI_decActualNoOfItems { get; set; }
        public decimal? ItemNetTotal { get; set; }
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public string Item_strItemId { get; set; }
        public string Item_strItemDescriptionAlt { get; set; }
        public string Item_strItemDescription { get; set; }
        public string Class_strCode { get; set; }
        public string Class_strDescription { get; set; }
        public string Class_strCode2 { get; set; }
        public string Class_strDescription2 { get; set; }
        public string Class_strCode3 { get; set; }
        public string Class_strDescription3 { get; set; }
        public string Classification { get; set; }
        [Key]
        public string BookingH_strSource { get; set; }
    }
}
