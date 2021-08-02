using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblTaiwanTheaterClassification
    {
        [Key]
        public int ID { get; set; }
        public string TheaterName { get; set; }
        public string RealTheaterName { get; set; }
        public string ClassificationID { get; set; }
        public int CountyID { get; set; }
    }
}
