using Workshops.Domain.Models;
using Danps.Core.Data;

namespace Workshops.Domain.Repository;

public interface IWorkshopRepository : IRepository<Workshop>
{
    Task<IReadOnlyList<Workshop>> GetAllAsync(DateTimeOffset? from, DateTimeOffset? to, string? q, CancellationToken ct);

    Task<Workshop?> GetByIdAsync(Guid id, CancellationToken ct);

    Task<Workshop> AddAsync(Workshop workshop, CancellationToken ct);

    Task<Workshop?> UpdateAsync(Workshop workshop, CancellationToken ct);

    Task<bool> DeleteAsync(Guid id, CancellationToken ct);

    Task<bool> ExistsAsync(Guid id, CancellationToken ct);

    Task<Workshop?> UpdatePartialAsync(Guid id, Action<Workshop> updateAction, CancellationToken ct);
}