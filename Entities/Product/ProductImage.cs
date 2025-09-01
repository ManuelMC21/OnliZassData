using onlizas.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace onlizas.Entities;

public class ProductImage : BaseEntity
{
    [Required]
    public int ProductId { get; set; }
    public Entities.ProductVariant.ProductVariant Product { get; set; } = null!;
    
    public required string Image { get; set; }
    public int Order { get; set; }
}
