using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Exchange_Simulator
{
    internal class CryptoCurrency
    {
        public string Name { get; set; }
        public string Symbol { get; set; }
        public decimal Price { get; set; }

        public CryptoCurrency(string name, string symbol, decimal price)
        {
            Name = name;
            Symbol = symbol;
            Price = price;
        }

        public void updatePrice(Random rng)
        {
            decimal changePercentage = (decimal)rng.Next(-10, 11) / 100;
            Price += Price * changePercentage;
            Price = Math.Round(Price, 2);
        }        
    }
}
