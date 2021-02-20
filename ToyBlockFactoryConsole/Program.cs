using System;
using ToyBlockFactoryKata;
using ToyBlockFactoryKata.PricingStrategy;

namespace ToyBlockFactoryConsole
{
    internal static class Program
    {
        private static IInvoiceCalculationStrategy _pricing = new PricingCalculator();
        internal static void Main()
        {
            Console.WriteLine("Welcome to the Toy Block Factory!\n");
            var toyBlockFactory = new ToyBlockFactory(_pricing);

            Menu(toyBlockFactory);
        }

        public static void Menu(ToyBlockFactory toyBlockFactory)
        {
            var options = "Would you like to [1] Place an order or [2] Get an existing order [3] Get reports due on a particular date?";
            if (_pricing is PricingCalculator)
            {
                options += " [4] Crazy stocktake sale time???";
            }
            else
            {
                Console.WriteLine("ITS CRAZY SALE TIME!");
            }

            Console.WriteLine(options);
            Console.Write("Please input your choice: ");
            var functionalityOption = int.Parse(Console.ReadLine());
            switch (functionalityOption)
            {
                case 1:
                    UserInterface.PlaceOrder(toyBlockFactory);
                    break;
                case 2:
                    UserInterface.GetOrder(toyBlockFactory);
                    break;
                case 3:
                    UserInterface.GenerateReportsForADate(toyBlockFactory);
                    break;
                case 4:
                    if (_pricing is StocktakeSalePrices) break;
                    _pricing = new StocktakeSalePrices();
                    toyBlockFactory = new ToyBlockFactory(_pricing);
                    Menu(toyBlockFactory);
                    break;
                default:
                    Menu(toyBlockFactory);
                    break;
            }
        }
    }
}