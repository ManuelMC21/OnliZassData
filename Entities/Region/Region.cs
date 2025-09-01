using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class Region : BaseEntity
{
    public required string Name { get; set; }
    public required string Code { get; set; }
    
    public ICollection<Country> Countries { get; set; } = new List<Country>();
}