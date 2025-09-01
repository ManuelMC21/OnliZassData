using Microsoft.EntityFrameworkCore;
using onlizas.Data;
using System.Reflection;
using System.Text;

namespace onlizas.Services.Trace;

public class EntityLogService<T, TLog> : IEntityLogService<T, TLog>
    where T : class
    where TLog : class, new()
{
    protected readonly OnlizasDb _db;

    public EntityLogService(OnlizasDb db)
    {
        _db = db;
    }

    public async Task CreateLogAsync(
        int entityId,
        int userId,
        T newEntity,
        T? oldEntity,
        string typeAction,
        CancellationToken ct)
    {
        var log = new TLog();

        // Usamos reflexión para asignar propiedades comunes
        SetCommonLogProperties(log, entityId, userId, typeAction, newEntity, oldEntity);

        var description = GenerateDescription(newEntity, oldEntity, typeAction);

        // Asignar la descripción al log (por reflexión)
        var descriptionProp = typeof(TLog).GetProperty("Description");
        if (descriptionProp != null && descriptionProp.CanWrite)
        {
            descriptionProp.SetValue(log, description);
        }

        // Asumimos que TLog tiene una propiedad `Timestamp` 
        var timestampProp = typeof(TLog).GetProperty("Timestamp");
        if (timestampProp != null && timestampProp.CanWrite)
        {
            timestampProp.SetValue(log, DateTime.UtcNow);
        }

        // Agregar al contexto y guardar
        var dbSet = _db.Set<TLog>();
        dbSet.Add(log);
        await _db.SaveChangesAsync(ct);
    }

    protected virtual void SetCommonLogProperties(
        TLog log,
        int entityId,
        int userId,
        string typeAction,
        T newEntity,
        T oldEntity)
    {
        // Este método puede sobre-escribirse si hay propiedades específicas (ej: DepartmentId)
        // Por defecto, no hace nada. Útil para clases derivadas.
    }

    protected virtual string GenerateDescription(T newEntity, T? oldEntity, string typeAction)
    {
        var description = new StringBuilder();
        description.AppendLine($"Tipo de acción: {typeAction}");

        if (oldEntity == null)
        {
            var properties = GetPropertiesToLog(newEntity);
            foreach (var (name, value) in properties)
            {
                description.AppendLine($"{name}: {FormatValue(value)} (Valor inicial)");
            }
        }
        else
        {
            var newProps = GetPropertiesToLog(newEntity);
            var oldProps = GetPropertiesToLog(oldEntity);

            foreach (var (name, newVal) in newProps)
            {
                var oldVal = oldProps.FirstOrDefault(p => p.name == name).value;
                var changeDesc = GetFieldChangeDescription(name, FormatValue(oldVal), FormatValue(newVal));
                description.AppendLine(changeDesc);
            }
        }

        return description.ToString();
    }

    protected virtual List<(string name, object? value)> GetPropertiesToLog(T entity)
    {
        // Usa reflexión para obtener propiedades relevantes
        // Puedes personalizar esto con atributos o nombres específicos
        var props = new List<(string name, object? value)>();

        foreach (var prop in entity.GetType().GetProperties())
        {
            // Ignorar colecciones grandes, navegación, etc.
            if (IsIgnoredProperty(prop)) continue;

            var displayName = GetDisplayName(prop);
            var value = prop.GetValue(entity);

            props.Add((displayName, value));
        }

        return props;
    }

    protected virtual bool IsIgnoredProperty(PropertyInfo prop)
    {
        var ignoredTypes = new[] { typeof(IEnumerable<>), typeof(DbContext), typeof(byte[]) };
        return prop.Name.EndsWith("Id") || // evita duplicados como CategoryId
               prop.GetMethod?.IsVirtual == true && !prop.PropertyType.IsValueType &&
               !ignoredTypes.Any(t => t.IsAssignableFrom(prop.PropertyType)) == false;
    }

    protected virtual string GetDisplayName(PropertyInfo prop)
    {
        // Aquí puedes usar atributos personalizados como [Display(Name="...")]
        // Por ahora, mapeo simple
        return prop.Name switch
        {
            "Name" => "Nombre",
            "Description" => "Descripción",
            "IsActive" => "Esta activa",
            "Image" => "Imagen",
            "Rate" => "Tasa",
            "Symbol" => "Simbolo",
            "Default" => "Por defecto",
            "ParentDepartment" => "Departamento",
            _ => prop.Name
        };
    }

    protected virtual string FormatValue(object? value)
    {
        return value switch
        {
            null => "null",
            decimal d => d.ToString("F4"),
            double d => d.ToString("F4"),
            float f => f.ToString("F4"),
            bool b => b ? "Sí" : "No",
            IEnumerable<object> list when list.Any() => string.Join(", ", list.Select(x => x?.ToString() ?? "N/A")),
            IEnumerable<object> => "N/A",
            _ => value.ToString() ?? "null"
        };
    }

    protected virtual string GetFieldChangeDescription(string fieldName, string oldValue, string newValue)
    {
        oldValue ??= "null";
        newValue ??= "null";

        if (decimal.TryParse(oldValue, out decimal oldDecimal) && decimal.TryParse(newValue, out decimal newDecimal))
        {
            return oldDecimal == newDecimal
                ? $"{fieldName} se mantuvo en '{newValue}'"
                : $"{fieldName} cambió de '{oldValue}' a '{newValue}'";
        }
        else
        {
            return oldValue.Equals(newValue, StringComparison.OrdinalIgnoreCase)
                ? $"{fieldName} se mantuvo en '{newValue}'"
                : $"{fieldName} cambió de '{oldValue}' a '{newValue}'";
        }
    }
}