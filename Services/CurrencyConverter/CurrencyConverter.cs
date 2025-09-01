using Microsoft.EntityFrameworkCore;
using onlizas.Data;

namespace onlizas.Services.CurrencyConverter;

public class CurrencyConverter : ICurrencyConverter
{
    private readonly OnlizasDb _db;

    public CurrencyConverter(OnlizasDb db)
    {
        _db = db;
    }

    public async Task<decimal> ConvertAsync(
        decimal amount,
        string fromCurrencyCode,
        string toCurrencyCode,
        CancellationToken ct = default)
    {
        var rate = await GetExchangeRateAsync(fromCurrencyCode, toCurrencyCode, ct);
        return amount * rate;
    }

    public async Task<decimal> GetExchangeRateAsync(
        string fromCurrencyCode,
        string toCurrencyCode,
        CancellationToken ct = default)
    {
        if (fromCurrencyCode == toCurrencyCode)
            return 1m;

        var currencies = await _db.Currencies
            .Where(c => c.CodIso == fromCurrencyCode || c.CodIso == toCurrencyCode)
            .ToDictionaryAsync(c => c.CodIso, c => c.Rate, ct);

        if (!currencies.TryGetValue(fromCurrencyCode, out var fromRate) ||
            !currencies.TryGetValue(toCurrencyCode, out var toRate))
        {
            throw new InvalidOperationException("Una o ambas monedas no existen");
        }

        return toRate / fromRate; // Conversión basada en tasas relativas
    }
}
