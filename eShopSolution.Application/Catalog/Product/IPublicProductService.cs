﻿using eShopSolution.Application.Catalog.Product.DTOs;
using eShopSolution.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Product
{
    public interface IPublicProductService
    {
        PagedResult<ProductViewModel> GetAllByCategoryId();
    }
}