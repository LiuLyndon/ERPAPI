using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblItem
    {
        [Key]
        public string Item_strItemId { get; set; }
        public string Item_strStatus { get; set; }
        public string Item_strItemDescription { get; set; }
        public string Item_strItemDescriptionAlt { get; set; }
        public string Class_strCode { get; set; }
        public string Class_strCode2 { get; set; }
        public string Class_strCode3 { get; set; }
        public string Item_strReport { get; set; }
    }
}
