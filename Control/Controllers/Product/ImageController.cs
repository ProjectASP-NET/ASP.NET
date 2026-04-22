using Control.Controllers;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Control.API.Controllers.Product
{
    public class ImageController : BaseController<ProductImageDTO>
{
    public ImageController(IImageService service)
        : base(service, "Image") { }
}
}
