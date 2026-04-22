using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models.Product;

public class VapesController : BaseController<VapeDTO>
{
    public VapesController(IVapeService service)
        : base(service, "Vape") { }
}