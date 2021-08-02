using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblMenuCinema
    {
        [Key]
        public int ID { get; set; }
        public string Operator { get; set; }
        public string DepartID { get; set; }
        public string UserID { get; set; }
    }
}
