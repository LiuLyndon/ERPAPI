using CinemaInfoLib;
using Dapper;
using GlobalLib.Models.V_IrpDB;
using GlobalLib.Models.Vieshow_ReportDB;
using NLog;
using SendEmailLib.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Resources;
using System.Net.Mail;
using SendEmailLib;

namespace ReportPersaleTicketLib
{
    public class ReportPersaleTicket : IDisposable
    {
        /// <summary>
        /// Check function result
        /// </summary>
        private bool bResult = false;
        /// <summary>
        /// Save File Name
        /// </summary>
        private DateTime Dt { get; set; }
        /// <summary>
        /// Save Film Name
        /// </summary>
        public string FilmName { get; set; }
        /// <summary>
        /// Save File Name
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// Save Path
        /// </summary>
        public string SavePath { get; set; }
        /// <summary>
        /// GetFileName: {0}{1:yyyyMMdd}
        /// </summary>
        private string GetFileName
        {
            get
            {
                return "{0}-{1:yyyyMMdd}";
            }
        }
        /// <summary>
        /// Excel Extension: {0}{1}.xlsx
        /// </summary>
        private string ExcelExtension
        {
            get
            {
                return "{0}{1}.xlsx";
            }
        }
        /// <summary>
        /// 192.168.10.34:V_IrpDB
        /// </summary>
        public string IrpDBConnectionString { get; } =
            "Data Source=192.168.10.34;Initial Catalog=V_IrpDB;Persist Security Info=True;User ID=itdbuser;Password=16086448";
        /// <summary>
        /// 192.168.10.34:ReportDB
        /// </summary>
        public string ReportDBConnectionString { get; } =
            "Data Source=192.168.10.34;Initial Catalog=Vieshow_ReportDB;Persist Security Info=True;User ID=itdbuser;Password=16086448";
        /// <summary>
        /// declare Resource manager to access to specific cultureinfo
        /// </summary>
        private ResourceManager Rm { get; set; }
        /// <summary>
        /// declare culture info
        /// create culture for english
        /// https://msdn.microsoft.com/zh-tw/library/system.globalization.cultureinfo(v=vs.80).aspx
        /// </summary>
        private CultureInfo Cul { get; set; }
        /// <summary>
        /// The cinema information
        /// </summary>
        private List<tblCinemaInfo> lCinema { get; set; }
        /// <summary>
        /// Admission Data
        /// </summary>
        private List<tblCalcTicketPersale> lData { get; set; }
        /// <summary>
        /// The logger
        /// LogManager.Configuration = new XmlLoggingConfiguration(".\\NLog.config", true);
        /// </summary>
        private Logger logger { get; set; }

        #region ReportExcelDailyLib: Init, IDisposable
        /// <summary>
        /// 建構子。Init Report Excel Lib
        /// </summary>
        /// <param name="InDt">Date</param>
        public ReportPersaleTicket(DateTime InDt)
        {
            Dt = InDt;
            //此為Resource的BaseName = [Namespace].[Class].[ResourceName]
            //------------------------------------------------------------------
            // 調用 Properties.Resources 這個全域資源檔的方法如下：
            // Properties.Resources這個字串事實上是對應到方案總管之專案底下路徑：
            // 專案名稱為 showPicture，其下有 Properties 子資料夾，而於 Properties
            // 底下又有 Resources.resx 資源檔
            // 想要將專案中所需的圖檔悉數納歸資源檔來管理，做法上如下：
            // 1.點按 showPicture 專案名並按下滑鼠右鍵，=> [屬性] => 左側選單選擇 [資源]
            // 2.點按 [資源] 後，於上方功能表選擇 [加入資源]，後續瀏覽圖檔並將其加入資源中
            // 3.此時可發現專案會自動產生一個名為Resources的資料夾，所有方才加入的圖檔
            //   可見於此資料夾中
            // 4.後續可利用 ResourceManager 來調用所需的圖檔資源
            // 5.註：使用 ResourceManager 需要 using System.Resources;
            //-------------------------------------------------------------------
            Rm = new ResourceManager(typeof(Properties.Resources));
            //create culture for english
            // https://msdn.microsoft.com/zh-tw/library/system.globalization.cultureinfo(v=vs.80).aspx
            Cul = new CultureInfo("en");
            logger = LogManager.GetCurrentClassLogger();
        }
        /// <summary>
        /// 解構子。
        /// </summary>
        ~ReportPersaleTicket()
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
        /// 釋放資源
        /// </summary>
        private bool bDisposed = false;
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

        #region GetAllInformation
        /// <summary>
        /// Get Information
        /// </summary>
        /// <returns>true/false</returns>
        public bool GetInformation(string InFilmName)
        {
            FilmName = InFilmName;
            bResult = false;
            logger.Info("GetInformation:Start");

            try
            {
                using (GetCinemaInfo gci = new GetCinemaInfo())
                {
                    lCinema = gci.Execute(1, DateTime.Now);
                }


                  // SELECT TOP(1000) [ID]
                  //    ,[FilmNameTw]
                  //    ,[FilmNameEn]
                  //    ,[SellStartDate]
                  //    ,[PersaleStartDate]
                  //    ,[PersaleEndDate]
                  //              FROM[V_IrpDB].[dbo].[tblPresaleFilm]
                  //order by[SellStartDate]

                // Get DBData
                using (SqlConnection con = new SqlConnection(ReportDBConnectionString))
                {
                    DynamicParameters Param = new DynamicParameters();
                    Param.Add("@FilmName", FilmName, dbType: DbType.String);

                    lData = con.Query<tblCalcTicketPersale>(
                        $"SELECT * FROM tblCalcTicketPersale WHERE CHARINDEX(@FilmName, Film_strTitle) > 0",
                        Param,
                        commandTimeout: 0).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            logger.Info("GetInformation:End");
            return bResult;
        }
        #endregion

        #region CreateExcel
        /// <summary>
        /// Create Excel: ReportByDay-yyyyMMdd.xlsx
        /// </summary>
        /// <returns></returns>
        public bool CreateExcel()
        {
            logger.Info("Start");

            FileName = string.Format(GetFileName, Properties.Resources.ReportName, DateTime.Now.AddDays(-1).ToString("yyyyMMdd"));
            SavePath = string.Format(ExcelExtension, Path.GetTempPath(), FileName);

            try
            {
                using (CreateExcel cExcel = new CreateExcel(logger))
                {
                    cExcel.Execute(SavePath, FilmName, lCinema, lData);
                }
            }
            catch (Exception ex)
            {
                logger.Error(ex);
                return false;
            }

            logger.Info("End");
            return true;
        }
        #endregion

        #region SendMail
        /// <summary>
        /// Sends the mail.
        /// </summary>
        /// <returns>true/false</returns>
        public bool SendMail()
        {
            List<TblReportMailList> lTblSendMailList = null;

            bResult = false;
            logger.Info("Start");

            try
            {
                using (SendEmail seLib = new SendEmail())
                {
                    // Mail From
                    seLib.MailFrom = "ops@vscinemas.com.tw";

                    lTblSendMailList = seLib.GetReportMailList(IrpDBConnectionString,
                                                                Properties.Resources.ReportName);

                    if (lTblSendMailList != null)
                        foreach (TblReportMailList item in lTblSendMailList.Where(w => w.IsSendMail.Equals(true)))
                        {
#if true
                            if (item.MailSendPermissionID.Equals(1))
                                seLib.lMailTos.Add(item.Mail);
                            else if (item.MailSendPermissionID.Equals(2))
                                seLib.lCcMailList.Add(item.Mail);
                            else // 密件副本
#endif
                                seLib.lBccMailList.Add(item.Mail);
                        }

                    // 附件
                    Attachment file = null;
                    file = new Attachment(SavePath);
                    seLib.lAttachment.Add(file);

                    // 信件主旨
                    seLib.Subject = FileName;
                    // 信件內容
                    seLib.Body = FileName;

                    seLib.SendMail();
                }

                bResult = true;
            }
            catch (Exception ex)
            {
                logger.Error(ex);
            }

            logger.Info("End");
            return bResult;
        }
        #endregion
    }
}
