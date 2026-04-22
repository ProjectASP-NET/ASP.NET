using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models.Product;

public class LiquidController : BaseController<LiquidDTO>
{
    public LiquidController(ILiquidService service)
        : base(service, "Liquid") { }
}
