using onlizas.Shared.Entities;

namespace onlizas.Entities.TrackingApiKeys;

public sealed class TrackingApiKey : BaseEntity
{
    public required string HashedKey { get; set; }
    public required string Key { get; set; }

    public required string Name { get; set; }

}