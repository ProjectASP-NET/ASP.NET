using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models.Product;

public class VapeController : BaseController<VapeDTO>
{
    public VapeController(IVapeService service)
        : base(service, "Vape") { }
}