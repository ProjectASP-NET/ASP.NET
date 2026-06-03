using Control.Controllers;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace Control.API.Controllers.Product
{
    public class ImageController : BaseController<ProductImageDTO>
{
    public ImageController(IImageService service)
        : base(service, "Image") { }
}
}

