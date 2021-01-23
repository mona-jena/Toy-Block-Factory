namespace ToyBlockFactoryKata
{
    internal class ReportGenerator
    {
        private readonly IInvoiceCalculationStrategy _priceList = new PricingList();

        internal InvoiceReportGenerator GenerateInvoice(Order requestedOrder) //should I return an interface?
        {
            var invoiceReportGenerator = new InvoiceReportGenerator(_priceList, requestedOrder);
            invoiceReportGenerator.GenerateReport();
            return invoiceReportGenerator;
        }
    }

    
}