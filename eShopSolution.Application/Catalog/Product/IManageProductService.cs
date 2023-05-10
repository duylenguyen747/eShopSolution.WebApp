using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace eShopSolution.Application.Catalog.Product
{
    public interface IManageProductService
	{
		Task<int> Create(ProductCreateRequest request);
		Task<int> Update(ProductUpdateRequest request);
		Task<int> Delete(int productId);
		Task<bool> UpdatePrice(int productId, decimal newPrice);
		Task<bool> UpdateStock(int productId, int addedQuantity);
		Task AddViewCount(int productId);
		Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request);
		Task<int> AddImages(int  ProductId, List<IFormFile> files);
		Task<int> UpdateImages(int imageId, string caption, bool Default);
		Task<int> DeleteImages(int imageId);
		Task<List<ProductImageViewModel>> GetListImage(int  productId);
	}
}
