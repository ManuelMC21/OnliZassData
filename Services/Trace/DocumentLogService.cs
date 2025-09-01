using onlizas.Data;
using onlizas.Entities;
using onlizas.Entities.Trace;


namespace onlizas.Services.Trace;

public class DocumentLogService : EntityLogService<Document, DocumentLog>
{
    public DocumentLogService(OnlizasDb db) : base(db) { }

    protected override void SetCommonLogProperties(
    DocumentLog log,
    int entityId,
    int userId,
    string typeAction,
    Document newEntity,
    Document? oldEntity)
    {
        log.DocumentId = entityId;
        log.UserId = userId;


        log.FileName = newEntity.FileName;
        log.Content = newEntity.Content;
        log.IsApproved = newEntity.IsApproved;
        log.IsMandatory = newEntity.IsMandatory;
        log.ValidationDate = newEntity.ValidationDate;
        log.RejectionReason = newEntity.RejectionReason;
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(Document entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre del archivo", entity.FileName),
            ("Aprobado", entity.IsApproved ? "Sí" : "No"),
            ("Obligatorio", entity.IsMandatory ? "Sí" : "No"),
            ("Fecha de validación", entity.ValidationDate?.ToString("yyyy-MM-dd HH:mm") ?? "N/A"),
            ("Motivo de rechazo", entity.RejectionReason ?? "N/A"),
        };
    }
}