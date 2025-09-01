using onlizas.Entities.Product;
using onlizas.Shared.Entities;

namespace onlizas.Entities;

public class Category : BaseEntity
{
    public Guid GlobalId { get; set; } = Guid.NewGuid();
    public required string Name { get; set; }
    public string? Description { get; set; }
    public string? Image { get; set; }

    // Colección de productos asociados
    public List<ProductCategory> Products { get; set; } = new List<ProductCategory>();

    // Navegación directa a Features (skip navigation)
    public List<Feature> Features { get; set; } = new List<Feature>();

    // Relación con CategoryFeatures
    public List<CategoryFeature> CategoryFeatures { get; set; } = new List<CategoryFeature>();

    // Relación con Department
    public Department? ParentDepartment { get; set; }
    public int DepartmentId { get; set; }
    public List<CategoryLog> Logs { get; set; } = new List<CategoryLog>();

    //Relacion con StoreCategories
    public List<StoreCategory.StoreCategory> StoreCategories { get; set; } = new();

    // Inversas para las dos relaciones many-to-many
    public ICollection<ApprovalProcessApprovedCategory> ApprovedInProcesses { get; set; } = new List<ApprovalProcessApprovedCategory>();
    public ICollection<ApprovalProcessRequestedCategory> RequestedInProcesses { get; set; } = new List<ApprovalProcessRequestedCategory>();
}