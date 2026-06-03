using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models.Product;

public class VapeController : BaseController<VapeDTO>
{
    public VapeController(IVapeService service)
        : base(service, "Vape") { }
}
