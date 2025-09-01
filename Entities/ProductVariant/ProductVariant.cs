using onlizas.Shared.Entities;
using System.ComponentModel.DataAnnotations;

namespace onlizas.Entities.ProductVariant;

public class ProductVariant : BaseEntity
{
    public Guid GlobalId { get; set; } = Guid.NewGuid();
    [Required]
    public int ProductId { get; set; }
    public Entities.Product.Product ParentProduct { get; set; } = null!;

    public int InventoryId { get; set; }
    public Inventory Inventory { get; set; }

    public decimal Price { get; set; }
    public int Quantity { get; set; }

    public DiscountType DiscountType { get; set; }
    public decimal DiscountValue { get; set; }

    public int LimitPurchaseLimit { get; set; }

    public required Warranty Warranty { get; set; }

    public bool IsPrime { get; set; }
    public List<ProductImage> Images { get; set; } = new List<ProductImage>();

    
    public Dictionary<string, string>? Details { get; set; }
}