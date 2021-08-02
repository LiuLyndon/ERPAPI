using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblTaiwanFilm
    {
        public string FilmNameTw { get; set; }
        [Required]
        public string FilmNameUs { get; set; }
        public string FilmRating { get; set; }
        public string Country { get; set; }
        public string Copyright { get; set; }
        public string Publisher { get; set; }
        public int CinemaNumber { get; set; }
        public DateTime PlayDate { get; set; }
    }
}
