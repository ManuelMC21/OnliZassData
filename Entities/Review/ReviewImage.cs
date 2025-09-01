namespace onlizas.Entities.Review;

public class ReviewImage
{
    public int Id { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
    public int ReviewId { get; set; }
}
