using System;
using System.Net.Http;
using System.Xml;

namespace Forex
{
    public class CurrencyExchanger: ICurrencyExchanger
    {
        private readonly HttpClient _httpClient;

        private readonly Uri _baseUri = new Uri("https://www.ecb.europa.eu/stats/eurofxref/eurofxref-daily.xml");

        public CurrencyExchanger()
        {
            _httpClient = new HttpClient();
        }

        public double GetCurrencyValue(CurrencyType currency)
        {
            var response = _httpClient.GetStringAsync(_baseUri).Result;
            var xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(response);
            
            return GetCurrencyValue(currency, xmlDocument);
        }

        public double ConvertTo(CurrencyType currency, double value)
        {
            var currencyRate = GetCurrencyValue(currency);
            return Convert.ToDouble(currencyRate) * value;
        }

        private double GetCurrencyValue(CurrencyType currency, XmlDocument document)
        {
            var nodes = document.GetElementsByTagName("Cube");
            for (var i = 0; i < nodes.Count; i++)
            {
                if (nodes[i].HasChildNodes) continue;
                
                var element = nodes[i];
                if (element.Attributes["currency"].Value.Equals(currency.ToString()))
                {
                    return Convert.ToDouble(element.Attributes["rate"].Value);
                }
            }
            return 0;
        }
    }
}
