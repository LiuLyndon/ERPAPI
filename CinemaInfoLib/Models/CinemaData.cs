namespace CinemaInfoLib.Models
{
    public class CinemaData
    {
        /// <summary>
        /// Gets or sets the count Cinema.
        /// </summary>
        public int count { get; set; }
        /// <summary>
        /// Gets or sets the count database 10.34.
        /// </summary>
        public int countDB { get; set; }
        /// <summary>
        /// Gets or sets a value indicating whether this instance is same database data.
        /// </summary>
        public bool IsSameDBData
        {
            get
            {
                return count.Equals(countDB) ? true : false;
            }
        }
    }
}
