using System.Collections.Generic;
using ToyBlockFactoryKata;
using Xunit;

namespace ToyBlockFactoryTests
{
    public class OrderManagementSystemTests
    {
        [Fact]
        public void CheckIfCustomerOrderIsAbleToBeCreatedAndReturned()
        {
            var toyBlockFactory = new ToyBlockFactory();
            var customerName = "David Rudd";
            var customerAddress = "1 Bob Avenue, Auckland";
            Order customerOrder = toyBlockFactory.CreateOrder(customerName, customerAddress);
            customerOrder.AddBlock(Shape.Square, Colour.Red);
            customerOrder.AddBlock(Shape.Square, Colour.Yellow);
            customerOrder.AddBlock(Shape.Triangle, Colour.Blue);
            customerOrder.AddBlock(Shape.Triangle, Colour.Blue);
            customerOrder.AddBlock(Shape.Circle, Colour.Blue);
            customerOrder.AddBlock(Shape.Circle, Colour.Yellow);
            customerOrder.AddBlock(Shape.Circle, Colour.Yellow);
            var orderDueDate = "19 Jan 2019";
            customerOrder.DueDate = orderDueDate;
            toyBlockFactory.SubmitOrder(customerOrder);
            var orderList = new Dictionary<Block, int>
            {
                {new Block(Shape.Square, Colour.Red), 1},
                {new Block(Shape.Square, Colour.Yellow), 1},
                {new Block(Shape.Triangle, Colour.Blue), 2},
                {new Block(Shape.Circle, Colour.Blue), 1},
                {new Block(Shape.Circle, Colour.Yellow), 2}
            };
            
            var order = toyBlockFactory.GetOrder("0001");
            
            Assert.Equal(customerName, order.Name);
            Assert.Equal(customerAddress, order.Address);
            Assert.Equal(orderDueDate, order.DueDate);
            Assert.Equal("0001", order.OrderNumber);
            Assert.Equal(orderList, order.BlockList);
        }
        //IS IT BAD TO DO MULTIPLE ASSERTS IN ONE?
        
        
        
        //var orderManagementSystem = new OrderManagementSystem(customerDetails);
        //var customerOrder = orderManagementSystem.GetOrder();
        //var reportOrderManagement = new ReportOrderManagementSystem(customerOrder);
        /*var pricingList = new PricingList();
        pricingList.Square = 1;
        pricingList.Triangle = 2;
        pricingList.Circle = 1;
        pricingList.Red = 1;*/

        //var invoiceReport = reportOrderManagement.GenerateInvoice(customerOrder);
        
        

        /*
         * new toyblock factory
         * new customer
         * system creates new order
         * get customer details
         * customer add new block each time - in the back blocks and dict of blocks will be created
         * return order
         * give back invoice
         */
        
        /*var expectedInvoiceReport = 
                "Your invoice report has been generated:" +
                "\n" +
                "Name: David Rudd Address: 1 Bob Avenue, Auckland Due Date: 19 Jan 2019 Order #: 0001" +
                "\n" +
                "|          | Red | Blue | Yellow |" +
                "|----------|-----|------|--------|" +
                "| Square   | 1   | -    | 1      |" +
                "| Triangle | -   | 2    | -      |" +
                "| Circle   | -   | 1    | 2      |" +
                "\n" +
                "Squares 		        2 @ $1 ppi = $2" +
                "Triangles		        2 @ $2 ppi = $4" +
                "Circles			    3 @ $3 ppi = $9" +
                "Red colour surcharge   1 @ $1 ppi = $1" +
                "\n" +
                "Total                  $16";*/
    }


    

    
}

