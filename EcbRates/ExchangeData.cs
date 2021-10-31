using System;
using System.Collections.Generic;

namespace EcbRatesApi
{
    public class ExchangeData
    {
        public bool Success { get; set; }
        public string Timestamp { get; set; }
        public string Base { get; set; }
        public DateTime Date { get; set; }
        public Dictionary<string,string> Rates { get; set; }
    }
}
