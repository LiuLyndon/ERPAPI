using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_EIP
{
    public class tblDepart
    {
        [Key]
        public string cDepart_ID { get; set; }
        public string cDepart_Name_CN { get; set; }
        public string cDepart_Name_EN { get; set; }
        public string cDepart_Tel_No { get; set; }
        public string cDepart_Tel_Code { get; set; }
        public string cDepart_Fax_No { get; set; }
        public string cDepart_Address { get; set; }
        public string cDepart_Mail { get; set; }
        public string cDailyReport_CityID { get; set; }
        public string cDailyReport_CityID_GC { get; set; }
        public string cCinema_Visitors { get; set; }
        public string cCinema_VISTA_IP { get; set; }
        public string cCinema_MV_IP { get; set; }
        public string cCinema_Code { get; set; }
        public string cRSS { get; set; }
        public string cDescription { get; set; }
        public int? cShow { get; set; }
        public int? cOrder { get; set; }
        public DateTime? cDt_Update { get; set; }
        public DateTime? cDt_Insert { get; set; }
        public string cCinema_VoucherID { get; set; }
        public string cCinema_LoyaltyID { get; set; }
        public string cCinema_FinanceID { get; set; }
        public string cCinema_UserID { get; set; }
        public string cCinema_SapID { get; set; }
        public string cCinema_PaymentID { get; set; }
        public string cCinema_DepositMachineID { get; set; }
        public string cCinema_VieShowDB { get; set; }
        public string cCinema_TaxID { get; set; }
        public bool? cPhone_isOperation { get; set; }
        public bool? cPhone_isConcession { get; set; }
        public bool? cPhone_isEntertainment { get; set; }
        public bool? cPhone_isRestaurant { get; set; }
    }
}
