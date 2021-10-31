using System;

namespace EcbRatesApi
{
    public class CurrencyInfo
    {
        public string Name { get; set; }
        public double Rate { get; set; }

        public CurrencyInfo(string name, double rate)
        {
            Name = name;
            Rate = rate;
        }
    }
}
