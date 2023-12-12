using NTierApplication.Service.ViewModels;

namespace NTierApplication.Service
{
    public interface IItemService
    {
        void CreateNew(ItemViewModel item);
        void Update(ItemViewModel item);
        void Delete(long itemId);
        ICollection<ItemViewModel> GetItems();
    }
}
