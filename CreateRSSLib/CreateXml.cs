using NLog;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace CreateRSSLib
{
    class CreateXml : IDisposable
    {
        private Logger logger { get; set; }

        /// <summary>
        /// Create Excel
        /// </summary>
        public CreateXml(Logger InLogger)
        {
            logger = InLogger;
        }
        /// <summary>
        /// 解構子。
        /// </summary>
        ~CreateXml()
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
                            string InSheetName)
        {
            int nRow = 0;
            try
            {
         
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
