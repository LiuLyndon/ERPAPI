using ReportPersaleTicketLib;
using System;

namespace CAReport
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime Dt = DateTime.Now.AddDays(-1);

            Console.WriteLine("Setting: " + Dt.Date);
            Console.WriteLine("Main Start");

            using (ReportPersaleTicket reLib = new ReportPersaleTicket(Dt))
            {
                Console.WriteLine("GetAllInformation");
                reLib.GetInformation("FAST AND FURIOUS 9");

                Console.WriteLine("CreateExcel");
                reLib.CreateExcel();

                Console.WriteLine("SendMail");
                reLib.SendMail();
            }

            Console.WriteLine("Main End");
        }
    }
}
