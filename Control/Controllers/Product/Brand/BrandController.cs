using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product.Brand;
using D_DStore.Domain.Models.Product.Brand;

public class BrandController : BaseController<BrandDTO>
{
    public BrandController(IBrandService service)
        : base(service, "Brand") { }
}