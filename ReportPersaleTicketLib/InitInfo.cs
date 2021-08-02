using GlobalLib.Models.V_IrpDB;
using GlobalLib.Models.Vieshow_ReportDB;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ReportPersaleTicketLib.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace ReportPersaleTicketLib
{
    class InitInfo: ExcelInfo
    {
        public InitInfo(int InStartRow)
        {
            StartRow = InStartRow;
        }

        #region CreatColumn Daily Info
        /// <summary>
        /// Creat Column Info
        /// </summary>
        public void CreatColumnInfo(List<string> lColumn)
        {
            int nCol = SDataColumn;

            /////////////////////////////////////////////////////////
            DtFieldNameColumn = new Dictionary<string, RangeSpace>();
            DtColumn = new Dictionary<string, int>();
            /////////////////////////////////////////////////////////
            int Col = SDataColumn;
            foreach (string item in lColumn)
            {
                DtColumn.Add(item, Col++);
            }
            /////////////////////////////////////////////////////////
            // Day Info
            DtFieldNameColumn.Add(
                "Day",
                new RangeSpace()
                {
                    MajorName = "預售票數",
                    lMinorName = lColumn,
                    lFormat = new dynamic[] { FormatMoneyInt },
                    nS = nCol
                });
            nCol = DtFieldNameColumn["Day"].nE + 1;

            EDataColumn = nCol - 1;
            /////////////////////////////////////////////////////////
            // Day Info
            DtFieldNameColumn.Add(
                "Total",
                new RangeSpace()
                {
                    MajorName = "總計",
                    lMinorName = new List<string> { "總計" },
                    lFormat = new dynamic[] { FormatMoneyInt },
                    nS = nCol
                });
            nCol = DtFieldNameColumn["Total"].nE + 1;
        }
        #endregion

        #region CreatRow Info
        /// <summary>
        /// Creat Row Info
        /// </summary>
        public void CreatRowInfo(List<tblCinemaInfo> lTblCinemaInfo)
        {
            int nRow = SDataRow;
            int nTotal = 1;
            string sTotal = string.Empty;
            /////////////////////////////////////////////////////////
            lFieldNameRow = new List<RangeSpace>();
            DtFieldSeatRow = new Dictionary<string, int>();
            DtTotalData = new Dictionary<string, string>();

            DtRow = new Dictionary<string, int>();
            /////////////////////////////////////////////////////////
            List<tblCinemaInfo> elTblCinemaInfo = lTblCinemaInfo.Select(s =>
                new tblCinemaInfo
                {
                    CinemaID = s.CinemaID,
                    Name = s.Name,
                    NameTw = s.NameTw,
                    NameEn = s.NameEn,
                    Abbr = s.Abbr,
                    Operator = s.Operator,
                    DBName = s.DBName,
                    CountyTWID = s.CountyTWID,
                    ViewList = s.ViewList,
                    VSIndustryID = s.VSIndustryID,
                    PersonInCharge = s.PersonInCharge,
                    PersonInChargeID = s.PersonInChargeID,
                    County = s.County,
                    CountyEN = s.Industry.Equals("CinemaGC") ? "GC" :
                               s.Industry.Equals("CinemaMP") ? "MP" :
                               s.CountyEN,
                    List = s.List,
                    Industry = s.Industry,
                    Classify = s.Classify,
                    Description = s.Description
                }).ToList();


            // 吳明憲, 鄒秀芳 區分 PersonInChargeID
            var gyPerson = from data in elTblCinemaInfo
                           group data by data.PersonInChargeID;

            foreach (var item in gyPerson)
            {
                // tblVSIndustry - Industry (Cinema, CinemaGC, CinemaMP)
                var gyVSI = from data in item
                            group data by data.Industry;

                foreach (var itemi in gyVSI)
                {
                    // tblCountyTW - ID
                    var gyCinemaTW = from data in itemi
                                     group data by data.CountyEN;

                    SRow = nRow;

                    #region gyCinemaTW
                    foreach (var itemc in gyCinemaTW)
                    {
                        RangeSpace rsData = new RangeSpace()
                        {
                            MajorName = itemc.Key.ToString(),
                            lMinorName = new List<string>(),
                            nS = nRow
                        };

                        foreach (var itemq in itemc)
                        {
                            rsData.lMinorName.Add(itemq.Abbr);
                            DtRow.Add(itemq.Operator, nRow);
                            DtFieldSeatRow.Add(itemq.Abbr, nRow++);
                        }

                        lFieldNameRow.Add(rsData);
                    }
                    #endregion

                    string sum = string.Empty;

                    foreach (tblCinemaInfo iteme in elTblCinemaInfo.Where(w => DtFieldSeatRow.Keys.Contains(w.Abbr)))
                    {
                        sum += string.Format("{0},", Assemble("{0}", DtFieldSeatRow[iteme.Abbr]));
                    }

                    sTotal = string.Format("Total{0}", nTotal++);
                    DtTotalData.Add(sTotal, string.Format("=Sum({0})", sum));

                    lFieldNameRow.Add(new RangeSpace()
                    {
                        MajorName = "總計",
                        lMinorName = new List<string> { string.Empty },
                        nS = nRow
                    });
                    DtFieldSeatRow.Add(sTotal, nRow++);

                    EDataRow = ERow = nRow - 1;
                }
            }
        }
        #endregion

        /// <summary>
        /// Set Init Format
        /// </summary>
        /// <param name="xlWorkSheet">Excel Worksheet</param>
        /// <param name="OFInfo">The of information.</param>
        public void SetInitFormat(ExcelWorksheet ws)
        {
            // Format
            SArea = Assemble(StartColumn, (MajorRow - 1));
            EArea = Assemble(EndColumn, EndRow);
            FontSize(ws, SArea, EArea);
            FontName(ws, SArea, EArea);
            HorizontalAlignment(ws, SArea, EArea, ExcelHorizontalAlignment.Center);
            VerticalAlignment(ws, SArea, EArea, ExcelVerticalAlignment.Center);
            BorderAround(ws, SArea, EArea, ExcelBorderStyle.Thick);
            // Cinemas / F&B, Color
            SArea = Assemble(StartColumn, MajorRow);
            EArea = Assemble(EndColumn, MinorRow);
            BackgroundColor(ws, SArea, EArea, Color.Tan);

            foreach (KeyValuePair<string, int> item in DtFieldSeatRow.Where(w => w.Key.Contains("Total")))
            {
                SRow = item.Value;
                SArea = Assemble(StartColumn, SRow);
                EArea = Assemble(EndColumn, SRow);

                BackgroundColor(ws, SArea, EArea, Color.Tan);
            }

            // Data HorizontalAlignmentRight
            SArea = Assemble(SDataColumn, SDataRow);
            EArea = Assemble(EndColumn, EndRow);
            HorizontalAlignment(ws, SArea, EArea, ExcelHorizontalAlignment.Right);
            NumberFormatLocal(ws, SArea, EArea, FormatMoneyInt);
            // Column Width
            ColumnWidth(ws, SDataColumn, EndColumn, 11);
        }

        /// <summary>
        /// Set Table Top
        /// </summary>
        /// <param name="ws">Excel Worksheet</param>
        /// <param name="OFInfo">The of information.</param>
        /// <param name="sMajorHeader">The s major header.</param>
        /// <param name="sMinorHeader">The s minor header.</param>
        public void AlterTableName(ExcelWorksheet ws,
                                    string InSheetName)
        {
            SArea = Assemble(StartColumn, StartRow);
            EArea = Assemble(EndColumn, StartRow);
            Merge(ws, SArea, EArea);
            SetValue(ws, SArea, SArea, InSheetName);
        }

        #region Set Table Top
        /// <summary>
        /// Set Table Top
        /// </summary>
        /// <param name="ws">Excel Worksheet</param>
        /// <param name="OFInfo">The of information.</param>
        /// <param name="sMajorHeader">The s major header.</param>
        /// <param name="sMinorHeader">The s minor header.</param>
        public void SetSheetColumn(ExcelWorksheet ws,
                                string InSheetName)
        {
            SArea = Assemble(StartColumn, StartRow);
            EArea = Assemble(EndColumn, StartRow);
            Merge(ws, SArea, EArea);
            SetValue(ws, SArea, SArea, InSheetName);

            SArea = Assemble(StartColumn, EndRow + 1);
            EArea = Assemble(EndColumn, EndRow + 1);
            Merge(ws, SArea, EArea);

            // Title
            foreach (KeyValuePair<string, RangeSpace> item in DtFieldNameColumn)
            {
                RangeSpace rsItem = item.Value;

                SColumn = rsItem.nS;
                EColumn = rsItem.nE;

                if (rsItem.lMinorName.Count.Equals(1) &
                    string.IsNullOrEmpty(rsItem.lMinorName[0]))
                {
                    // Major Name
                    SArea = Assemble(SColumn, MajorRow);
                    EArea = Assemble(EColumn, MinorRow);
                    // Set Value
                    WrapText(ws, SArea, SArea);
                    Merge(ws, SArea, EArea);
                    FontBold(ws, SArea, EArea);
                    SetValue(ws, SArea, SArea, rsItem.MajorName);
                }
                else
                {
                    // Major Name
                    SArea = Assemble(SColumn, MajorRow);
                    EArea = Assemble(EColumn, MajorRow);
                    // Set Value
                    WrapText(ws, SArea, SArea);
                    Merge(ws, SArea, EArea);
                    FontBold(ws, SArea, EArea);
                    SetValue(ws, SArea, SArea, rsItem.MajorName);

                    // Minor Name
                    for (int i = SColumn, j = 0; i <= EColumn; i++, j++)
                    {
                        SArea = Assemble(i, MinorRow);
                        EArea = Assemble(i, MinorRow);
                        // Set Value
                        SetValue(ws, SArea, SArea, rsItem.lMinorName[j]);
                        WrapText(ws, SArea, SArea);
                        Merge(ws, SArea, EArea);
                        // Set FontBold
                        if (rsItem.lMinorName[j].Equals("Total") ||
                            rsItem.lMinorName[j].Equals("Acc"))
                        {
                            SArea = Assemble(i, MinorRow);
                            EArea = Assemble(i, EndRow);
                            FontBold(ws, SArea, EArea);
                        }
                    }
                }

                // BorderAround
                SArea = Assemble(SColumn, MajorRow);
                EArea = Assemble(EColumn, EndRow);
                BorderAround(ws, SArea, EArea, ExcelBorderStyle.Thick);
            }

            // SetDailyTotal
            // --------------------------------------------------

            // Table Name
            SColumn = DtFieldNameColumn["Day"].nS;
            EColumn = DtFieldNameColumn["Day"].nE;

            foreach (KeyValuePair<string, int> item in DtFieldSeatRow.Where(w => w.Key.Contains("Total")))
            {
                string TotalData = DtTotalData[item.Key];
                SRow = item.Value;
                for (int c = SColumn, j = 0; c <= EColumn; c++, j++)
                {
                    SetFormula(ws, c, SRow, string.Format(TotalData, ColInfo[c]));
                }
            }

            foreach (KeyValuePair<string, int> item in DtFieldSeatRow)
            {
                SRow = item.Value;

                SetFormula(ws, TotalColumn, SRow, string.Format(FunctionSUM, Assemble(SDataColumn, SRow), Assemble(EDataColumn, SRow)));
            }
        }
        #endregion

        /// <summary>
        /// Set Daily Left
        /// </summary>
        /// <param name="xlWorkSheet">Excel Worksheet</param>
        /// <param name="OFInfo">The of information.</param>
        /// <param name="sHeader">The s header.</param>
        public void SetSheetRow(ExcelWorksheet ws)
        {
            // Cinemas
            SArea = Assemble(StartColumn, MajorRow);
            EArea = Assemble(CinemaColumn, MinorRow);
            Merge(ws, SArea, EArea);
            FontBold(ws, SArea, EArea);
            SetValue(ws, SArea, EArea, "Cinemas");
            // Title
            foreach (RangeSpace item in lFieldNameRow)
            {
                SRow = item.nS;
                ERow = item.nE;

                if (item.lMinorName.Count.Equals(1) &
                    string.IsNullOrEmpty(item.lMinorName[0]))
                {
                    // Major
                    SArea = Assemble(StartColumn, SRow);
                    EArea = Assemble(CinemaColumn, ERow);
                    Merge(ws, SArea, EArea);
                    WrapText(ws, SArea, EArea);
                    FontBold(ws, SArea, EArea);
                    SetValue(ws, SArea, EArea, item.MajorName);
                }
                else
                {
                    // Major
                    SArea = Assemble(StartColumn, SRow);
                    EArea = Assemble(StartColumn, ERow);
                    Merge(ws, SArea, EArea);
                    WrapText(ws, SArea, EArea);
                    FontBold(ws, SArea, EArea);
                    SetValue(ws, SArea, EArea, item.MajorName);

                    // Minor
                    for (int i = SRow, j = 0; i <= ERow; i++, j++)
                    {
                        SArea = Assemble(CinemaColumn, i);
                        EArea = Assemble(CinemaColumn, i);
                        SetValue(ws, SArea, EArea, item.lMinorName[j]);
                    }
                }
            }

            // Border Around
            SArea = Assemble(1, MajorRow);
            EArea = Assemble(2, EndRow);
            BorderAround(ws, SArea, EArea, ExcelBorderStyle.Thick);
        }

        /// <summary>
        /// Set Daily Left
        /// </summary>
        /// <param name="ws">Excel Worksheet</param>
        /// <param name="lCinema">List tblCinemaInfo</param>
        /// <param name="lData">List tblCalcTicketPersale</param>
        public void SetData(
                            ExcelWorksheet ws1,
                            ExcelWorksheet ws2,
                            List<tblCinemaInfo> lCinema,
                            List<tblCalcTicketPersale> lData)
        {
            List<string> lOperator = lCinema.Select(s => s.Operator).ToList();
            List<tblCalcTicketPersale> gData = lData.Where(w => lOperator.Contains(w.CinOperator_strCode))
                .GroupBy(g => new
            {
                g.cTransDateTime,
                g.CinOperator_strCode,
            }).Select(s => new tblCalcTicketPersale
            {
                cTransDateTime = s.Key.cTransDateTime,
                CinOperator_strCode = s.Key.CinOperator_strCode,
                TransT_intNoOfSeats = (short?)s.Sum(p => p.TransT_intNoOfSeats),
                TicketPrice = s.Sum(p => p.TicketPrice)
            }).ToList();

            foreach (tblCalcTicketPersale item in gData)
            {
                try
                {
                    SRow = DtRow[item.CinOperator_strCode];
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex);
                    throw;
                }
                
                SColumn = DtColumn[item.cTransDateTime.ToString("yyyy/MM/dd")];

                SetValue(ws1, SColumn, SRow, item.TicketPrice);
                SetValue(ws2, SColumn, SRow, item.TransT_intNoOfSeats);
            }
        }
    }
}
