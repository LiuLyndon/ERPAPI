using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.VieShowDB
{
    public class tblFilmCategory
    {
        [Key]
        public string FilmCat_strCode { get; set; }
        public string FilmCat_strName { get; set; }
    }
}
