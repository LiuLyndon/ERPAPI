using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblTicketType
    {
        [Key]
        public string TType_strCode { get; set; }
        public string TType_strDescription { get; set; }
        public string TType_strDescriptionAlt { get; set; }
        public string TType_strHOCode { get; set; }
    }
}
