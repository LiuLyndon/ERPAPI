using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblMailList
    {
        [Key]
        public int ID { get; set; }
        public string Mail { get; set; }
        public int Sort { get; set; }
        public int MailSendPermissionID { get; set; }
        public int ReportNameID { get; set; }
        public bool IsSendMail { get; set; }
    }
}
