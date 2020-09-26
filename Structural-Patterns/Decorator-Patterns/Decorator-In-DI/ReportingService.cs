using System;

namespace Decorator_In_DI
{
    public class ReportingService : IReportingService
    {
        public void Report()
        {
            Console.WriteLine("Here is your report!");
        }
    }
}