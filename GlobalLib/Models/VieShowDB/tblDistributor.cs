using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblDistributor
    {
        [Key]
        public string Distrib_strCode { get; set; }
        public string Distrib_strName { get; set; }
    }
}
