using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_EIP
{
    public class tblUser
    {
        [Key]
        public string cUser_ID { get; set; }
        public string cUser_Name_CN { get; set; }
        public string cUser_Name_EN { get; set; }
        public string cUser_Tel_Home { get; set; }
        public string cUser_Tel_Mobile { get; set; }
        public string cUser_Fax_No { get; set; }
        public string cUser_Ext { get; set; }
        public string cUser_Mail { get; set; }
        public string cUser_Img { get; set; }
        public string cUser_Domain { get; set; }
        public string cPosition_ID { get; set; }
        public string cDepart_ID { get; set; }
        public DateTime? cDt_Login { get; set; }
        public DateTime? cDt_Update { get; set; }
        public DateTime? cDt_Insert { get; set; }
        public DateTime? cDt_UpdateByHR { get; set; }
        public string cUserID_UpdateByHR { get; set; }
        public string cUser_Directory { get; set; }
    }
}
