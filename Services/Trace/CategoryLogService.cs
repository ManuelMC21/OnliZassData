using onlizas.Data;
using onlizas.Entities;


namespace onlizas.Services.Trace;

public class CategoryLogService : EntityLogService<Category, CategoryLog>
{
    public CategoryLogService(AppDbContext db) : base(db) { }

    protected override void SetCommonLogProperties(
        CategoryLog log,
        int entityId,
        int userId,
        string typeAction,
        Category newEntity,
        Category? oldEntity)
    {
        log.CategoryId = entityId;
        log.CategoryName = newEntity.Name;
        log.DepartmentId = newEntity.DepartmentId;
        log.DepartmentName = newEntity.ParentDepartment?.Name ?? "N/A";
        log.UserId = userId;
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(Category entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre", entity.Name),
            ("Descripción", entity.Description),
            ("Esta activa", entity.IsActive.ToString()),
            ("Imagen", entity.Image ?? "N/A"),
            ("Departamento", entity.ParentDepartment?.Name ?? "N/A"),
            ("Productos", entity.Products?.Select(p => p.Product.Name) ?? Enumerable.Empty<string>())
        };
    }
}