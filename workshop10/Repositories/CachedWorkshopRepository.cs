using Workshop10_API.Api.Models;

namespace Workshop10_API.Api.Repositories
{
    using Microsoft.Extensions.Caching.Memory;
    using Microsoft.Extensions.Options;
    using System;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public sealed class CachedWorkshopRepository : IWorkshopRepository
    {
        private readonly IWorkshopRepository _inner;
        private readonly IMemoryCache _cache;
        private readonly TimeSpan _ttl;

        public CachedWorkshopRepository(
            IWorkshopRepository inner,
            IMemoryCache cache,
            IOptionsSnapshot<Services.CacheSettings> opts)
        {
            _inner = inner;
            _cache = cache;
            _ttl = TimeSpan.FromSeconds(opts.Value.DefaultTtlSeconds);
        }

        private static string KeyById(Guid id) => $"workshops:byId:{id}";

        private static string KeyList(DateTimeOffset? from, DateTimeOffset? to, string? q)
            => $"workshops:list:{from?.ToUnixTimeSeconds()}:{to?.ToUnixTimeSeconds()}:{q?.Trim().ToLowerInvariant()}";

        // TODO #2A implementado
        public async Task<IReadOnlyList<Workshop>> GetAllAsync(
            DateTimeOffset? from, DateTimeOffset? to, string? q, CancellationToken ct)
        {
            var key = KeyList(from, to, q);

            if (_cache.TryGetValue(key, out IReadOnlyList<Workshop> cachedList))
            {
                return cachedList;
            }

            var result = await _inner.GetAllAsync(from, to, q, ct);
            _cache.Set(key, result, _ttl);
            return result;
        }

        // TODO #2B implementado
        public async Task<Workshop?> GetByIdAsync(Guid id, CancellationToken ct)
        {
            var key = KeyById(id);

            if (_cache.TryGetValue(key, out Workshop cachedWorkshop))
            {
                return cachedWorkshop;
            }

            var result = await _inner.GetByIdAsync(id, ct);
            if (result != null)
            {
                _cache.Set(key, result, _ttl);
            }

            return result;
        }

        public async Task<Workshop> AddAsync(Workshop workshop, CancellationToken ct)
        {
            var w = await _inner.AddAsync(workshop, ct);
            _cache.Remove(KeyById(w.Id));
            return w;
        }

        public async Task<Workshop?> UpdateAsync(Workshop workshop, CancellationToken ct)
        {
            var w = await _inner.UpdateAsync(workshop, ct);
            if (w is not null) _cache.Remove(KeyById(w.Id));
            return w;
        }

        public async Task<bool> DeleteAsync(Guid id, CancellationToken ct)
        {
            var ok = await _inner.DeleteAsync(id, ct);
            if (ok) _cache.Remove(KeyById(id));
            return ok;
        }

        public Task<bool> ExistsAsync(Guid id, CancellationToken ct)
            => _inner.ExistsAsync(id, ct);

        public async Task<Workshop?> UpdatePartialAsync(Guid id, Action<Workshop> updateAction, CancellationToken ct)
        {
            var w = await _inner.UpdatePartialAsync(id, updateAction, ct);
            if (w is not null) _cache.Remove(KeyById(w.Id));
            return w;
        }
    }
}