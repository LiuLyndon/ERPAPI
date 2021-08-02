using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.Drawing;

// ExportAsFixedFormat with Excel fails
// https://stackoverflow.com/questions/4408538/exportasfixedformat-with-excel-fails
namespace GlobalLib
{
    /// <summary>
    /// Excel Format
    /// </summary>
    public class EPPlusFormat
    {
        /// <summary>
        /// 設定必要的物件
        /// 按照順序分別是Application > Workbook > Worksheet > Range > Cell
        /// (1) Application ：代表一個 Excel 程序
        /// (2) WorkBook ：代表一個 Excel 工作簿
        /// (3) WorkSheet ：代表一個 Excel 工作表，一個 WorkBook 包含好幾個工作表
        /// (4) Range ：代表 WorkSheet 中的多個單元格區域
        /// (5) Cell ：代表 WorkSheet 中的一個單元格
        /// Creae an Excel application instance
        /// https://www.add-in-express.com/creating-addins-blog/2013/11/05/release-excel-com-objects/
        /// </summary>
        /// <summary>
        /// 代表一個 Excel 工作簿
        /// </summary>
        protected ExcelWorksheet ws { get; set; }

        /// <summary>
        /// Set Value 設定值: get_Range(Area).Value
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="sSArea">Start Area</param>
        /// <param name="sEArea">End Area</param>
        /// <param name="sValue">Set Value</param>
        public void SetValue(ExcelWorksheet XlWorkSheet,
                            string InSArea,
                            string InEArea,
                            object InValue)
        {
            // Range() is faster than Range[]
            // http://stackoverflow.com/questions/13759810/range-instead-of-get-range
            // Ways to populate data into excel via C# and excel interop (with performance comparison)
            // https://bembengarifin.wordpress.com/2014/12/27/ways-to-populate-data-into-excel-via-c-and-excel-interop-with-performance-comparison/

            //https://stackoverflow.com/questions/21229203/read-excel-using-npoi-cell-range-address/21235788
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Value = InValue;
        }

        /// <summary>
        /// Set Value 設定值: get_Range(Area).Value
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="sSArea">Start Area</param>
        /// <param name="sEArea">End Area</param>
        /// <param name="sValue">Set Value</param>
        public void SetValue(ExcelWorksheet XlWorkSheet,
                            int InCol,
                            int InRow,
                            object InValue)
        {
            XlWorkSheet.Cells[InRow, InCol].Value = InValue;
        }

        /// <summary>
        /// Set Value 設定值: get_Range(Area).Value
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="sSArea">Start Area</param>
        /// <param name="sEArea">End Area</param>
        /// <param name="sValue">Set Value</param>
        public void SetValue(ExcelWorksheet XlWorkSheet,
                            int InFromRow,
                            int InFromCol,
                            int InToRow,
                            int InToCol,
                            object InValue)
        {
            XlWorkSheet.Cells[InFromRow, InFromCol, InToRow, InToCol].Value = InValue;
        }

        /// <summary>
        /// Set Value 設定值: get_Range(Area).Value
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="sSArea">Start Area</param>
        /// <param name="sEArea">End Area</param>
        /// <param name="sValue">Set Value</param>
        public void SetFormula(ExcelWorksheet XlWorkSheet,
                            int InCol,
                            int InRow,
                            string InValue)
        {
            XlWorkSheet.Cells[InRow, InCol].Formula = InValue;
        }

        /// <summary>
        /// Set Value 設定值: get_Range(Area).Value
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        /// <param name="InValue">Set Value</param>
        //protected void SetHtmlValue(ExcelWorksheet XlWorkSheet,
        //                            string InSArea,
        //                            string InEArea,
        //                            string InValue)
        //{
        //    try
        //    {
        //        // http://stackoverflow.com/questions/9999713/html-text-with-tags-to-formatted-text-in-an-excel-cell
        //        //Type IeType = Type.GetTypeFromProgID("InternetExplorer.Application");
        //        //dynamic Ie = Activator.CreateInstance(IeType);

        //        InValue = InValue.Replace("\r", "<br/>");
        //        //InValue = InValue.Replace("<br>", "\r\n").Replace("<br />", "\r\n");
        //        //XlWorkSheet.get_Range(SArea, EArea).Style.IsTextWrapped = true;

        //        XlWorkSheet.get_Range(InSArea, InEArea).Value = InValue;

        //        //Ie.Visible = false;
        //        //Ie.Navigate("about:blank");
        //        //Ie.document.body.InnerHTML = XlWorkSheet.get_Range(SArea).Value;
        //        //Ie.document.body.createtextrange.execCommand("Copy", false, null);
        //        //XlWorkSheet.Paste(Destination: XlWorkSheet.get_Range(SArea));
        //        //Ie.Quit();
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //        throw;
        //    }
        //}

        /// <summary>
        /// Font Bold 粗體: get_Range(Area).Font.Bold
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void FontBold(ExcelWorksheet XlWorkSheet,
                                string InSArea,
                                string InEArea)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Font.Bold = true;
        }

        /// <summary>
        /// Font Name 設置字體的種類: get_Range(Area).Font.Name
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void FontName(ExcelWorksheet XlWorkSheet,
                                string InSArea,
                                string InEArea,
                                string FontName = "Times New Roman")
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Font.Name = FontName;
        }

        /// <summary>
        /// Font Size 設置字體大小: get_Range(Area).Style.Font.Size
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void FontSize(ExcelWorksheet XlWorkSheet,
                                string InSArea,
                                string InEArea,
                                float InSize = 11)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Font.Size = InSize;
        }
        /// <summary>
        /// Font Color 設置字體顏色: get_Range(Area).Font.Color
        /// </summary>
        /// <param name="xlWorkSheet">Excel Worksheet</param>
        /// <param name="sSArea">Start Area</param>
        /// <param name="sEArea">End Area</param>
        protected void FontColor(ExcelWorksheet XlWorkSheet,
                                string InSArea,
                                string InEArea,
                                Color InColor)
        {
            // Colors 類別
            // https://docs.microsoft.com/zh-tw/dotnet/api/system.windows.media.colors?view=netframework-4.8
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Font.Color.SetColor(InColor);
        }

        /// <summary>
        /// Interior ColorIndex 設定底色: get_Range(Area).Interior.ColorIndex
        /// </summary>
        /// <param name="xlWorkSheet">Excel Worksheet</param>
        /// <param name="sSArea">Start Area</param>
        /// <param name="sEArea">End Area</param>
        /// <param name="nColor">Color Index</param>
        protected void BackgroundColor(ExcelWorksheet XlWorkSheet,
                                        string InSArea,
                                        string InEArea,
                                        Color InColor)
        {
            // Color Palette and the 56 Excel ColorIndex Colors
            // http://dmcritchie.mvps.org/excel/colors.htm
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Fill.PatternType = ExcelFillStyle.Solid;
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Fill.BackgroundColor.SetColor(InColor);
        }

        /// <summary>
        /// Merge 儲存格合併: get_Range(Area).Merge
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void Merge(ExcelWorksheet XlWorkSheet,
                                string InSArea,
                                string InEArea)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Merge = true;
        }

        /// <summary>
        /// WrapText 自動換行: get_Range(Area).WrapText
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void WrapText(ExcelWorksheet XlWorkSheet,
                                string InSArea,
                                string InEArea)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.WrapText = true;
        }

        /// <summary>
        /// xlHAlignLeft 文本水準居*方式: Cells(SArea, EArea).HorizontalAlignment
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void HorizontalAlignment(ExcelWorksheet XlWorkSheet,
                                                string InSArea,
                                                string InEArea,
                                                ExcelHorizontalAlignment excelHorizontalAlignment)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.HorizontalAlignment = excelHorizontalAlignment;
        }

        /// <summary>
        /// xlHAlignCenter 文本水準居中方式: get_Range(Area).VerticalAlignment
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void VerticalAlignment(ExcelWorksheet XlWorkSheet,
                                            string InSArea,
                                            string InEArea,
                                            ExcelVerticalAlignment excelVerticalAlignment)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.VerticalAlignment = excelVerticalAlignment;
        }

        /// <summary>
        /// Borders 設置儲存格邊框的粗細: get_Range(Area).Borders.LineStyle
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void BordersStyleThin(ExcelWorksheet XlWorkSheet,
                                        string InSArea,
                                        string InEArea)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Border.Top.Style = ExcelBorderStyle.Thin;
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Border.Left.Style = ExcelBorderStyle.Thin;
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Border.Right.Style = ExcelBorderStyle.Thin;
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Border.Bottom.Style = ExcelBorderStyle.Thin; //設置儲存格邊框的粗細
        }

        /// <summary>
        /// BorderAround 給單元格加邊框: get_Range(Area).BorderAround
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void BorderAround(ExcelWorksheet XlWorkSheet,
                                        string InSArea,
                                        string InEArea,
                                        ExcelBorderStyle excelBorderStyle)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Border.BorderAround(excelBorderStyle,
                                                                                Color.Black); // 給單元格加邊框
        }

        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// "#,##0"
        /// </summary>
        // protected string FormatMoneyInt { get; } = "#,##0";
        /// <summary>
        /// "#,##0"
        /// </summary>
        // protected string FormatMoney { get; } = "$ #,###,###0";
        /// <summary>
        /// "#,##0.0"
        /// </summary>
        // protected string FormatMoneyDec { get; } = "#,##0.00";
        /// <summary>
        /// 0.0%, 百分比 
        /// </summary>
        // protected string FormatPercentage { get; } = "0.00%";
        /// <summary>
        /// 0.0%, 百分比 
        /// </summary>
        // protected string FormatDate { get; } = "YYYY/MM/DD HH:mm";
        /// <summary>
        /// 設置單元格式為 Format: get_Range(Area).NumberFormatLocal
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        /// <param name="InFormat">FormatMoneyInt, FormatMoneyDec, FormatPercentage</param>
        protected void NumberFormatLocal(ExcelWorksheet XlWorkSheet,
                                            string InSArea,
                                            string InEArea,
                                            string InFormat)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].Style.Numberformat.Format = InFormat;
        }

        /// <summary>
        /// AutoFit 自動調整列寬: get_Range(Area).EntireColumn.AutoFit()
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void AutoFit(ExcelWorksheet XlWorkSheet,
                                string InSArea,
                                string InEArea)
        {
            XlWorkSheet.Cells[$"{InSArea}:{InEArea}"].AutoFitColumns();
        }

        /// <summary>
        /// ColumnWidth: get_Range(Area).ColumnWidth
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        /// <param name="nWidth">Width</param>
        protected void ColumnWidth(ExcelWorksheet XlWorkSheet,
                                int SColumn,
                                int EColumn,
                                double InWidth)
        {
            for (int i = SColumn; i <= EColumn; i++)
            {
                XlWorkSheet.Column(i).Width = InWidth;
            }
            // worksheet.Column(1).Width = columnWidth;
            // worksheet.Row(1).Height = rowHeight;
        }

        /// <summary>
        /// Freeze Row and Column Headers
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InColumn">Column Number</param>
        /// <param name="InRow">Row Number</param>
        protected void Freeze(ExcelWorksheet XlWorkSheet,
                                int InColumn,
                                int InRow)
        {
            XlWorkSheet.View.FreezePanes(InRow, InColumn);
        }
#if fa
        /// <summary>
        /// Adds the comment.
        /// </summary>
        /// <param name="XlWorkSheet">The xl work sheet.</param>
        /// <param name="InSArea">The s s area.</param>
        /// <param name="InEArea">The s e area.</param>
        /// <param name="InComment">The s comment.</param>
        protected void AddComment(ExcelWorksheet XlWorkSheet,
                                    string InSArea,
                                    string InEArea,
                                    string InComment)
        {
            XlWorkSheet.get_Range(InSArea, InEArea).AddComment(InComment);
        }

        /// <summary>
        /// Set conditional formatting
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        protected void SetConditional(ExcelWorksheet XlWorkSheet,
                                        string InSArea,
                                        string InEArea)
        {
            // Set conditional formatting to alter the font if 
            // the formatConditionsRange value is less than the value in A1.
            FormatCondition condition1 =
                (FormatCondition)XlWorkSheet.get_Range(InSArea, InEArea).FormatConditions.Add(
                XlFormatConditionType.xlCellValue,
                XlFormatConditionOperator.xlLess, "0");

            condition1.Font.Bold = true;
            condition1.Font.Color = ColorTranslator.ToOle(Color.Red);
        }

        /// <summary>
        /// HiddenRow 隱藏: get_Range(Area).HiddenRow
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        /// <param name="IsHidden">if set to <c>true</c> [b hidden].</param>
        protected void HiddenRow(ExcelWorksheet XlWorkSheet,
                                        string InSArea,
                                        string InEArea,
                                        bool IsHidden)
        {
            XlWorkSheet.get_Range(InSArea, InEArea).EntireRow.Hidden = IsHidden;
        }

        /// <summary>
        /// HiddenColumn 隱藏: get_Range(Area).Hidden
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        /// <param name="IsHidden">if set to <c>true</c> [b hidden].</param>
        protected void HiddenColumn(Worksheet XlWorkSheet,
                                        string InSArea,
                                        string InEArea,
                                        bool IsHidden)
        {
            XlWorkSheet.get_Range(InSArea, InEArea).EntireColumn.Hidden = IsHidden;
        }

        /// <summary>
        /// Page Setup Orientation: 橫:xlLandscape / 直: xlPortrait
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InColumn">Column Number</param>
        /// <param name="InRow">Row Number</param>
        protected void PageSetupOrientation(ExcelWorksheet XlWorkSheet,
                                            bool InPageOrientation)
        {
            if (InPageOrientation)
            {
                XlWorkSheet.PageSetup.Orientation = XlPageOrientation.xlPortrait;
            }
            else
            {
                XlWorkSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape;
            }

            XlWorkSheet.PageSetup.CenterHorizontally = true;
            //XlWorkSheet.PageSetup.CenterVertically = true;
        }

        /// <summary>
        /// PageSetup
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        protected void PageSetup(ExcelWorksheet XlWorkSheet)
        {
#if error
             192.168.10.34 
             [Office | Excel | IIS] 筆記備忘－佈署在IIS上的Excel自動化程式，再主機帳戶未登入桌面前無法使用之處理方法(PageSetup與印表機Printer問題)
             https://dotblogs.com.tw/v6610688/2015/02/20/office_iis_excel_pagesetup_comexception_0x800a03ec_account_non_sign_in_reason

             出錯的原因－Excel的版面配置(PageSetup)與印表機
             此錯誤區塊是在我打算設定版面配置中，頁首頁尾的縮放比例，是否會維持原插入的物件比例，還是隨著Excel的版面配置比例跟著調整。
             因此，依照研判是出在Excel的版面配置功能，在程式中，便是PageSetup這個物件！

             無法設定種類 PageSetup 的 Zoom 屬性
             Description: An unhandled exception occurred during the execution of the current web request. Please review the stack trace for more information about the error and where it originated in the code. 
             Exception Details: System.Runtime.InteropServices.COMException: 無法設定種類 PageSetup 的 Zoom 屬性

             解決方法
             1. regedit 
             2. HKEY_USERS\S-1-5-18\Software\Microsoft\Windows NT\CurrentVersion\Windows
             並手動設定預設印表機
             3.   "UserSelectedDefault"=dword:00000000
                  "Device"=" Microsoft XPS Document Writer,winspool,nul:"
             上述的Device可以自行修改，這邊以XPS為例。
             或是直接把下列的機碼製作成.reg檔案直接註冊亦可。
             Windows Registry Editor Version 5.00
             [HKEY_USERS\S-1-5-18\Software\Microsoft\Windows NT\CurrentVersion\Windows]
             "UserSelectedDefault"=dword:00000000
             "Device"=" Microsoft XPS Document Writer,winspool,nul:"
             4. 最後，重新開機即可！
#endif
#if true
            //XlWorkSheet.PageSetup.Zoom = false;
            //XlWorkSheet.PageSetup.TopMargin = 0.5;
            //XlWorkSheet.PageSetup.BottomMargin = 0.5;
            //XlWorkSheet.PageSetup.LeftMargin = 1.5;
            //XlWorkSheet.PageSetup.RightMargin = 1.5;
            //XlWorkSheet.PageSetup.CenterHorizontally = true;
            //XlWorkSheet.PageSetup.CenterVertically = true;
            //XlWorkSheet.PageSetup.FitToPagesTall = 1;
            //XlWorkSheet.PageSetup.FitToPagesWide = 1;
            XlWorkSheet.PageSetup.Orientation = XlPageOrientation.xlLandscape; // 橫:xlLandscape / 直: xlPortrait
#endif
        }

        /// <summary>
        /// PageSetup
        /// </summary>
        /// <param name="xlWorkSheet">Excel Worksheet</param>
        //protected void PageSetup(ExcelWorksheet xlWorkSheet,
        //                          string Header)
        //{
            /*
            System.Reflection.Assembly CurrAssembly = System.Reflection.Assembly.LoadFrom(System.Windows.Forms.Application.ExecutablePath);
            Stream stream = CurrAssembly.GetManifestResourceStream("Oferty_BMGRP.Resources.stopka.png");
            string temp = Path.GetTempFileName();
            Image.FromStream(stream).Save(temp);

            xlWorkSheet.PageSetup.CenterFooterPicture.Filename = temp; //Application.StartupPath + "\\Resources\\stopka.png";
            xlWorkSheet.PageSetup.CenterFooterPicture.LockAspectRatio = Microsoft.Office.Core.MsoTriState.msoTrue;
            xlWorkSheet.PageSetup.CenterFooterPicture.Width = 590;
            xlWorkSheet.PageSetup.CenterFooter = "&G";
            */
            // C# 設定Excel列印選項及列印excel文件
            // https://tw.saowen.com/a/5225a12f773d76ae97546fbf1a5d5425bf82637c76766c875484fe7ae70d6220
            // C# 如何新增Excel頁首頁尾（圖片、文字、奇偶頁不同）
            // https://www.cnblogs.com/Yesi/p/9259926.html
            // How to change the font and size for Excel header and footer in C#
            // http://www.e-iceblue.com/Knowledgebase/Spire.XLS/Spire.XLS-Program-Guide/Header-and-Footer/How-to-change-the-font-and-size-for-Excel-header-and-footer-in-C.html
            //xlWorkSheet.PageSetup.RightHeader = "&\"Times New Roman\"&9" + Properties.Resources.TabulationDay + DateTime.Now.ToString("yyyy/MM/dd");
            //xlWorkSheet.PageSetup.CenterHeader = "&\"Times New Roman\"&20" + Properties.Resources.CenterHeader;

        //    try
        //    {
        //        xlWorkSheet.PageSetup.LeftHeader = Header;

        //        xlWorkSheet.PageSetup.RightHeader = string.Format($"列印時間 &D");

        //        xlWorkSheet.PageSetup.RightFooter = string.Format($"第&P頁 / 共&N頁");

        //        // 每頁都需要列印
        //        // xlWorkSheet.PageSetup.PrintTitleColumns = "$A:$B";
        //        xlWorkSheet.PageSetup.PrintTitleRows = "$1:$3";
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine(ex);
        //    }
        //}

        /// <summary>
        /// PageSetup, Freeze Row and Column Headers, Activate, ColumnWidth
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        //protected void Activate(Worksheet XlWorkSheet)
        //{
        //    // 設定工作表焦點
        //    ((_Worksheet)XlWorkSheet).Activate();
        //}

        /// <summary>
        /// PageSetup, Freeze Row and Column Headers, Activate, ColumnWidth
        /// </summary>
        /// <param name="XlWorkSheet">Excel Worksheet</param>
        /// <param name="InSArea">Start Area</param>
        /// <param name="InEArea">End Area</param>
        //protected void SetPackage(Worksheet XlWorkSheet,
        //                        string InSArea,
        //                        string InEArea,
        //                        int InWidth)
        //{
        //    // 設定工作表焦點
        //    Activate(XlWorkSheet);
        //    // ColumnWidth
        //    ColumnWidth(XlWorkSheet, InSArea, InEArea, InWidth);
        //    // Freeze Row and Column Headers
        //    Freeze(XlWorkSheet, 2, 5);
        //    // PageSetup
        //    PageSetup(XlWorkSheet);
        //}
#endif
    }
}
