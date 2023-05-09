﻿using eShopSolution.Application.Catalog.Product.DTOs;
using eShopSolution.Application.Catalog.Product.DTOs.Manage;
using eShopSolution.Application.Dtos;
using eShopSolution.Data.Data;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using Microsoft.EntityFrameworkCore;
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

		public async Task AddViewCount(int ProductId)
		{
			var product = await _context.Products.FindAsync(ProductId);
			product.ViewCount += 1;
			await _context.SaveChangesAsync();
		}

		public async Task<int> Create(ProductCreateRequest request)
		{
			var product = new eShopSolution.Data.Entities.Product()
			{
				Price = request.Price,
				OriginalPrice = request.OriginalPrice,
				Stock = request.Stock,
				ViewCount = 0,
				DateCreated = DateTime.Now,
				ProductTranslations = new List<ProductTranslation>()
				{
					new ProductTranslation()
					{
						Name = request.Name,
						Description = request.Description,
						Details = request.Details,
						SeoDescription = request.SeoDescription,
						SeoAlias = request.SeoAlias,
						SeoTitle = request.SeoTitle,
						LanguageId = request.LanguageId,
					}
				}
			};
			_context.Products.Add(product); 
			return await _context.SaveChangesAsync();
		}

		public async Task<int> Delete(int ProductId)
		{
			var product = await _context.Products.FindAsync(ProductId);
			if (product == null) throw new eShopException($"Cannot find a product: {ProductId}");

			_context.Products.Remove(product);
			return await _context.SaveChangesAsync();
		}

		public Task<List<ProductViewModel>> GetAll()
		{
			throw new NotImplementedException();
		}


		public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetProductPagingRequest request)
		{
			var query = from p in _context.Products
						join pt in _context.productsTranslation on p.Id equals pt.ProductId
						join pic in _context.productsInCategories on p.Id equals pic.ProductId
						join c in _context.categories on pic.CategoryId equals c.Id
						where pt.Name.Contains(request.Keyword)
						select new { p, pt, pic };
			if (!string.IsNullOrEmpty(request.Keyword))
				query = query.Where(x => x.pt.Name.Contains(request.Keyword));

			if(request.CategoryIds.Count > 0)
			{
				query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
			}

			int totalRow = await query.CountAsync();
			var data = await query.Skip((request.PageIndex - 1)* request.PageSize)
				.Take(request.PageSize)
				.Select( x => new ProductViewModel()
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

		public Task<int> Update(ProductUpdateRequest request)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdatePrice(int ProductId, decimal newPrice)
		{
			throw new NotImplementedException();
		}

		public Task<bool> UpdateStock(int ProductId, int addedQuantity)
		{
			throw new NotImplementedException();
		}
	}
}
