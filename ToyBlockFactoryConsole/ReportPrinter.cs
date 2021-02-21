using System;
using System.Linq;
using ToyBlockFactoryKata.Reports;
using static System.String;

namespace ToyBlockFactoryConsole
{
    internal static class ReportPrinter
    {
        public static void PrintReport(IReport report)
        {
            Console.WriteLine();
            Console.WriteLine($"Your {report.ReportType.ToString().ToLower()} report has been generated:");
            Console.WriteLine();
            Console.WriteLine(
                $"Name: {report.Name}  Address: {report.Address}  Due Date: {report.DueDate:dd/MM/yyyy}  Order #: {report.OrderId}");
            Console.WriteLine();

            var topRowLabels =
                report.OrderTable
                    .SelectMany(l => l.TableColumn)
                    .Select(l => l.MeasuredItem)
                    .Distinct().ToList();

            Console.WriteLine(Join("|", topRowLabels.Select(l => $"{l,8}")));
            Console.WriteLine(Join("|", topRowLabels.Select(_ => "----------")));
            Console.WriteLine(Join("\n", report.OrderTable));

            if (report is InvoiceReport invoice)
                Console.WriteLine(Join("\n", invoice.LineItems) + $"\nTotal : ${invoice.Total}");
        }
    }
}