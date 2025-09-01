using onlizas.Data;
using onlizas.Entities.Trace;
using onlizas.Entities;

namespace onlizas.Services.Trace;
public class CurrencyLogService : EntityLogService<Currency, CurrencyLog>
{
    public CurrencyLogService(AppDbContext db) : base(db) { }

    protected override void SetCommonLogProperties(
        CurrencyLog log,
        int entityId,
        int userId,
        string typeAction,
        Currency newEntity,
        Currency? oldEntity)
    {
        log.CurrencyId = entityId;
        log.CurrencyCode = newEntity.CodIso;
        log.CurrencyName = newEntity.Name;
        log.CurrencySymbol = newEntity.Symbol;

        log.UserId = userId;
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(Currency entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre", entity.Name),
            ("Código ISO", entity.CodIso),
            ("Símbolo", entity.Symbol),
            ("Tasa", entity.Rate),
            ("Estado", entity.IsActive),
            ("Por defecto", entity.Default)
        };
    }
}