using EcbRatesApi;
using System;

namespace Forex
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            CallExchanger(new CurrencyExchanger());


            // EcbRatesReader updates daily, has many more currencies + crypto ones
            // How can it be used with the CallExchanger method???
           // CallExchanger(new EcbRatesReader());



            Console.ReadLine();
        }

        private static void CallExchanger(ICurrencyExchanger currencyExchanger)
        {
            Console.WriteLine(currencyExchanger.GetCurrencyValue(CurrencyType.USD));
            Console.WriteLine(currencyExchanger.ConvertTo(CurrencyType.USD, 10));
        }
    }
}
