using Workshop10_API.Api.Models;

namespace Workshop10_API.Api.Repositories
{
    public interface IUserRepository
    {
        Task<User?> GetByIdAsync(string nome, string passwordd, CancellationToken ct);
    }
}