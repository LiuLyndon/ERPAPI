using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRptBookingInventory
    {
        [Key]
        public int TransI_lgnNumber { get; set; }
        [Key]
        public short TransI_intSequence { get; set; }
        public DateTime? TransI_dtmDateTime { get; set; }
        public DateTime? cSearchDate { get; set; }
        public decimal? TransI_curValueEach { get; set; }
        public decimal? TransI_curSTaxEach { get; set; }
        public decimal? TransI_curNetTotal { get; set; }
        public string CinOperator_strCode { get; set; }
        public decimal? TransI_decActualNoOfItems { get; set; }
        public string Item_strBarcode { get; set; }
        public string Item_strItemId { get; set; }
        public short? TransI_intPackageGroupNo { get; set; }
        public string TransI_strParentItem_strItemId { get; set; }
        public string BookingH_strSource { get; set; }
        public int? TransI_lngSessionId { get; set; }
        public DateTime? Session_dtmRealShow { get; set; }
        public DateTime? cRealShowDate { get; set; }
        public DateTime? cRealConsumptionDate { get; set; }
    }
}
