using Microsoft.AspNetCore.Mvc;
using NTierApplication.Service;
using NTierApplication.Service.ViewModels;
using Swashbuckle.AspNetCore.Annotations;

namespace NTierApplication.Web.Controllers;

[ApiController]
[Route("api/item")]
public class ItemController : ControllerBase
{
    private readonly IItemService ItemService;

    public ItemController(IItemService itemService)
    {
        ItemService = itemService;
    }

    [HttpGet]
    public ICollection<ItemViewModel> GetAll()
    {
        return ItemService.GetItems();
    }

    [HttpGet("{id}")]
    public ItemViewModel GetById(long id)
    {
        return ItemService.GetById(id);
    }

    [HttpPost]
    public ItemViewModel CreateNew(ItemViewModel itemViewModel)
    {
        ItemService.CreateNew(itemViewModel);
        return itemViewModel;
    }

    [HttpDelete]
    public void DeleteById(long id)
    {
        ItemService.Delete(id);
    }
    [HttpPut]
    public ItemViewModel Update(ItemViewModel itemViewModel)
    {
        ItemService.Update(itemViewModel);
        return itemViewModel;
    }
}
