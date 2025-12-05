using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using Workshops.Domain.Models;
using Workshops.Domain.Repository;
using Workshops.Infrastructure.Context;
using Danps.Core.Data;

namespace Workshops.Api.Repositories;

public class WorkshopRepository : IWorkshopRepository
{
    private readonly WorkshopsDbContext _context;

    public WorkshopRepository(WorkshopsDbContext context)
    {
        _context = context;
    }

    public IUnitOfWork UnitOfWork => _context;

    public DbConnection GetConnection()
    {
        return _context.Database.GetDbConnection();
    }

    public async Task<IReadOnlyList<Workshop>> GetAllAsync(DateTimeOffset? from, DateTimeOffset? to, string? q, CancellationToken ct)
    {
        var query = _context.Workshops.AsNoTracking().AsQueryable();
        if (from.HasValue)
        {
            query = query.Where(w => w.StartAt >= from.Value);
        }
        if (to.HasValue)
        {
            query = query.Where(w => w.EndAt >= to.Value);
        }
        if (!string.IsNullOrWhiteSpace(q))
        {
            var termo = q.ToLowerInvariant();
            query = query.Where(w => w.Title.Contains(termo) || w.Description.Contains(termo));
        }
        Console.WriteLine(query.ToQueryString());
        return await query.ToListAsync(ct);
    }

    public async Task<Workshop?> GetByIdAsync(Guid id, CancellationToken ct)
        => await _context.Workshops.AsNoTracking().FirstOrDefaultAsync(w => w.Id == id, ct);

    public async Task<Workshop> AddAsync(Workshop workshop, CancellationToken ct)
    {
        _context.Workshops.Add(workshop);
        await _context.SaveChangesAsync();
        return workshop;
    }

    public async Task<Workshop?> UpdateAsync(Workshop workshop, CancellationToken ct)
    {
        _context.Workshops.Update(workshop);
        await _context.SaveChangesAsync(ct);
        return workshop;
    }

    public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
    {
        var encontrado = await _context.Workshops.FindAsync([id]);
        if (encontrado == null)
        {
            return false;
        }
        _context.Workshops.Remove(encontrado);
        await _context.SaveChangesAsync();
        return true;
    }

    public Task<bool> ExistsAsync(Guid id, CancellationToken ct)
        => _context.Workshops.AnyAsync(w => w.Id == id, ct);

    public async Task<Workshop?> UpdatePartialAsync(Guid id, Action<Workshop> updateAction, CancellationToken ct)
    {
        var w = await _context.Workshops.FirstOrDefaultAsync(x => x.Id == id, ct);
        // TODO: implementar o UpdatePartial
        return w;
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}