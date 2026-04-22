using AutoMapper;
using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces.Product;
using D_DStore.Domain.Entities.BaseProduct;
using D_DStore.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.BusinessLogic.Services.Product
{
    public class ImageService : BaseService<ProductImageData , ProductImageDTO> , IImageService
    {
        public ImageService(IRepository<ProductImageData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
