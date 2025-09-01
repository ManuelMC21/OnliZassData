using onlizas.Shared.Entities;


namespace onlizas.Entities.Store;

public class Store : BaseEntity
{
    public Guid GlobalId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Url { get; set; }
    public Email Email { get; set; }
    public PhoneNumber PhoneNumber { get; set; }
    public required string Address { get; set; }

    public required string LogoStyle { get; set; }     
    
    public required string ReturnPolicy { get; set; }
    public required string ShippingPolicy { get; set; }
    public required string TermsOfService { get; set; }

    public string? PrimaryColor { get; set; }
    public string? SecondaryColor { get; set; }
    public string? AccentColor { get; set; }

    public FontEnum Font { get; set; }
    public TemplateEnum Template { get; set; }

    public List<StoreFollower> Followers { get; set; } = new();
    public List<Banner.Banner> Banners { get; set; } = new();
    public List<Inventory> Inventories { get; set;} = new();

    //Relacion con StoreCategories
    public List<StoreCategory.StoreCategory> StoreCategories { get; set; } = new();

    //Relacion con Promotion
    public List<Promotion.Promotion> Promotions { get; set; } = new();

    //Relacion con negocio
    public Business? Business { get; set; }
    public int BusinessId { get; set; }
}