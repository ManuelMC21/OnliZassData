using System.Text.Json;

namespace ZasExpressApi.Events;

public record BusinessDto(
    Guid Guid,
    int id,
    string source,
    string name,
    string Code,
    string? Description,
    string[] PhotoObjectCodes,
    Guid OwnerId,
    JsonDocument? Attributes ,
    List<Guid> Users ,
    int? ParentId,
    List<int>Children ,
    int LocationId ,

    string HBLInitial,
    string Address,
    string Email ,
    string Phone ,
    string InvoiceText,
    bool IsPrimary,
    decimal FixedRate,
    DateTimeOffset CreatedAt ,

    List<int> SubSystemIds,
       
    bool IsActive
);