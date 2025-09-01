using onlizas.Data;
using onlizas.Entities;
using onlizas.Entities.Trace;

namespace onlizas.Services.Trace;

public class RoleLogService : EntityLogService<Role, RoleLog>
{
    public RoleLogService(AppDbContext db) : base(db) { }

    protected override void SetCommonLogProperties(
        RoleLog log,
        int entityId,
        int userId,
        string typeAction,
        Role newEntity,
        Role? oldEntity)
    {
        log.RoleGuid = newEntity.Guid;
        log.RoleName = newEntity.Name;
        log.RoleCode = newEntity.Code;
        log.RoleDescription = newEntity.Description;

        log.UserId = userId;
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(Role entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre", entity.Name),
            ("Código", entity.Code),
            ("Descripción", entity.Description ?? "N/A"),
            ("Subsistema ID", entity.SubSystemId)
        };
    }

    
}