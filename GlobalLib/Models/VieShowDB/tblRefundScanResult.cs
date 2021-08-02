using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblRefundScanResult
    {
        [Key]
        public string sn { get; set; }
        public int error_time { get; set; }
        public bool is_reivew { get; set; }
        public bool is_check { get; set; }
        public bool is_error { get; set; }
        public bool is_recheck { get; set; }
        public bool is_reerror { get; set; }
        public bool is_close { get; set; }
        public string remark { get; set; }
        public string check_user_id { get; set; }
        public DateTime? check_time { get; set; }
        public string review_remark { get; set; }
        public string review_user_id { get; set; }
        public DateTime? review_time { get; set; }
    }
}
