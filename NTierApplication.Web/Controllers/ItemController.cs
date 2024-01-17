using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NTierApplication.DataAccess.Utils;
using NTierApplication.Service;
using NTierApplication.Service.ViewModels;

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

    [Authorize]
    [HttpGet]
    public ItemGetAllViewModel GetAll(int page=1,int pageSize=10)
    {
        return ItemService.GetItems(new PaginationParams(page,pageSize));
    }

    [HttpGet("{id}")]
    [Authorize]
    public ItemViewModel GetById(long id)
    {
        return ItemService.GetById(id);
    }

    [HttpPost]
    [Authorize]
    public ItemViewModel CreateNew(ItemViewModel itemViewModel)
    {
        ItemService.CreateNew(itemViewModel);
        return itemViewModel;
    }
    [Authorize]
    [HttpDelete]
    public void DeleteById(long id)
    {
        ItemService.Delete(id);
    }

    [HttpPut]
    [Authorize]
    public ItemViewModel Update(ItemViewModel itemViewModel)
    {
        ItemService.Update(itemViewModel);
        return itemViewModel;
    }
}
