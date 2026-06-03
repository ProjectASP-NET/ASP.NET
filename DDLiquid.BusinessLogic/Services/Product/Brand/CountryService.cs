using DDLiquid.DataAccess.Interfaces;
using DDLiquid.BusinessLogic.Interfaces.Product.Brand;
using DDLiquid.Domain.Entities.BaseProduct.Brand;
using DDLiquid.Domain.Models.Product.Brand;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;

namespace DDLiquid.BusinessLogic.Services.Product.Brand
{
    public class CountryService : BaseService<CountryData,CountryDTO> , ICountryService
    {
        public CountryService(IRepository<CountryData> repo, IMapper mapper) : base(repo, mapper) { }
    }
}

