using onlizas.Entities.Trace;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class Currency : BaseEntity
{
    public required string Name { get; set; }
    public required string CodIso { get; set; }
    public required string Symbol { get; set; }
    public required decimal Rate { get; set; }
    public required bool Default { get; set; }

    // Relaci�n con logs
    public List<CurrencyLog> Logs { get; set; } = new List<CurrencyLog>();
}