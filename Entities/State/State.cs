using onlizas.Shared.Entities;

namespace onlizas.Entities;

public sealed class State: BaseEntity
{
    public required string Name { get; set; }
    
    public ICollection<District> Districts { get; set; } = new List<District>();
    
    public int CountryId { get; set; }
    public Country? Country { get; set; }
}