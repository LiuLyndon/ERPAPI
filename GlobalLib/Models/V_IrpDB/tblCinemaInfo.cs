using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblCinemaInfo
    {
        [Key]
        public int CinemaID { get; set; }
        public string Name { get; set; }
        public string NameTw { get; set; }
        public string NameEn { get; set; }
        public string Abbr { get; set; }
        [Key]
        public string Operator { get; set; }
        public string DBName { get; set; }
        public int CountyTWID { get; set; }
        public int ViewList { get; set; }
        public int VSIndustryID { get; set; }
        public string IP { get; set; }
        public string DepartID { get; set; }
        public DateTime OpenDate { get; set; }
        public DateTime CloseDate { get; set; }
        public string CompanyName { get; set; }
        public string UniformInvoice { get; set; }
        public string RegistrationNumber { get; set; }
        public string PersonInCharge { get; set; }
        public string PersonInChargeID { get; set; }
        public int Permission { get; set; }
        public string TaiwanTheater { get; set; }
        /// <summary>
        /// Connection String
        /// </summary>
        public string ConnectionString
        {
            get
            {
                string password = Permission.Equals(1) ? "16086448" : "2wsxzaq!";
                return string.Format($"Data Source={IP};Initial Catalog=VISTA;Persist Security Info=True;User ID=itdbuser;Password={password}");
            }
        }
        /// <summary>
        /// Connection String: 10.34
        /// </summary>
        public string ConnectionStringCinema
        {
            get
            {
                return string.Format($"Data Source=192.168.10.34;Initial Catalog=VieShowDB_{DBName};Persist Security Info=True;User ID=itdbuser;Password=16086448");
            }
        }
        /// <summary>
        /// County
        /// </summary>
        public string County { get; set; }
        public string CountyEN { get; set; }
        public string List { get; set; }
        public string Industry { get; set; }
        public string Classify { get; set; }
        public string Description { get; set; }


    }
}
