using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models;

public class CategoryController : BaseController<CategoryDTO>
{
    public CategoryController(ICategoryService service)
        : base(service, "Category") { }
}

