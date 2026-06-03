using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models;

public class TagController : BaseController<TagDTO>
{
    public TagController(ITagService service)
        : base(service, "Tag") { }
}
