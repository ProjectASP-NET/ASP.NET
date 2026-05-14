using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models.Product;

public class ConsumableController : BaseController<ConsumableDTO>
{
    public ConsumableController(IConsumableService service)
        : base(service, "Consumable") { }
}