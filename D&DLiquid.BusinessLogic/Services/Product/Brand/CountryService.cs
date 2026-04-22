using D_DLiquid.DataAccess.Interfaces;
using D_DStore.BusinessLogic.Interfaces.Product.Brand;
using D_DStore.Domain.Entities.BaseProduct.Brand;
using D_DStore.Domain.Models.Product.Brand;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace D_DStore.BusinessLogic.Services.Product.Brand
{
    public class CountryService : BaseService<CountryData,CountryDTO> , ICountryService
    {
        public CountryService(IRepository<CountryData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}
