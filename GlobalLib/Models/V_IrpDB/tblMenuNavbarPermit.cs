using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblMenuNavbarPermit
    {
        [Key]
        public int ID { get; set; }
        public int MenuNavbarID { get; set; }
        public string DepartID { get; set; }
        public string UserID { get; set; }
    }
}
