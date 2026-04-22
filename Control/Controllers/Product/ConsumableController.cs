using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models.Product;

public class ConsumablesController : BaseController<ConsumableDTO>
{
    public ConsumablesController(IConsumableService service)
        : base(service, "Consumable") { }
}