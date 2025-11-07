using Danps.Core.DomainObjects.DTO;

namespace Danps.Core.Data
{
    public interface IRawQuery
    {
        string GetQuery();

        string GetCountQuery();

        string GetQuery(int pageNumber, int maxResults);

        Parameter[] GetParameters();
    }
}