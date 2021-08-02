using System.Collections.Generic;

namespace ReportPersaleTicketLib.Models
{
    /// <summary>
    /// Range Space
    /// </summary>
    public class RangeSpace
    {
        /// <summary>
        /// Major Table Name
        /// </summary>
        public string MajorName { get; set; }
        /// <summary>
        /// Minor Table Name
        /// </summary>
        public List<string> lMinorName;
        /// <summary>
        /// The list format
        /// </summary>
        public dynamic[] lFormat;
        /// <summary>
        /// Start
        /// </summary>
        public int nS { get; set; }
        /// <summary>
        /// End
        /// </summary>
        public int nE
        {
            get
            {
                return nS + lMinorName.Count - 1;
            }
        }
    }
}
