using Danps.Core.Data;
using Danps.My.Domain.Models;

namespace Danps.My.Data.Repository
{
    public class MyClassRepository : Repository<MyClass>, IMyClassRepository
    {
        public MyClassRepository(MyApplicationContext context) : base(context)
        {
        }
    }
}