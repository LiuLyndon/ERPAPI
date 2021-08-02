using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class vieshowtblSTDailyReport
    {
        [Key]
        public string DateAndName { get; set; }
        public int? NoOfSessions { get; set; }
        public int? FullCapacity { get; set; }
        public int? Admission { get; set; }
        public double? AverageAdmission { get; set; }
        public double? AdmissionRevenue { get; set; }
        public double? ConncessionRevenue { get; set; }
        public double? OtherRevenue { get; set; }
        public DateTime? RealShowDate { get; set; }
    }
}
