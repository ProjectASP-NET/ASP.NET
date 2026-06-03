using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models.Product;

public class LiquidController : BaseController<LiquidDTO>
{
    public LiquidController(ILiquidService service)
        : base(service, "Liquid") { }
}

