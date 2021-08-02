using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblReportName
    {
        [Key]
        public int ID { get; set; }
        public string ReportName { get; set; }
        public string Description { get; set; }
    }
}
