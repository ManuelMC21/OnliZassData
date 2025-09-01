using onlizas.Data;
using onlizas.Entities;
using onlizas.Entities.Trace;


namespace onlizas.Services.Trace;

public class BusinessLogService : EntityLogService<Business, BusinessLog>
{
    public BusinessLogService(OnlizasDb db) : base(db) { }

    protected override void SetCommonLogProperties(
        BusinessLog log,
        int entityId,
        int userId,
        string typeAction,
        Business newEntity,
        Business? oldEntity)
    {
        log.BusinessGuid = newEntity.Guid;
        log.UserId = userId;

        // Datos básicos del negocio
        log.BusinessName = newEntity.Name;
        log.BusinessCode = newEntity.Code;

        // Propietario
        log.OwnerId = newEntity.OwnerId;
        log.OwnerName = newEntity.Owner?.Name ?? "Desconocido";

        // Ubicación
        log.LocationId = newEntity.LocationId;
        log.LocationName = newEntity.Location?.Name ?? "N/A";
    }

    protected override List<(string name, object? value)> GetPropertiesToLog(Business entity)
    {
        return new List<(string name, object? value)>
        {
            ("Nombre", entity.Name),
            ("Código", entity.Code),
            ("Descripción", entity.Description),
            ("Dirección", entity.Address),
            ("Email", entity.Email),
            ("Teléfono", entity.Phone),
            ("Es primario", entity.IsPrimary ? "Sí" : "No"),
            ("Tarifa fija", entity.FixedRate.ToString("F2")),
            ("Texto de factura", entity.InvoiceText),
            ("HBL Inicial", entity.HBLInitial),
            ("Cantidad de fotos", entity.PhotoObjectCodes.Length),
            ("Ubicación", entity.Location?.Name ?? "N/A"),
            ("Propietario", entity.Owner?.Name ?? "N/A")
        };
    }
}