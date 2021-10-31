using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;

namespace EcbRatesApi
{
    public class EcbRatesReader
    {
        private readonly HttpClient _httpClient;

        private readonly Uri _baseUri =
            new Uri(
                "http://data.fixer.io/api/latest?access_key=ec9b7c085cec16ecf8b0511fa11daacc");

        public EcbRatesReader()
        {
            _httpClient = new HttpClient();
        }

        public List<CurrencyInfo> GetRates()
        {
            var response = _httpClient.GetStringAsync(_baseUri).Result;

            var currencyResponse = JsonConvert.DeserializeObject<ExchangeData>(response);

            return currencyResponse.Rates.Select(x => new CurrencyInfo(x.Key, Convert.ToDouble(x.Value))).ToList();
        }
    }
}
