using NTierApplication.DataAccess.Models;
using NTierApplication.Errors;
using NTierApplication.Repository;
using NTierApplication.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.Service
{
    public class ItemService : IItemService
    {
        private IItemRepository ItemRepository;

        public ItemService(IItemRepository itemRepository)
        {
            ItemRepository = itemRepository;
        }

        public void CreateNew(ItemViewModel item)
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
            ItemRepository.SaveChanges();
            item.ItemId = entity.ItemId;
        }

        public void Delete(long itemId)
        {
            throw new NotImplementedException();
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

            if (result == null)
            {
                throw new EntryNotFoundException("No such item");
            }
            return result;
            //.Where(x => x.ItemId == id)
            //.FirstOrDefault();
        }

        public ICollection<ItemViewModel> GetItems()
        {
            return ItemRepository.GetAll().Select(x => new ItemViewModel
            {
                ItemId = x.ItemId,
                ItemDate = x.ItemDate,
                ItemName = x.ItemName,
                ItemType = x.ItemType
            }).ToList();
        }

        public void Update(ItemViewModel item)
        {
            throw new NotImplementedException();
        }
    }
}
