using onlizas.Data;
using onlizas.Entities.Trace;
using onlizas.Entities;

namespace onlizas.Services.Trace;

public class DepartmentLogService : EntityLogService<Department, DepartmentLog>
{
    public DepartmentLogService(AppDbContext db) : base(db) { }

    protected override void SetCommonLogProperties(
        DepartmentLog log,
        int entityId,
        int userId,
        string typeAction,
        Department newEntity,
        Department? oldEntity)
    {
        log.DepartmentId = entityId;
        log.UserId = userId;   
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(Department entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre", entity.Name),
            ("Descripción", entity.Description),
            ("Imagen", entity.Image ?? "N/A")
        };
    }
}