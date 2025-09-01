namespace onlizas.Services.CurrencyConverter;

public interface ICurrencyConverter
{
    Task<decimal> ConvertAsync(
        decimal amount,
        string fromCurrencyCode,
        string toCurrencyCode,
        CancellationToken ct = default);

    Task<decimal> GetExchangeRateAsync(
        string fromCurrencyCode,
        string toCurrencyCode,
        CancellationToken ct = default);
}
