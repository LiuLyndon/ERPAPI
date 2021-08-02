using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblTicketClassificationType
    {
        [Key]
        public int ID { get; set; }
        public string Classification { get; set; }
        public string Description { get; set; }
    }
}
