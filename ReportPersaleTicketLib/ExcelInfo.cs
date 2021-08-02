using GlobalLib;
using ReportPersaleTicketLib.Models;
using System;
using System.Collections.Generic;

namespace ReportPersaleTicketLib
{
    class ExcelInfo : EPPlusFormat
    {
        /// <summary>
        /// Start Column —
        /// </summary>
        public int SColumn { get; set; }
        /// <summary>
        /// End Column —
        /// </summary>
        public int EColumn { get; set; }
        /// <summary>
        /// Start Row |
        /// </summary>
        public int SRow { get; set; }
        /// <summary>
        /// End Row |
        /// </summary>
        public int ERow { get; set; }
        /// <summary>
        /// Start Cell Area
        /// </summary>
        public string SArea { get; set; }
        /// <summary>
        /// End Cell Area
        /// </summary>
        public string EArea { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Start Col: 1
        /// </summary>
        public int StartColumn { get; } = 1;
        /// <summary>
        /// Start Col: 1
        /// </summary>
        public int CinemaColumn
        {
            get
            {
                return StartColumn + 1;
            }
        }

        /// <summary>
        /// Table Data Start Row
        /// </summary>
        public int SDataColumn
        {
            get
            {
                return CinemaColumn + 1;
            }
        }
        /// <summary>
        /// End Data Col
        /// </summary>
        public int EDataColumn { get; set; } = 0;
        /// <summary>
        /// Total Col
        /// </summary>
        public int TotalColumn
        {
            get
            {
                return EDataColumn + 1;
            }
        }
        /// <summary>
        /// End Col (Auto)
        /// </summary>
        public int EndColumn
        {
            get
            {
                return TotalColumn;
            }
        }
        /// <summary>
        /// Start Row: 1
        /// </summary>
        public int StartRow { get; set; } = 1;
        /// <summary>
        /// Major Row: 2
        /// </summary>
        public int MajorRow
        {
            get
            {
                return StartRow + 1;
            }
        }

        /// <summary>
        /// Title Row: 3
        /// </summary>
        public int MinorRow
        {
            get
            {
                return MajorRow + 1;
            }
        }

        /// <summary>
        /// Table Data Start Row
        /// </summary>
        public int SDataRow
        {
            get
            {
                return MinorRow + 1;
            }
        }
        /// <summary>
        /// Table Data End Row
        /// </summary>
        public int EDataRow { get; set; }
        /// <summary>
        /// End Row: 1
        /// </summary>
        public int EndRow
        {
            get
            {
                return EDataRow;
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Total Data
        /// </summary>
        public Dictionary<string, string> DtTotalData { get; set; }
        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Table Column Info
        /// </summary> 
        public Dictionary<string, RangeSpace> DtFieldNameColumn { get; set; }
        /// <summary>
        /// Table Row Info
        /// </summary>
        public List<RangeSpace> lFieldNameRow { get; set; }
        /// <summary>
        /// Cinema ID Row Info
        /// </summary>
        // 06 07 08 09 10 11 12 13 14 15 16 17 18 19  20  21   22 
        // HY QS SN BT HC BC MS TE TC MM TN TD KH HGC TGC TDGC KGC
        // Add some elements to the dictionary. There are no 
        // duplicate keys, but some of the values are duplicates.
        public Dictionary<string, int> DtFieldSeatRow { get; set; }



        public Dictionary<string, int> DtRow { get; set; }

        public Dictionary<string, int> DtColumn { get; set; }

        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// A-AQ: Table Column Info
        /// 00 01 02 03 04 05 06 07 08 09 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25 26 27 28 29 30 31 32 33 34 35 36 37 38 39 40 41 42 43 44 45 46 47 48 49 50 51 52 53 54 55 56 57 58 59 60 61 62 63 64 65 66 67 68 69 70 71 72 73 74 75 76 77 78 79 
        ///  A  A  B  C  D  E  F  G  H  I  J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z  AA AB AC AD AE AF AG AH AI AJ AK AL AM AN AO AP AQ AR AS AT AU AV AW AX AY AZ BA BB BC BD BE BF BG BH BI BJ BK BL BM BN BO BP BQ BR BS BT BU BV BW BX BY BZ
        /// Add some elements to the dictionary. There are no 
        /// duplicate keys, but some of the values are duplicates.
        /// </summary>
        protected List<string> ColInfo
        {
            get
            {
                return new List<string> { "A",
                    "A",  "B",  "C",  "D",  "E",  "F",  "G",  "H",  "I",
                    "J",  "K",  "L",  "M",  "N",  "O",  "P",  "Q",  "R",
                    "S",  "T",  "U",  "V",  "W",  "X",  "Y",  "Z",
                    "AA", "AB", "AC", "AD", "AE", "AF", "AG", "AH", "AI",
                    "AJ", "AK", "AL", "AM", "AN", "AO", "AP", "AQ", "AR",
                    "AS", "AT", "AU", "AV", "AW", "AX", "AY", "AZ",
                    "BA", "BB", "BC", "BD", "BE", "BF", "BG", "BH", "BI",
                    "BJ", "BK", "BL", "BM", "BN", "BO", "BP", "BQ", "BR",
                    "BS", "BT", "BU", "BV", "BW", "BX", "BY", "BZ",
                    "CA", "CB", "CC", "CD", "CE", "CF", "CG", "CH", "CI",
                    "CJ", "CK", "CL", "CM", "CN", "CO", "CP", "CQ", "CR",
                    "CS", "CT", "CU", "CV", "CW", "CX", "CY", "CZ",
                    "DA", "DB", "DC", "DD", "DE", "DF", "DG", "DH", "DI",
                    "DJ", "DK", "DL", "DM", "DN", "DO", "DP", "DQ", "DR",
                    "DS", "DT", "DU", "DV", "DW", "DX", "DY", "DZ",
                    "EA", "EB", "EC", "ED", "EE", "EF", "EG", "EH", "EI",
                    "EJ", "EK", "EL", "EM", "EN", "EO", "EP", "EQ", "ER",
                    "ES", "ET", "EU", "EV", "EW", "EX", "EY", "EZ",
                    "FA", "FB", "FC", "FD", "FE", "FF", "FG", "FH", "FI",
                    "FJ", "FK", "FL", "FM", "FN", "FO", "FP", "FQ", "FR",
                    "FS", "FT", "FU", "FV", "FW", "FX", "FY", "FZ",
                    "GA", "GB", "GC", "GD", "GE", "GF", "GG", "GH", "GI",
                    "GJ", "GK", "GL", "GM", "GN", "GO", "GP", "GQ", "GR",
                    "GS", "GT", "GU", "GV", "GW", "GX", "GY", "GZ", };
            }
        }

        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// Assemble 組合位置: A1, B1, ...
        /// </summary>
        /// <param name="InColumn">Column Number(1~45)</param>
        /// <param name="InRow">Row Number(N)</param>
        /// <returns>String Area(A1)</returns>
        protected string Assemble(int InColumn, int InRow)
        {
            return $"{ColInfo[InColumn]}{InRow}";
        }

        /// <summary>
        /// Assemble 組合位置: A1, B1, ...
        /// </summary>
        /// <param name="InColumn">Column Number(1~45)</param>
        /// <param name="InRow">Row Number(N)</param>
        protected string Assemble(int InColumn, string InRow)
        {
            return $"{ColInfo[InColumn]}{InRow}";
        }

        /// <summary>
        /// Assemble 組合位置: A1, B1, ...
        /// </summary>
        /// <param name="nColumn">Column Number(1~45)</param>
        /// <param name="nRow">Row Number(N)</param>
        /// <returns>String Area(A1)</returns>
        protected string Assemble(string InColumn, int InRow)
        {
            return $"{InColumn}{InRow}";
        }

        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// =Sum({0}:{1})
        /// </summary>
        protected string FunctionSUM
        {
            get
            {
                return "=SUM({0}:{1})";
            }
        }
        /// <summary>
        /// "=IF({0} != 0, ({1} / {0}), 0)"
        /// </summary>
        protected string FunctionMINUS
        {
            get
            {
                return "={0}-{1}";
            }
        }
        ///////////////////////////////////////////////////////////////////////////////////
        /// <summary>
        /// "#,##0"
        /// </summary>
        protected string FormatMoneyInt
        {
            get
            {
                return "#,##0";
            }
        }
        /// <summary>
        /// "#,##0"
        /// </summary>
        protected string FormatMoney
        {
            get
            {
                return "$ #,###,###0";
            }
        }
        /// <summary>
        /// "#,##0.0"
        /// </summary>
        protected string FormatMoneyDec
        {
            get
            {
                return "#,##0.00";
            }
        }
        /// <summary>
        /// 0.0%, 百分比 
        /// </summary>
        protected string FormatPercentage
        {
            get
            {
                return "0.00%";
            }
        }

        /// <summary>
        /// 0.0%, 百分比 
        /// </summary>
        protected string FormatDate
        {
            get
            {
                return "YYYY/MM/DD HH:mm";
            }
        }
    }
}
