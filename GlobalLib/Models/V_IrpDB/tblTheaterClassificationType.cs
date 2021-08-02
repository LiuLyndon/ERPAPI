using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblTheaterClassificationType
    {
        [Key]
        public int ID { get; set; }
        public string Classification { get; set; }
        public int Sort { get; set; }
    }
}
