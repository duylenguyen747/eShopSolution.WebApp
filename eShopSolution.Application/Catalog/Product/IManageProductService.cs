using eShopSolution.Application.Catalog.Product.DTOs;
using eShopSolution.Application.Catalog.Product.DTOs.Manage;
using eShopSolution.Application.Dtos;
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
		Task<List<ProductViewModel>> GetAll();
		Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request);
	}
}
