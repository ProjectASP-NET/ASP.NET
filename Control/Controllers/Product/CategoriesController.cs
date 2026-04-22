using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models;

public class CategoryController : BaseController<CategoryDTO>
{
    public CategoryController(ICategoryService service)
        : base(service, "Category") { }
}
