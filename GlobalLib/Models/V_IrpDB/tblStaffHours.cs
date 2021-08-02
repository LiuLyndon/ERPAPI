using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.ComponentModel.DataAnnotations;

namespace GlobalLib.Models.V_IrpDB
{
    public class tblStaffHours
    {
        [Key]
        public string CinOperator_strCode { get; set; }
        [Key]
        public DateTime cMovieDate { get; set; }
        public decimal BIO { get; set; }
        public decimal CandyBar { get; set; }
        public decimal CoffeeBar { get; set; }
        public decimal Unicorn { get; set; }
        public decimal ChefJohn { get; set; }
        public decimal WoodCase { get; set; }
        public decimal CashRoom { get; set; }
        public decimal Floor { get; set; }
        public decimal Clean { get; set; }
        public decimal StockTake { get; set; }
        public decimal ScreeningHelp { get; set; }
        public decimal NewBIOStaffTraning { get; set; }
        public decimal PosterMap { get; set; }
        public decimal TestRun { get; set; }
        public decimal TicketBox { get; set; }
        public decimal Training { get; set; }
        public decimal Office { get; set; }
        public decimal MarketSurvey { get; set; }
        public decimal MarketingHelp { get; set; }
        public decimal CRM { get; set; }
        public decimal PhoneBooking { get; set; }
        public decimal Store { get; set; }
        public decimal Other { get; set; }
        public decimal Total { get; set; }
    }
}
