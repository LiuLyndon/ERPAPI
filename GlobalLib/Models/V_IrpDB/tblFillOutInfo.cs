using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblFillOutInfo
    {
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public DateTime cMovieDate { get; set; }
        public int AdmissionForecast { get; set; }
        public int StaffPassTics { get; set; }
        public string EventComboName { get; set; }
        public int EventComboInitall { get; set; }
        public int EventComboInitAcc { get; set; }
        public int EventComboInitQty { get; set; }
        public string BoxOfficeComments { get; set; }
        public string ConcessionBusinessComments { get; set; }
        public string LabourControlComments { get; set; }
        public int TwoPersonMeal { get; set; }
        public int FourPersonMeal { get; set; }
        public int AfternoonTeaMeal { get; set; }
        public int SpecialMeal { get; set; }
        public int BusinessLunch { get; set; }
        public int SingleMeal { get; set; }
        public int PancakeMeal { get; set; }
        public int MovieDoubleMeal { get; set; }
        public int AdmissionFillIn { get; set; }
    }
}
