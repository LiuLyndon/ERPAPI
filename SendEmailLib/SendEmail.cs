using Dapper;
using GlobalLib.Models.V_EIP;
using SendEmailLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;

namespace SendEmailLib
{
    /// <summary>
    /// Send Email Lib
    /// </summary>
    public class SendEmail : IDisposable
    {
        /// <summary>
        /// Check function result
        /// </summary>
        private bool bResult { get; set; } = false;
        /// <summary>
        /// Mail From
        /// </summary>
        public string MailFrom { get; set; }
        /// <summary>
        /// Mail Tos
        /// </summary>
        public List<string> lMailTos { get; set; }
        /// <summary>
        /// 副本
        /// </summary>
        public List<string> lCcMailList { get; set; }
        /// <summary>
        /// 密件副本
        /// </summary>
        public List<string> lBccMailList { get; set; }
        /// <summary>
        /// 附件
        /// </summary>
        public List<Attachment> lAttachment { get; set; }
        /// <summary>
        /// 信件主旨
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 信件內容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 信件內容
        /// </summary>
        public bool IsBodyHtml { get; set; }

        #region SendEmailLib: Init, Dispose
        /// <summary>
        /// Disposed
        /// </summary>
        private bool bDisposed { get; set; } = false;
        /// <summary>
        /// 建構子。
        /// </summary>
        public SendEmail()
        {
            MailFrom = string.Empty;
            lMailTos = new List<string>();
            lCcMailList = new List<string>();
            lBccMailList = new List<string>();
            lAttachment = new List<Attachment>();
            Subject = string.Empty;
            Body = string.Empty;
            IsBodyHtml = false;
        }

        /// <summary>
        /// 解構子。
        /// </summary>
        ~SendEmail()
        {
            Dispose(false);
        }

        /// <summary>
        /// 釋放資源(程式設計師呼叫)。
        /// </summary>
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this); //要求系統不要呼叫指定物件的完成項。
        }
        /// <summary>
        /// 釋放資源(給系統呼叫的)。
        /// </summary>        
        protected virtual void Dispose(bool IsDisposing)
        {
            if (bDisposed)
            {
                return;
            }

            if (IsDisposing)
            {
                //補充：

                //這裡釋放具有實做 IDisposable 的物件(資源關閉或是 Dispose 等..)
                //ex: DataSet DS = new DataSet();
                //可在這邊 使用 DS.Dispose();
                //或是 DS = null;
                //或是釋放 自訂的物件。
                //因為我沒有這類的物件，故意留下這段 code ;若繼承這個類別，
                //可覆寫這個函式。
            }

            bDisposed = true;
        }
        #endregion

        /// <summary>
        /// Get All Information
        /// </summary>
        /// <returns>true or false</returns>
        public List<TblReportMailList> GetDistributorMailList(string ConnectionString,
                                                              string Name)
        {
            List<TblReportMailList> lTblSendMailList = null;

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {

                    DynamicParameters Param = new DynamicParameters();
                    Param.Add("@NameEn", Name, dbType: DbType.String);

                    lTblSendMailList = con.Query<TblReportMailList>(
                        Properties.Resources.SLTblDistributorMailList,
                        Param,
                        commandTimeout: 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:{0}", ex);
                return null;
            }

            return lTblSendMailList;
        }

        /// <summary>
        /// Get All Information
        /// </summary>
        /// <returns>true or false</returns>
        public List<TblReportMailList> GetReportMailList(string ConnectionString,
                                                         string ReportName)
        {
            List<TblReportMailList> lTblSendMailList = null;

            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    DynamicParameters Param = new DynamicParameters();
                    Param.Add("@ReportName", ReportName, dbType: DbType.String);

                    lTblSendMailList = con.Query<TblReportMailList>(
                        Properties.Resources.SLTblReportMailList,
                        Param,
                        commandTimeout: 0).ToList();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:{0}", ex);
                return null;
            }

            return lTblSendMailList;
        }

        /// <summary>
        /// Get All Information
        /// </summary>
        /// <returns>true or false</returns>
        public tblDepart GetDepartMail(string ConnectionString,
                                        string DepartID)
        {
            tblDepart tdMail = null;

            // Get Depart Mail
            try
            {
                using (SqlConnection con = new SqlConnection(ConnectionString))
                {
                    DynamicParameters Param = new DynamicParameters();
                    Param.Add("@DepartID", DepartID, dbType: DbType.String);

                    // Tbl Depart
                    tdMail = con.Query<tblDepart>(
                        @$"SELECT * 
                            FROM tblDepart 
                            WHERE cDepart_ID = @DepartID",
                        Param,
                        commandTimeout: 0).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception:{0}", ex);
                return null;
            }

            return tdMail;
        }

        /// <summary>
        /// Send Mail
        /// </summary>
        /// <returns>true or false</returns>
        public bool SendMail()
        {
            // Send Mail
            SendMailFun sMail = new SendMailFun();
            if (sMail.Run(MailFrom,
                          lMailTos,
                          lCcMailList,
                          lBccMailList,
                          lAttachment,
                          Subject,
                          Body,
                          IsBodyHtml))
            {
                return true;
            }
            else
            {
                Console.WriteLine("RunCreateExcel:false");
                return false;
            }
        }
    }
}
