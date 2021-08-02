using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.Vieshow_ReportDB
{
    public class tblCalcIShowCardPay
    {
        [Key]
        public DateTime cRealConsumptionDate { get; set; }
        [Key]
        public string DBName { get; set; }
        public int? TransCount { get; set; }
        public decimal? SumOtherPay { get; set; }
        public decimal? SumIShowPay { get; set; }
        public decimal? ActOtherPay { get; set; }
        public decimal? ActIShowPay { get; set; }
        public int? TickSeatIShowPay { get; set; }
        public decimal? BOEachGrossOtherPay { get; set; }
        public decimal? BOEachGrossIShowPay { get; set; }
        public decimal? BONetOtherPay { get; set; }
        public decimal? BONetIShowPay { get; set; }
        public decimal? CRGrossOtherPay { get; set; }
        public decimal? CRGrossIShowPay { get; set; }
        public decimal? CRNetOtherPay { get; set; }
        public decimal? CRNetIShowPay { get; set; }
        public decimal? FBGrossOtherPay { get; set; }
        public decimal? FBGrossIShowPay { get; set; }
        public decimal? FBNetOtherPay { get; set; }
        public decimal? FBNetIShowPay { get; set; }
        public decimal? OCRGrossOtherPay { get; set; }
        public decimal? OCRGrossIShowPay { get; set; }
        public decimal? OCRNetOtherPay { get; set; }
        public decimal? OCRNetIShowPay { get; set; }
        public int? Admissions { get; set; }
        public decimal? BOGross { get; set; }
        public decimal? BOEachGross { get; set; }
        public decimal? BONet { get; set; }
        public decimal? CRGross { get; set; }
        public decimal? CRNet { get; set; }
        public decimal? FBCRGross { get; set; }
        public decimal? FBCRNet { get; set; }
        public decimal? OtherCRGross { get; set; }
        public decimal? OtherCRNet { get; set; }
        public int? iShowCardLoyaltyCount { get; set; }
        public int? iShowPetCard { get; set; }
        public int? iShowPetCardReplaceMember { get; set; }
        public int? iShowPetCardNewMember { get; set; }
        public decimal? iShowCardLoyalty { get; set; }
        public int? DepositCount1000 { get; set; }
        public int? DepositCount2000 { get; set; }
        public int? DepositCount3000 { get; set; }
        public int? DepositCount4000 { get; set; }
        public int? DepositCount5000 { get; set; }
        public int? DepositCount6000 { get; set; }
        public int? DepositCount7000 { get; set; }
        public int? DepositCount8000 { get; set; }
        public int? DepositCount9000 { get; set; }
        public int? DepositCount10000 { get; set; }
    }
}
