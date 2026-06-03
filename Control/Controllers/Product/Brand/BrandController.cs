using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product.Brand;
using DDLiquid.Domain.Models.Product.Brand;

public class BrandController : BaseController<BrandDTO>
{
    public BrandController(IBrandService service)
        : base(service, "Brand") { }
}
