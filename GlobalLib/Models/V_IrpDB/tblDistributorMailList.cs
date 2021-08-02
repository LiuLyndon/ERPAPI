using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblDistributorMailList
    {
        [Required]
        public int ID { get; set; }
        public string Mail { get; set; }
        public int Sort { get; set; }
        public int MailSendPermissionID { get; set; }
        public int DistributorID { get; set; }
        public bool IsSendMail { get; set; }
    }
}
