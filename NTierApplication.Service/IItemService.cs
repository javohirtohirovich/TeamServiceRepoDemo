using NTierApplication.DataAccess.Utils;
using NTierApplication.Service.ViewModels;

namespace NTierApplication.Service
{
    public interface IItemService
    {
        int CreateNew(ItemViewModel item);
        void Update(ItemViewModel item);
        void Delete(long itemId);
        ItemGetAllViewModel GetItems(PaginationParams @params);
        ItemViewModel GetById(long id);
    }
}
