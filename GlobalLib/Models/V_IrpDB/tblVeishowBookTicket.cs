using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblVeishowBookTicket
    {
        public DateTime CategorizeDate { get; set; }
        public string Vendor { get; set; }
        public string Cinema { get; set; }
        public int BookingH_intNextBookingNo { get; set; }
        public string TaxIDNumber { get; set; }
        public string Film_strCode { get; set; }
        public string Film_strTitleAlt { get; set; }
        public DateTime cRealShowDate { get; set; }
        public DateTime Session_dtmRealShow { get; set; }
        public int Screen_bytNum { get; set; }
        public string ScreenD_strPhyRowId { get; set; }
        public string ScreenD_strSeatId { get; set; }
        public string TType_strDescriptionAlt { get; set; }
        public decimal TicketPrice { get; set; }
        public string Film_strCensor { get; set; }
        public DateTime BookingH_dtmDateCollected { get; set; }
        public string TransactionNumber { get; set; }
        public string Format { get; set; }
        public string ShopNumber { get; set; }
        public string Store { get; set; }
        public string BookingH_strBookingId { get; set; }
        public string BookingH_strSource { get; set; }
    }
}
