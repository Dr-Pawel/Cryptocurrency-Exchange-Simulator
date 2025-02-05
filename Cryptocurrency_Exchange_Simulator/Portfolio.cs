using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Exchange_Simulator
{
    internal class Portfolio
    {
        public decimal Balance { get; set; }
        Dictionary<string, decimal> Holdings = new Dictionary<string, decimal>();
        public Portfolio(decimal balance)
        {
            balance = 10000;
            Balance = balance;
        }

        public void BuyCrypto()
        {
            Console.WriteLine("What kind of Crypto Currency would you like to buy?");
            string cryptoToBuy = Console.ReadLine();
            Console.WriteLine($"how much of {cryptoToBuy} would you like to buy?");
            decimal amount = decimal.Parse(Console.ReadLine());          
        }

        public void SellCrypto()
        {

        }
        public void ShowPortfolio()
        {
            Console.WriteLine($"Current Ballance: {Balance}$");

            if(Holdings.Count == 0)
            {
                Console.WriteLine("You currently dont have any cryptocurrencies");
            }
            else
            {
                foreach (var asset in Holdings)
                {
                    Console.WriteLine($"{asset.Key}: {asset.Value} units");
                }
            }
        }
    }
}
