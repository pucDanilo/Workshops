using System.Threading.Tasks;

namespace Danps.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> Commit();
    }
}