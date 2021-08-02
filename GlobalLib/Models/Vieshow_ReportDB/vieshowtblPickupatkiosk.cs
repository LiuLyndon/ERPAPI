namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class vieshowtblPickupatkiosk
    {
        public int? CinemasID { get; set; }
        public string CinemasName { get; set; }
        public string Abbr { get; set; }
        public string cMonth { get; set; }
        public decimal? nTotalNeedPickup { get; set; }
        public decimal? nPickupAtKiosk { get; set; }
        public decimal? niBeacon { get; set; }
    }
}
