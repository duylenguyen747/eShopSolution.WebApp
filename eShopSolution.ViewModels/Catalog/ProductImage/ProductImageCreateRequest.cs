﻿using Microsoft.AspNetCore.Http;

namespace eShopSolution.ViewModels.Catalog.ProductImage
{
    public class ProductImageCreateRequest
    {
        public string Caption { get; set; }

        public bool IsDefault { get; set; }

        public int SortOrder { get; set; }

        public IFormFile ImageFile { get; set; }
    }
}