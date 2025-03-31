using System;

namespace Cryptocurrency_Exchange_Simulator
{
    internal class Program
    {
        static Portfolio portfolio;
        static Market market = new Market();
        static void Main(string[] args)
        {
            if (File.Exists("portfolio.json"))
            {
                portfolio = new Portfolio();  
            }
            else
            {
                portfolio = CreateNewPortfolio();
                portfolio.SaveToFile();
            }

            MainMenu();        
        }

            static void MainMenu()
        {
            Console.Clear();
            Console.WriteLine("==== DR.Pawel's CryptoCurrency Exchange Simulator App====\n");
            List<string> menu = new List<string>
            {
                "1.Show Portfolio",
                "2.Show Market",
                "3.Buy Currency",
                "4.Sell Currency",
                "5.Quit App"
            };

            foreach (string menuOption in menu)
            {
                Console.WriteLine($"{menuOption}");
            }

            string input = Console.ReadLine();

            switch (input)
            {
                case "1":
                    Console.Clear();
                    portfolio.ShowPortfolio(market);
                    ReturnToMainMenu();
                    break;
                case "2":
                    Console.Clear();
                    market.ShowMarket();
                    ReturnToMainMenu();
                    break;
                case "3":
                    Console.Clear();
                    market.ShowMarket();
                    Console.WriteLine("\n");
                    portfolio.BuyCrypto(market);
                    ReturnToMainMenu();
                    break;
                case "4":
                    Console.Clear();
                    market.ShowMarket();
                    Console.WriteLine("\n");
                    portfolio.SellCrypto(market);
                    ReturnToMainMenu();
                    break;
                case "5":
                    System.Environment.Exit(1);
                    portfolio.SaveToFile();
                    break;
                default:
                    Console.WriteLine("Wrong input, try again");
                    System.Threading.Thread.Sleep(1000);
                    break;
            }
        }
        static void ReturnToMainMenu()
        {
            Console.WriteLine("To return to main Menu press any button");
            Console.ReadKey();
            Console.Clear();
            MainMenu();
        }
        private static Portfolio CreateNewPortfolio()
        {
            Console.WriteLine("No save file found. Please enter your starting budget:");

            decimal startingBalance;
            while (!decimal.TryParse(Console.ReadLine(), out startingBalance) || startingBalance <= 0)
            {
                Console.WriteLine("Invalid input. Please enter a positive number:");
            }

            return new Portfolio(startingBalance);
        }
    }
}
