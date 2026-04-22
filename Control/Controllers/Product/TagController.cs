using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models;

public class TagController : BaseController<TagDTO>
{
    public TagController(ITagService service)
        : base(service, "Tag") { }
}