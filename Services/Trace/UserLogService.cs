using Microsoft.EntityFrameworkCore;
using onlizas.Data;
using onlizas.Entities.Trace;
using onlizas.Entities.Users;


namespace onlizas.Services.Trace;

public class UserLogService : EntityLogService<User, UserLog>
{
    private readonly AppDbContext _db;
    public UserLogService(AppDbContext db) : base(db) { _db = db; }

    protected override void SetCommonLogProperties(
        UserLog log,
        int entityId,
        int userId,
        string typeAction,
        User newEntity,
        User? oldEntity)
    {
        log.UserId = entityId;
        log.UserName = newEntity.Name;
        log.UserEmail = newEntity.Emails.FirstOrDefault()?.Address ?? "N/A";
        log.IsBlocked = newEntity.IsBlocked;
        log.IsVerified = newEntity.IsVerified;
        log.ApiRole = newEntity.ApiRole;
        log.ChangedById = userId;
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(User entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre", entity.Name),
            ("Bloqueado", entity.IsBlocked ? "Sí" : "No"),
            ("Verificado", entity.IsVerified ? "Sí" : "No"),
            ("Rol API", entity.ApiRole.ToString()),
            ("Foto", entity.PhotoObjectCode ?? "N/A"),
            ("Benefactor ID", entity.BenefactorId?.ToString() ?? "N/A"),
            ("Email principal", entity.Emails.FirstOrDefault()?.Address ?? "N/A")
        };
    }


}