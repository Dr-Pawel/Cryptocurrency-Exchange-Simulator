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
            Console.WriteLine($"Current balance: {Balance}$");
        }

        public void BuyCrypto(string symbol, decimal amount, CryptoCurrency crypto)
        {

        }

        public void SellCrypto(string symbol, decimal amount, CryptoCurrency crypto)
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
