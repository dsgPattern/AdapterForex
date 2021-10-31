namespace Forex
{
    public interface ICurrencyExchanger
    {
        double GetCurrencyValue(CurrencyType currency);
        double ConvertTo(CurrencyType currency, double value);
    }
}
