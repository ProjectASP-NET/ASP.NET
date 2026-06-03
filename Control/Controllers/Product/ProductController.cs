using Control.Controllers;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Control.API.Controllers.Product
{
    public class ProductController : BaseController<ProductDTO>
{
    public ProductController(IProductService service) : base(service, "Product"){}
}
}

