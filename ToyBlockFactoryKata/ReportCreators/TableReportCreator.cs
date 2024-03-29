using ToyBlockFactoryKata.Orders;
using ToyBlockFactoryKata.Reports;
using ToyBlockFactoryKata.Tables;

namespace ToyBlockFactoryKata.ReportCreators
{
    internal class TableReportCreator : IReportCreator
    {
        private readonly ITableFactory _tableFactory;

        internal TableReportCreator(ITableFactory tableFactory)
        {
            _tableFactory = tableFactory;
        }

        public IReport GenerateReport(ReportType reportType, Order requestedOrder)
        {
            var report = new Report
            {
                ReportType = reportType,
                Name = requestedOrder.Name,
                Address = requestedOrder.Address,
                DueDate = requestedOrder.DueDate,
                OrderId = requestedOrder.OrderId
            };
            
            var table = _tableFactory.GenerateTable(requestedOrder.BlockList);
            report.OrderTable.AddRange(table);
            
            return report;
        }
    }
}