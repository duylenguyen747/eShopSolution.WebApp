using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Common;
using eShopSolution.ViewModels.Catalog.Product.Manage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Product
{
    public interface IManageProductService
	{
		Task<int> Create(ProductCreateRequest request);
		Task<int> Update(ProductUpdateRequest request);
		Task<int> Delete(int ProductId);
		Task<bool> UpdatePrice(int ProductId, decimal newPrice);
		Task<bool> UpdateStock(int ProductId, int addedQuantity);
		Task AddViewCount(int ProductId);
		Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
	}
}
