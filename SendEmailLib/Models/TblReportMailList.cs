namespace SendEmailLib.Models
{
    public class TblReportMailList
    {
        public int ID { get; set; }

        public string Mail { get; set; }

        public int Sort { get; set; }

        public int MailSendPermissionID { get; set; }

        public string Permissions { get; set; }

        /// <summary>
        /// Report Name ID
        /// </summary>
        public int ReportNameID { get; set; }
        /// <summary>
        /// Distributor ID
        /// </summary>
        public int DistributorID { get; set; }

        /// <summary>
        /// Report Name
        /// </summary>
        public string ReportName { get; set; }
        /// <summary>
        /// Distributor Name
        /// </summary>
        public string NameEn { get; set; }

        public bool IsSendMail { get; set; }

        public string SendMailInfo
        {
            get
            {
                return IsSendMail ? "寄送" : "不寄送";
            }
        }
    }
}
