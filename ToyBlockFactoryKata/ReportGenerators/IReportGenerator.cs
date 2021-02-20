using ToyBlockFactoryKata.Orders;
using ToyBlockFactoryKata.Reports;

namespace ToyBlockFactoryKata.ReportGenerators
{
    internal interface IReportGenerator
    {
        IReport GenerateReport(ReportType reportType, Order requestedOrder);
    }
}