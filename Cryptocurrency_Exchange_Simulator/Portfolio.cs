using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.IO;

namespace Cryptocurrency_Exchange_Simulator
{
    internal class Portfolio
    {
        public decimal Balance { get; set; }
        Dictionary<string, decimal> Holdings = new Dictionary<string, decimal>();

        public Portfolio(decimal balance)
        {
            Balance = balance;
        }

        public Portfolio()
        {
            if (File.Exists("portfolio.json"))
            {
                LoadFromFile();
            }
            else
            {
                Console.WriteLine("No save file found. Please enter your starting budget:");
                decimal startingBalance;
                while (!decimal.TryParse(Console.ReadLine(), out startingBalance) || startingBalance <= 0)
                {
                    Console.WriteLine("Invalid input. Please enter a positive number:");
                }
                Balance = startingBalance;
            }
        }

        public void BuyCrypto(Market market)
        {
            Console.WriteLine("What kind of Crypto Currency would you like to buy?");
            string cryptoToBuy = Console.ReadLine().ToUpper();
            CryptoCurrency crypto = market.GetCrypto(cryptoToBuy);
            if(crypto == null)
            {
                Console.WriteLine($"Cryptocurrency not found");
                return;
            }
            Console.WriteLine($"how much of {cryptoToBuy} would you like to buy?");
            if(!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("invalid amount!");
                return;
            }
            decimal totalCost = crypto.Price * amount;
            if(Balance < totalCost)
            {
                Console.WriteLine("You dont have enough money!");
                return;
            }
            Balance -= totalCost;

            if(!Holdings.ContainsKey(cryptoToBuy))
            {
                Holdings.Add(cryptoToBuy, amount);
            }
            Console.WriteLine($"You just bought {amount} of {cryptoToBuy} for {totalCost}");
            Console.WriteLine($"Your current ballance is: {Balance}$");
        }

        public void SellCrypto(Market market)
        {
            Console.WriteLine("What kind of Crypto Currency would you like to sell?");
            string cryptoToSell = Console.ReadLine().ToUpper();
            CryptoCurrency crypto = market.GetCrypto(cryptoToSell);
            if (crypto == null)
            {
                Console.WriteLine($"Cryptocurrency not found");
                return;
            }
            Console.WriteLine($"How much of {cryptoToSell} woudl you like to sell");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount) || amount <= 0)
            {
                Console.WriteLine("invalid amount!");
                return;
            }
            if (!Holdings.ContainsKey(cryptoToSell) || Holdings[cryptoToSell] < amount) 
            {
                Console.WriteLine("You don't have enough of this cryptocurrency to sell!");
                return;
            }
            decimal totalCost = crypto.Price * amount;
            Balance += totalCost;
            Holdings[cryptoToSell] -= amount;

            if (Holdings[cryptoToSell] == 0)
            {
                Holdings.Remove(cryptoToSell);
            }

            Console.WriteLine($"You just sold {amount} of {cryptoToSell} for {totalCost}");
            Console.WriteLine($"Your current ballance is: {Balance}$");
        }
        public void ShowPortfolio(Market market)
        {
            Console.WriteLine($"Current Ballance: {Balance}$");

            if(Holdings.Count == 0)
            {
                Console.WriteLine("You currently dont have any cryptocurrencies");
            }
            else
            {
                decimal totalPortfolioValue = 0;
                foreach (var asset in Holdings)
                {
                    CryptoCurrency crypto = market.GetCrypto(asset.Key);
                    if (crypto != null)
                    {
                        decimal assetValue = asset.Value * crypto.Price;
                        totalPortfolioValue += assetValue;
                        Console.WriteLine($"{asset.Key}: {asset.Value} units - worth {Math.Round(assetValue, 2)}$");
                    }
                    else
                    {
                        Console.WriteLine($"{asset.Key}: {asset.Value} units - Market data unavailable");
                    }
                }
                Console.WriteLine($"Total Portfolio Value: {Math.Round(totalPortfolioValue, 2)}$");
            }
        }

        public void SaveToFile()
        {
            PortfolioData portfolioData = new PortfolioData(Balance, Holdings);

            string json = JsonSerializer.Serialize(portfolioData, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText("portfolio.json", json);
            Console.WriteLine("Portfolio Saved!");
        }

        public void LoadFromFile()
        {
            if (File.Exists("portfolio.json"))
            {
                try
                {
                    string json = File.ReadAllText("portfolio.json");
                    PortfolioData portfolioData = JsonSerializer.Deserialize<PortfolioData>(json);

                    Balance = portfolioData.Balance;
                    Holdings = portfolioData.Holdings ?? new Dictionary<string, decimal>();

                    Console.WriteLine("Portfolio loaded!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error loading portfolio: {ex.Message}");
                }
            }
            else
            {
                Console.WriteLine("No save file found, starting fresh.");
            }
        }
    }
}
