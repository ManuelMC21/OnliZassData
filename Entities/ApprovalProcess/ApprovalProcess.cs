using onlizas.Entities.Users;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class ApprovalProcess : BaseEntity
{
    public required string Name { get; set; }
    public required string Email { get; set; }
    public string? Phone { get; set; }
    public string? Addres { get; set; }
    public bool IsAproved { get; set; } = false;
    public DateTime? ApprovedAt { get; set; }
    public required SupplierType Type { get; set; }                 // Minorista / Mayorista / Ambas
    public required SellerType SellerType { get; set; }
    public required NacionalityType Nacionality { get; set; }       // Nacional / Extranjero / Ambas
    public string? MincexCode { get; set; }                         // Solo aplica para Extranjero/Ambas
    public int? CountryId { get; set; } 
    public Country? Country { get; set; }                            // País (Cuba=40 por defecto si Nacional)

    public required ProcessState State { get; set; } = ProcessState.Pending;
    public bool IsEvaluated { get; set; } = false;
    public DateTime? LastEvaluationDate { get; set; }
    public double CurrentRating { get; set; } = 0;
    public int EvaluationCount { get; set; } = 0;

    public ICollection<ApprovalProcessApprovedCategory> ApprovedCategories { get; set; } = new List<ApprovalProcessApprovedCategory>();
    public ICollection<ApprovalProcessRequestedCategory> RequestedCategories { get; set; } = new List<ApprovalProcessRequestedCategory>();

    public ICollection<Document>? ApprovedDocuments { get; set; } = new List<Document>();
    public ICollection<Document>? ExtensionDocuments { get; set; } = new List<Document>();

    public int? UserId { get; set; }
    public User? User { get; set; }
    public required DateTime? ExpirationDate { get; set; }

    public string GetSupplierType() => Type.ToString();
}