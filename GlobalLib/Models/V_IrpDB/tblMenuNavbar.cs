using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblMenuNavbar
    {
        [Key]
        public int ID { get; set; }
        public string NameOption { get; set; }
        public int Sort { get; set; }
        public string Controller { get; set; }
        public string Action { get; set; }
        public string Area { get; set; }
        public string ImageClass { get; set; }
        public string Activeli { get; set; }
        public bool Status { get; set; }
        public int ParentID { get; set; }
        public bool IsParent { get; set; }
    }
}
