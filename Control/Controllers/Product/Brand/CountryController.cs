using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product.Brand;
using D_DStore.Domain.Models.Product.Brand;

public class CountryController : BaseController<CountryDTO>
{
    public CountryController(ICountryService service)
        : base(service, "Country") { }
}