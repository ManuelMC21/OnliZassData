using onlizas.Shared.Entities;

namespace onlizas.Entities.Banner;

public class Banner : BaseEntity
{
    public Guid GlobalId { get; set; }
    public string Title { get; set; }
    public string UrlDestinity { get; set; }
    public Position Position { get; set; }
    public DateTimeOffset InitDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public string Image { get; set; }

    public Entities.Store.Store Store { get; set; }
    public int StoreId { get; set; }
}
