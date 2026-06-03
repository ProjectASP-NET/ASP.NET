using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models.Product;

public class ConsumableController : BaseController<ConsumableDTO>
{
    public ConsumableController(IConsumableService service)
        : base(service, "Consumable") { }
}
