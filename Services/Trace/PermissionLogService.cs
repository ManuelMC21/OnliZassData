using onlizas.Data;
using onlizas.Entities.Permissions;
using onlizas.Entities.Trace;


namespace onlizas.Services.Trace;

public class PermissionLogService : EntityLogService<Permission, PermissionLog>
{
    public PermissionLogService(AppDbContext db) : base(db) { }

    protected override void SetCommonLogProperties(
        PermissionLog log,
        int entityId,
        int userId,
        string typeAction,
        Permission newEntity,
        Permission? oldEntity)
    {
        log.PermissionName = newEntity.Name;
        log.PermissionCode = newEntity.Code;
        log.PermissionEntity = newEntity.Entity;
        log.PermissionType = newEntity.PermissionType?.ToString();
        log.PermissionDescription = newEntity.Description;

        log.UserId = userId;
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(Permission entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre", entity.Name),
            ("Código", entity.Code),
            ("Entidad", entity.Entity ?? "N/A"),
            ("Tipo de permiso", entity.PermissionType?.ToString() ?? "N/A"),
            ("Descripción", entity.Description ?? "N/A")
        };
    }
}