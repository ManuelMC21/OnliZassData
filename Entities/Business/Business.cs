using onlizas.Entities.Users;
using onlizas.Shared.Entities;
using System.Text.Json;

namespace onlizas.Entities;

public class Business : BaseEntity
{
    public Guid Guid { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }//
    public required string Code { get; set; }//
    public required string? Description { get; set; }
    public required string[] PhotoObjectCodes { get; set; } = [];

    public string? HBLInitial { get; set; }

    public string? Address { get; set; }
    public string? Email { get; set; }
    public string? Phone { get; set; }

    public bool IsPrimary { get; set; } = false;
    public decimal FixedRate { get; set; } = 0;

    public string InvoiceText { get; set; } = string.Empty;


    public Guid OwnerGuid { get; set; }
    public required int OwnerId { get; set; }
    public User? Owner { get; set; }

    public JsonDocument? Attributes { get; set; }

    public ICollection<SubSystem> SubSystems { get; set; } = new List<SubSystem>();
    public ICollection<User> Users { get; set; } = new List<User>();

    public int? ParentId { get; set; }
    public Business? Parent { get; set; }
    public ICollection<Business> Children { get; set; } = new List<Business>();

    public ICollection<BusinessAttributeLog> AttributeLogs { get; set; } = new List<BusinessAttributeLog>();


    public int LocationId { get; set; }
    public required Location Location { get; set; }

    public List<Entities.Store.Store> Stores { get; set; } = new List<Entities.Store.Store>();

}
