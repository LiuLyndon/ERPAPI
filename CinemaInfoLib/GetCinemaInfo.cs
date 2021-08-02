using Dapper;
using GlobalLib.Models.V_IrpDB;
using NLog;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CinemaInfoLib
{
    public class GetCinemaInfo : IDisposable
    {
        private Logger logger { get; set; }
        /// <summary>
        /// 192.168.10.34:V_IrpDB
        /// </summary>
        public string IrpDBConnectionString { get; } =
            "Data Source=192.168.10.34;Initial Catalog=V_IrpDB;Persist Security Info=True;User ID=itdbuser;Password=16086448";
        /// <summary>
        /// 建構子。
        /// </summary> 
        public GetCinemaInfo()
        {
            logger = LogManager.GetCurrentClassLogger();
        }
        /// <summary>
        /// 解構子。
        /// </summary>
        ~GetCinemaInfo()
        {
            Dispose(false);
        }

        /// <summary>
        /// 釋放資源
        /// </summary>
        private bool bDisposed = false;
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

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="QueryData">Query Data</param>
        /// <param name="Dt">Date Time.</param>
        /// <returns>
        /// true/false
        /// </returns>
        public List<tblCinemaInfo> Execute(int QueryData,
                                            DateTime Dt)
        {
            List<tblCinemaInfo> lTblCinemaInfo = null;

            try
            {
                using (SqlConnection con = new SqlConnection(IrpDBConnectionString))
                {
                    DynamicParameters Param = new DynamicParameters();
                    Param.Add("@QueryData", QueryData, dbType: DbType.Int32);
                    Param.Add("@OpenData", Dt.Date, dbType: DbType.DateTime);
                    Param.Add("@CloseData", Dt.Date, dbType: DbType.DateTime);

                    lTblCinemaInfo = con.Query<tblCinemaInfo>(
                        "SP_QueryCinema",
                        Param,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: 0).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetDBData Exception:" + ex.ToString());
                return null;
            }

            return lTblCinemaInfo;
        }

        /// <summary>
        /// Execute
        /// </summary>
        /// <param name="QueryData">The in dt.</param>
        /// <param name="SDt">Start DateTime.</param>
        /// <param name="EDt">End DateTime.</param>
        /// <returns>
        /// true/false
        /// </returns>
        public List<tblCinemaInfo> Execute(int QueryData,
                                            DateTime SDt,
                                            DateTime EDt)
        {
            List<tblCinemaInfo> lTblCinemaInfo = null;

            try
            {
                using (SqlConnection con = new SqlConnection(IrpDBConnectionString))
                {
                    DynamicParameters Param = new DynamicParameters();
                    Param.Add("@QueryData", QueryData, dbType: DbType.Int32);
                    Param.Add("@OpenData", EDt.Date, dbType: DbType.DateTime);
                    Param.Add("@CloseData", SDt.Date, dbType: DbType.DateTime);

                    lTblCinemaInfo = con.Query<tblCinemaInfo>(
                        "SP_QueryCinema",
                        Param,
                        commandType: CommandType.StoredProcedure,
                        commandTimeout: 0).ToList();
                }
            }
            catch (Exception ex)
            {
                logger.Error("GetDBData Exception:" + ex.ToString());
                return null;
            }

            return lTblCinemaInfo;
        }
    }
}
