using eShopSolution.Application.Catalog.Product.DTOs;
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
		Task<int> Update(ProductEditRequest request);
		Task<int> Delete(int ProductId);
		Task<List<ProductViewModel>> GetAll();
		Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize);
	}
}
