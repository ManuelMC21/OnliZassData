namespace onlizas.Entities.Promotion;

public class PromotionProduct
{
    public int Id { get; set; }
    public int PromotionId { get; set; }
    public Promotion? Promotion { get; set; }
    public int ProductVariantId { get; set; }
    public ProductVariant.ProductVariant? ProductVariant { get; set; }
}
