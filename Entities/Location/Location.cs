using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class Location : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
}