using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces;
using D_DStore.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Control.API.Controllers.Product
{
    public class FlavorController : BaseController<FlavorDTO>
    {
        public FlavorController(IBaseService<FlavorDTO> service) : base(service, "Flavor")
        {
        }
    }
}
