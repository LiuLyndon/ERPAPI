using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblItem_Class
    {
        [Key]
        public string Class_strCode { get; set; }
        public string Class_strDescription { get; set; }
        public string Class_strOnConcReceipt { get; set; }
    }
}
