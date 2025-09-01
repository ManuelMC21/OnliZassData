using onlizas.Entities.ProductVariant;
using onlizas.Shared.Entities;

namespace onlizas.Entities.Promotion;

public class Promotion : BaseEntity
{
    public int StoreId { get; set; }
    public Store.Store Store { get; set; }

    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime StartDate { get; set; }
    public DateTime EndDate { get; set; }
    public decimal DiscountValue {get; set;}
    public DiscountType DiscountType { get; set; }
    public int UsageLimit { get; set; }
    public string Code { get; set; }
    public string MediaFile { get; set; }

    //Relacion 1 a muchos con ProductVariant
    public List<PromotionProduct> PromotionProducts { get; set; } = new();

    //Relacion 1 a muchos con Category
    public List<PromotionCategory> PromotionCategories { get; set; } = new();
}