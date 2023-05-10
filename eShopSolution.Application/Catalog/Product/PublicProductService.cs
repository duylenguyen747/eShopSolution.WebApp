
using eShopSolution.ViewModels.Common;
using eShopSolution.Data.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Catalog.ProductImage;

namespace eShopSolution.Application.Catalog.Product
{
    public class PublicProductService : IPublicProductService
	{
		private readonly eShopSolutionDataContext _context;

		public PublicProductService(eShopSolutionDataContext context)
		{
			_context = context;
		}
		public async Task<PagedResult<ProductViewModel>> GetAllByCategoryId(string languageId, GetPublicProducPagingRequest request)
		{
			var query = from p in _context.Products
						join pt in _context.productsTranslation on p.Id equals pt.ProductId
						join pic in _context.productsInCategories on p.Id equals pic.ProductId
						join c in _context.categories on pic.CategoryId equals c.Id
						where pt.LanguageId == languageId
						select new { p, pt, pic };
			if (request.CategoryId.HasValue && request.CategoryId.Value > 0)
			{
				query = query.Where(p => p.pic.CategoryId == request.CategoryId);
			}

			int totalRow = await query.CountAsync();
			var data = await query.Skip((request.PageIndex - 1) * request.PageSize)
				.Take(request.PageSize)
				.Select(x => new ProductViewModel()
				{
					Id = x.p.Id,
					DateCreated = x.p.DateCreated,
					OriginalPrice = x.p.OriginalPrice,
					Price = x.p.Price,
					Stock = x.p.Stock,
					ViewCount = x.p.ViewCount,

					Name = x.pt.Name,
					Description = x.pt.Description,
					Details = x.pt.Details,
					LanguageId = x.pt.LanguageId,
					SeoAlias = x.pt.SeoAlias,
					SeoDescription = x.pt.SeoDescription,
					SeoTitle = x.pt.SeoTitle,
				}).ToListAsync();

			var pagedResult = new PagedResult<ProductViewModel>()
			{
				TotalRecord = totalRow,
				Items = data
			};
			return pagedResult;
		}

	}
}
