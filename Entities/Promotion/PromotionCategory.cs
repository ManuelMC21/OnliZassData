namespace onlizas.Entities.Promotion;

public class PromotionCategory
{
    public int Id { get; set; }
    public int PromotionId { get; set; }
    public Promotion? Promotion { get; set; }
    public int CategoryId { get; set; }
    public Category? Category { get; set; }
}
