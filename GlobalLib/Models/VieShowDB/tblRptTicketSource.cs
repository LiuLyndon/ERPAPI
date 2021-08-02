using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRptTicketSource
    {
        [Key]
        public int TransT_lgnNumber { get; set; }
        [Key]
        public short TransT_intSequence { get; set; }
        public string TransT_strTicketNumber { get; set; }
        public DateTime? TransT_dtmDateTimeMIN { get; set; }
        public DateTime? TransT_dtmDateTimeMAX { get; set; }
        public DateTime? Session_dtmRealShow { get; set; }
        public DateTime? cRealShowDate { get; set; }
        public short? TransT_intNoOfSeats { get; set; }
        public byte? Screen_bytNum { get; set; }
        public string ScreenD_strPhyRowId { get; set; }
        public string ScreenD_strSeatId { get; set; }
        public string Price_strCode { get; set; }
        public decimal? TicketPrice { get; set; }
        public decimal? TicketTaxAmount { get; set; }
        public decimal? TicketTaxAmount2 { get; set; }
        public decimal? TicketTaxAmount3 { get; set; }
        public decimal? TicketTaxAmount4 { get; set; }
        public decimal? TransT_curFullPrice { get; set; }
        public decimal? TransT_curValueEach { get; set; }
        public decimal? TransT_curRedempValueEach { get; set; }
        public string TransT_strBarcodeMember { get; set; }
        public string TransT_strBarcodeRedemp { get; set; }
        public string CinOperator_strCode { get; set; }
        public string TType_strHOCode { get; set; }
        public string TType_strDescription { get; set; }
        public string TType_strDescriptionAlt { get; set; }
        public int? Session_lngSessionId { get; set; }
        public string Film_strCode { get; set; }
        public string Film_strTitle { get; set; }
        public string Film_strTitleAlt { get; set; }
        public string Film_strCensor { get; set; }
        public string BookingH_strSource { get; set; }
        public string BookingH_strPickupWorkstn { get; set; }
        public string BookingH_strBookedWorkstn { get; set; }
        public int? BookingH_intNextBookingNo { get; set; }
        public DateTime? BookingH_dtmDateCollected { get; set; }
        public DateTime? cSearchDate { get; set; }
    }
}
