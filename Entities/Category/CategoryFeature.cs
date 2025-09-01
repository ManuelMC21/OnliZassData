using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class CategoryFeature : BaseEntity
{
    public int CategoryId { get; set; }
    public Category Category { get; set; } = null!;
    
    public int FeatureId { get; set; }
    public Feature Feature { get; set; } = null!;
    
    public bool IsRequired { get; set; }
    public bool IsPrimary { get; set; }
    // IMPORTANTE: Se eliminó la navegación hacia Products porque generaba una FK sombra
    // Product.CategoryFeatureId que nunca existió físicamente y provocaba migraciones fantasma.
}
