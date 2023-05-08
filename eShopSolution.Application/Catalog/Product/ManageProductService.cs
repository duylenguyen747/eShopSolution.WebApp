using eShopSolution.Application.Catalog.Product.DTOs;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.Data;
using eShopSolution.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eShopSolution.Application.Catalog.Product
{
	public class ManageProductService : IManageProductService
	{
		private readonly eShopSolutionDataContext _context;

		public ManageProductService(eShopSolutionDataContext context)
		{
			_context = context;
		}
		public async Task<int> Create(ProductCreateRequest request)
		{
			var product = new Product()
			{
				Price = request.Price
			};
			_context.Products.Add(product); 
			return await _context.SaveChangesAsync();
		}

		public Task<int> Delete(int ProductId)
		{
			throw new NotImplementedException();
		}

		public Task<List<ProductViewModel>> GetAll()
		{
			throw new NotImplementedException();
		}

		public Task<PagedViewModel<ProductViewModel>> GetAllPaging(string keyword, int pageIndex, int pageSize)
		{
			throw new NotImplementedException();
		}

		public Task<int> Update(ProductEditRequest request)
		{
			throw new NotImplementedException();
		}
	}
}
