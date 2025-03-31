using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cryptocurrency_Exchange_Simulator
{
    internal class PortfolioData
    {
        public decimal Balance { get; set; }
        public Dictionary<string, decimal> Holdings { get; set; }

        public PortfolioData() { }

        public PortfolioData(decimal balance, Dictionary<string, decimal> holdings)
        {
            Balance = balance;
            Holdings = holdings;
        }
    }
}
