using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblFillUploadFile
    {
        [Key]
        public int ID { get; set; }
        public string CinOperator_strCode { get; set; }
        public DateTime cMovieDate { get; set; }
        public string FIleName { get; set; }
        public string FileContent { get; set; }
    }
}
