using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRptCashPaymentType
    {
        [Key]
        public int TransC_lgnNumber { get; set; }
        [Key]
        public short TransC_intSequence { get; set; }
        public DateTime? TransC_dtmDateTime { get; set; }
        public DateTime? cSearchDate { get; set; }
        public decimal? TransC_curValue { get; set; }
        public string Workstation_strCode { get; set; }
        public string TransC_strBKCardNo { get; set; }
        public string TransC_strBKCardType { get; set; }
        public string TransC_strBKSource { get; set; }
        public string TransC_strMemberId { get; set; }
        public string TransC_strMemberName { get; set; }
        public string CinOperator_strCode { get; set; }
        public string TransC_strType { get; set; }
        public string PayType_strShortDesc { get; set; }
        public string PayType_strShortDescAlt { get; set; }
    }
}
