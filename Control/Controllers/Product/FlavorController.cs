using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Control.API.Controllers.Product
{
    public class FlavorController : BaseController<FlavorDTO>
    {
        public FlavorController(IFlavorService service) : base(service, "Flavor")
        {
        }
    }
}

