using NTierApplication.DataAccess.Utils;

namespace NTierApplication.Service.Common.Interface;

public interface IPaginator
{
    public void Paginate(long itemsCount, PaginationParams @params);
}
