using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblPaymentType
    {
        [Key]
        public string PayType_strType { get; set; }
        public string PayType_strShortDesc { get; set; }
        public string PayType_strShortDescAlt { get; set; }
    }
}
