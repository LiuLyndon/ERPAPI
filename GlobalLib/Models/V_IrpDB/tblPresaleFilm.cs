using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblPresaleFilm
    {
        [Key]
        public int ID { get; set; }
        public string FilmNameTw { get; set; }
        public string FilmNameEn { get; set; }
        public DateTime SellStartDate { get; set; }
        public DateTime PersaleStartDate { get; set; }
        public DateTime PersaleEndDate { get; set; }
    }
}
