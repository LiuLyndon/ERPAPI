using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblVSIndustry
    {
        [Key]
        public int ID { get; set; }
        public string Industry { get; set; }
        public string Classify { get; set; }
        public string Description { get; set; }
    }
}
