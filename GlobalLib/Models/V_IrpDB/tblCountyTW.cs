using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblCountyTW
    {
        [Key]
        public int ID { get; set; }
        public string County { get; set; }
        public string CountyEN { get; set; }
        public int List { get; set; }
    }
}
