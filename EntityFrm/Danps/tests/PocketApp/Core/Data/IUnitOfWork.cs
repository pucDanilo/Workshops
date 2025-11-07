using System.Threading.Tasks;

namespace PocketApp.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}