using NTierApplication.DataAccess.Models;

namespace NTierApplication.Repository;

public interface IItemRepository
{
    void Insert(Item item);
    void Update(Item item);
    void Delete(Item item);
    IQueryable<Item> GetAll();
    int SaveChanges();
}
