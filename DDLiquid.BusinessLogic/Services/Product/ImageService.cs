using AutoMapper;
using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product;
using DDLiquid.Domain.Entities.BaseProduct;
using DDLiquid.Domain.Models.Product;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.BusinessLogic.Services.Product
{
    public class ImageService : BaseService<ProductImageData , ProductImageDTO> , IImageService
    {
        public ImageService(IRepository<ProductImageData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}

