using Autofac;

namespace Decorator_In_DI
{
    class Program
    {
        static void Main(string[] args)
        {
            var containerBuilder = new ContainerBuilder();
            containerBuilder.RegisterType<ReportingService>().Named<IReportingService>("Reporting");
            containerBuilder.RegisterDecorator<IReportingService>((context, service) =>
                    new ReportingServiceWithLogging(service),
                "Reporting");

            using var container = containerBuilder.Build();
            var reportingService = container.Resolve<IReportingService>();
            reportingService.Report();
        }
    }
}