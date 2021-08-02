using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblTicketTypeClassification
    {
        [Key]
        public int ID { get; set; }
        public string TType_strHOCode { get; set; }
        public string TType_strDescription { get; set; }
        public string TType_strDescriptionAlt { get; set; }
        public int ClassificationID { get; set; }
    }
}
