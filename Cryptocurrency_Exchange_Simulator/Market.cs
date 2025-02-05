using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Exchange_Simulator
{
    internal class Market
    {
       static Dictionary<string, CryptoCurrency> cryptoMarket = new Dictionary<string, CryptoCurrency>
        {
            {"BTC", new CryptoCurrency("Bitcoin", "BTC", 42000m)},
            {"ETH", new CryptoCurrency("Ethereum", "ETH", 3000m)},
            {"DOGE", new CryptoCurrency("Dogecoin", "DOGE", 0.08m)}
        };

        public void ShowMarket()
        {
            Console.WriteLine("MARKET:");
            foreach (var asset in cryptoMarket)
            {
                Console.WriteLine($"{asset.Key} : {asset.Value.Price}");
            }
        }

        public static CryptoCurrency GetCrypto(string symbol)
        {
           if(cryptoMarket.ContainsKey(symbol))
            {
                return cryptoMarket[symbol];
            }
            else
            {
                return null;
            }
        }
    }
}
