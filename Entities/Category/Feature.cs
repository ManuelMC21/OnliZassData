using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class Feature : BaseEntity
{
    public required string Name { get; set; }
    public string? Description { get; set; }
    public List<string> Suggestions { get; set; } = new List<string>();

    // Navegación directa a Categories (skip navigation)
    public List<Category> Categories { get; set; } = new List<Category>();

    // Relación con CategoryFeatures
    public List<CategoryFeature> CategoryFeatures { get; set; } = new List<CategoryFeature>();
}
