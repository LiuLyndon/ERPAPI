using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblMailSendPermission
    {
        [Key]
        public int ID { get; set; }
        public string Permissions { get; set; }
        public string Description { get; set; }
    }
}
