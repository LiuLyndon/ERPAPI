using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblExcelPickupTicket
    {
        [Key]
        public DateTime CategorizeDate { get; set; }
        public string Vendor { get; set; }
        public string Cinema { get; set; }
        [Key]
        public int BookingH_intNextBookingNo { get; set; }
        [Key]
        public string TaxIDNumber { get; set; }
        public string Film_strCode { get; set; }
        public string Film_strTitleAlt { get; set; }
        public DateTime? cRealShowDate { get; set; }
        public DateTime? Session_dtmRealShow { get; set; }
        public byte? Screen_bytNum { get; set; }
        public string ScreenD_strPhyRowId { get; set; }
        public string ScreenD_strSeatId { get; set; }
        public string TType_strDescriptionAlt { get; set; }
        public decimal? TicketPrice { get; set; }
        public string Film_strCensor { get; set; }
        public DateTime? BookingH_dtmDateCollected { get; set; }
        public string TransactionNumber { get; set; }
        public string BusinessStatus { get; set; }
        public string ShopNumber { get; set; }
        public string Store { get; set; }
        [Key]
        public string BookingH_strBookingId { get; set; }
        public string BookingH_strSource { get; set; }
        [Key]
        public bool SellStatus { get; set; }
    }
}
