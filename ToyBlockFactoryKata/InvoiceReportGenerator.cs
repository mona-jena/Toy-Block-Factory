using System;
using System.Collections.Generic;
using System.Linq;

namespace ToyBlockFactoryKata
{
    internal class InvoiceReportGenerator : IReportGenerator
    {
        private readonly IInvoiceCalculationStrategy _priceList;

        internal InvoiceReportGenerator(IInvoiceCalculationStrategy priceList) 
        {
            _priceList = priceList;
            
        }

        public IReport GenerateReport(Order requestedOrder) //Should sep setup and getting part of report?
        {
            var report = new InvoiceReport()
            {
                ReportType = ReportType.Invoice,
                Name = requestedOrder.Name,
                Address = requestedOrder.Address,
                DueDate = requestedOrder.DueDate,
                OrderId = requestedOrder.OrderId
            };
            GenerateTable(report, requestedOrder);
            _priceList.BlockListIterator(report, requestedOrder);
            return report;
        }
        

        private void GenerateTable(InvoiceReport report, Order requestedOrder)
        {
            // how to write in LINQ??
            foreach (Shape shape in Enum.GetValues(typeof(Shape)))
                report.OrderTable.Add(new TableRow(shape, RowItems(shape, requestedOrder)));
        }

        private List<TableColumn> RowItems(Shape shape, Order requestedOrder)
        {
            var rowItemQuantities = new List<TableColumn>();
            foreach (Colour colour in Enum.GetValues(typeof(Colour)))
            {
                var block = new Block(shape, colour);
                if (requestedOrder.BlockList.ContainsKey(block))
                    rowItemQuantities.Add(new TableColumn(colour.ToString(), requestedOrder.BlockList[block]));
            }

            return rowItemQuantities;
        }

        
    }
}