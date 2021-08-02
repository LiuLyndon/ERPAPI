using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRefundScan
    {
        public string User_strFirstName { get; set; }
        public string Workstation { get; set; }
        [Key]
        public string lgnNumberSequence { get; set; }
        public DateTime? Session_dtmRealShow { get; set; }
        public DateTime? TransI_dtmDateTime { get; set; }
        public DateTime? TransactionDateTime { get; set; }
        public decimal? TransI_curValueEach { get; set; }
        public DateTime? UserLog_dtmDateRec { get; set; }
        public string TransT_strReportCode { get; set; }
        public string strAuthorisingUser { get; set; }
        public int? TransT_lgnNumber { get; set; }
        public int? TransT_intSequence { get; set; }
        public int? TransT_intSeqRefunded { get; set; }
        public byte? Screen_bytNum { get; set; }
        public string ScreenD_strPhyRowId { get; set; }
        public string ScreenD_strSeatId { get; set; }
        public short? User_intUserNo { get; set; }
        public string CinOperator_strCode { get; set; }
        public string TType_strDescription { get; set; }
        public string TType_strDescriptionAlt { get; set; }
        public string Film_strTitle { get; set; }
        public string Film_strTitleAlt { get; set; }
        public string Film_strCensor { get; set; }
        public string BookingH_strSource { get; set; }
    }
}
