using Control.Controllers;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces;
using D_DStore.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Control.API.Controllers.Product
{
    public class ProductController : BaseController<ProductDTO>
{
    public ProductController(IBaseService<ProductDTO> service) : base(service, "Product"){}
}
}
