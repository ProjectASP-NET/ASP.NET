using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product.Brand;
using DDLiquid.Domain.Models.Product.Brand;

public class CountryController : BaseController<CountryDTO>
{
    public CountryController(ICountryService service)
        : base(service, "Country") { }
}
