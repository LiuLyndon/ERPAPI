using GlobalLib.Models.V_IrpDB;
using GlobalLib.Models.Vieshow_ReportDB;
using NLog;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ReportPersaleTicketLib
{
    class CreateExcel : ExcelInfo, IDisposable
    {
        private Logger logger { get; set; }

        /// <summary>
        /// Create Excel
        /// </summary>
        public CreateExcel(Logger InLogger)
        {
            logger = InLogger;
        }
        /// <summary>
        /// 解構子。
        /// </summary>
        ~CreateExcel()
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
        private bool IsDisposed = false;
        /// <summary>
        /// 釋放資源(給系統呼叫的)。
        /// </summary>        
        protected virtual void Dispose(bool IsDisposing)
        {
            if (IsDisposed)
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

            IsDisposed = true;
        }

        /// <summary>
        /// Executes the specified this RPT operation data.
        /// </summary>
        /// <param name="InSavePath">The in dt.</param>
        /// <param name="lData">The in rm.</param>
        /// <returns></returns>
        public bool Execute(string InSavePath,
                            string InSheetName,
                            List<tblCinemaInfo> lCinema,
                            List<tblCalcTicketPersale> lData)
        {
            try
            {
                ExcelPackage.LicenseContext = OfficeOpenXml.LicenseContext.NonCommercial; // 關閉新許可模式通知
                                                                                          // 沒設置的話會跳出 Please set the excelpackage.licensecontext property

                ////////////////////////////////////////////////////////////////////////
                // 先判斷檔案是否存在，若存在就先刪除再存檔 
                if (File.Exists(InSavePath))
                    File.Delete(InSavePath);

                //var output = new MemoryStream();
                using (ExcelPackage package = new ExcelPackage(new FileInfo(InSavePath)))
                {
                    // lData.
                    // 建立分頁, Sheet Name
                    ws = package.Workbook.Worksheets.Add($"{InSheetName}_BoxOfficeNet");
                    List<string> lColumn = lData.GroupBy(g => g.cTransDateTime)
                                                .Select(s => s.Key.ToString("yyyy/MM/dd"))
                                                .OrderBy(o => o).ToList();

                    int GLStartRow = 1;
                    // DMCINEMAInfo
                    InitInfo init = new InitInfo(GLStartRow);
                    init.CreatColumnInfo(lColumn);
                    init.CreatRowInfo(lCinema);
                    init.SetInitFormat(ws);
                    init.SetSheetColumn(ws, InSheetName);
                    init.SetSheetRow(ws);
                    //new sheet form copy 複製到目標 Execl的SheetName
                    package.Workbook.Worksheets.Add($"{InSheetName}_Admissions", package.Workbook.Worksheets[$"{InSheetName}_BoxOfficeNet"]);

                    ExcelWorksheet ws1 = package.Workbook.Worksheets[$"{InSheetName}_BoxOfficeNet"];
                    ExcelWorksheet ws2 = package.Workbook.Worksheets[$"{InSheetName}_Admissions"];
                    init.AlterTableName(ws1, "BoxOfficeNet");
                    init.AlterTableName(ws2, "Admissions");
                    init.SetData(ws1, ws2, lCinema, lData);

                    package.Save(); // 儲存 Excel
                }
                //output.Position = 0; // 如果是使用 stream 的方式讓人下載，請記得將指標移回資料起始
            }
            catch (Exception ex)
            {
                logger.Error($"Execute:{ex}");
                return false;
            }

            return true;
        }
    }
}
