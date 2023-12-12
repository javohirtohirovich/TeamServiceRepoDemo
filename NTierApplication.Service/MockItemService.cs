using NTierApplication.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NTierApplication.Service
{
    public class MockItemService : IItemService
    {
        public void CreateNew(ItemViewModel item)
        {
            
        }

        public void Delete(long itemId)
        {
            
        }

        public ICollection<ItemViewModel> GetItems()
        {
            return new List<ItemViewModel>();
        }

        public void Update(ItemViewModel item)
        {
            
        }
    }
}
