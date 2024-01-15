using NTierApplication.DataAccess.Models;
using NTierApplication.DataAccess.Utils;
using NTierApplication.Errors;
using NTierApplication.Repository;
using NTierApplication.Service.Common.Interface;
using NTierApplication.Service.ViewModels;

namespace NTierApplication.Service;

public class ItemService : IItemService
{
    private IItemRepository ItemRepository;
    private readonly IPaginator _paginator;

    public ItemService(IItemRepository itemRepository, IPaginator paginator)
    {
        ItemRepository = itemRepository;
        this._paginator = paginator;
    }

    public int CreateNew(ItemViewModel item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        if (string.IsNullOrWhiteSpace(item.ItemName))
        {
            throw new ParameterInvalidException("ItemName cannot be empty");
        }
        if (item.ItemType < 0)
        {
            throw new ParameterInvalidException("Item type must be equal or greater than 0");
        }

        var entity = new Item
        {
            ItemDate = item.ItemDate,
            ItemName = item.ItemName,
            ItemType = item.ItemType
        };
        ItemRepository.Insert(entity);
        int result=ItemRepository.SaveChanges();
        item.ItemId = entity.ItemId;

        return result;
    }

    public void Delete(long itemId)
    {
        var result = ItemRepository.
            GetAll().
            Where(x => x.ItemId == itemId).
            FirstOrDefault();
        if (result == null)
        {
            throw new ArgumentNullException(nameof(Item));
        }
        ItemRepository.Delete(result);
        ItemRepository.SaveChanges();

    }

    public ItemViewModel GetById(long id)
    {
        var result = ItemRepository.GetAll()
            .Select(x => new ItemViewModel
            {
                ItemId = x.ItemId,
                ItemDate = x.ItemDate,
                ItemName = x.ItemName,
                ItemType = x.ItemType
            })
            .FirstOrDefault(x => x.ItemId == id);
        //.Where(x => x.ItemId == id)
        //.FirstOrDefault();

        if (result == null)
        {
            throw new EntryNotFoundException("No such item");
        }
        return result;

    }

    public ICollection<ItemViewModel> GetItems(PaginationParams @params)
    {
        var items = ItemRepository.GetAll()
        .Skip(@params.GetSkipCount())
        .Take(@params.PageSize)
        .ToList();

        long itemCount = ItemRepository.GetAll().Count();
        _paginator.Paginate(itemCount, @params);

        return items.Select(x => new ItemViewModel
        {
            ItemId = x.ItemId,
            ItemDate = x.ItemDate,
            ItemName = x.ItemName,
            ItemType = x.ItemType
        }).ToList();
    }

    public void Update(ItemViewModel item)
    {
        if (item == null)
        {
            throw new ArgumentNullException(nameof(item));
        }
        var result = ItemRepository.GetAll().
            Where(x => x.ItemId == item.ItemId).
            FirstOrDefault();
        if (result == null)
        {
            throw new EntryNotFoundException("No such item");
        }

        result.ItemId =(long) item.ItemId;
        result.ItemDate = item.ItemDate;
        result.ItemName = item.ItemName;
        result.ItemType = item.ItemType;

        ItemRepository.Update(result);
        ItemRepository.SaveChanges();
    }
}
