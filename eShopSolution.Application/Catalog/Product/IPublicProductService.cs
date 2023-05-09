
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.Product.Public;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Product
{
    public interface IPublicProductService
    {
        Task<PagedResult<ProductViewModel>> GetAllByCategoryId(GetProducPagingRequest request);
    }
}
