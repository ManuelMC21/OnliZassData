namespace onlizas.Services;

public interface IEntityLogService<T, TLog>
    where T : class
    where TLog : class, new()
{
    Task CreateLogAsync(
        int entityId,
        int userId,
        T newEntity,
        T? oldEntity,
        string typeAction,
        CancellationToken ct);
}
