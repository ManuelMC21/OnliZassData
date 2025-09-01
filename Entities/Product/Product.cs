using onlizas.Shared.Entities;

namespace onlizas.Entities.Product;

public class Product : BaseEntity
{
    public Guid GlobalId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }

    // Dimensiones del producto
    public decimal? Length { get; set; }
    public decimal? Width { get; set; }
    public decimal? Height { get; set; }
    public decimal? Weight { get; set; }

    // About This section
    public List<string> AboutThis { get; set; } = new();

    // Details section - registros clave/valor
    public Dictionary<string, string>? Details { get; set; }

    // Tutoriales de uso del producto
    public List<string>? Tutorials { get; set; } = new List<string>();

    // Relaciones
    public List<ProductCategory> Categories { get; set; } = new List<ProductCategory>();
    public List<Entities.ProductVariant.ProductVariant> ProductVariants { get; set; } = new();
    public List<ProductUser> SuppliersId { get; set; } = new List<ProductUser>();
}
