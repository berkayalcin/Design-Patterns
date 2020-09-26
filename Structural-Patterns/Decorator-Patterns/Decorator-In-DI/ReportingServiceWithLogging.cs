using System;

namespace Decorator_In_DI
{
    public class ReportingServiceWithLogging : IReportingService
    {
        private IReportingService _decorated;

        public ReportingServiceWithLogging(IReportingService decorated)
        {
            _decorated = decorated;
        }

        public void Report()
        {
            Console.WriteLine("Commencing Log...");
            _decorated.Report();
            Console.WriteLine("Ending Log...");
        }
    }
}