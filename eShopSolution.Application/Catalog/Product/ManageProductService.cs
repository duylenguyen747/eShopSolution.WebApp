using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eShopSolution.Data.Data;
using eShopSolution.Data.Entities;
using eShopSolution.Utilities.Exceptions;
using eShopSolution.ViewModels.Catalog.Product;
using eShopSolution.ViewModels.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;
using eShopSolution.Application.Common;
using Microsoft.AspNetCore.Server.IISIntegration;
using Microsoft.Data.SqlClient;
using eShopSolution.ViewModels.Catalog.ProductImage;

namespace eShopSolution.Application.Catalog.Product
{
	public class ManageProductService : IManageProductService
	{
		private readonly eShopSolutionDataContext _context;
		private readonly IStorageService _storageService;

		public ManageProductService(eShopSolutionDataContext context, IStorageService storageService)
		{
			_context = context;
			_storageService = storageService;
		}

		public async Task<int> AddImage(int productId, ProductImageCreateRequest request)
		{
			var productImage = new ProductImage()
			{
				Caption = request.Caption,
				DateCreated = DateTime.Now,
				IsDefault = request.IsDefault,
				ProductId = productId,
				SortOrder = request.SortOrder,
			};
			if (request.ImageFile != null)
			{
				productImage.ImagePath = await this.SaveFile(request.ImageFile);
				productImage.FileSize = request.ImageFile.Length;
			}
			_context.productImages.Add(productImage);
			await _context.SaveChangesAsync();
			return productImage.Id;
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
			// Save Image
			if (request.ThumbnailImage != null)
			{
				product.ProductImage = new List<ProductImage>()
				{
					new ProductImage()
					{
						Caption = "Thumbnail image",
						DateCreated = DateTime.Now,
						FileSize = request.ThumbnailImage.Length,
						ImagePath = await this.SaveFile(request.ThumbnailImage),
						IsDefault = true,
						SortOrder = 1
					}
				};
			}

			_context.Products.Add(product);
			await _context.SaveChangesAsync();
			return product.Id;
		}

		public async Task<int> Delete(int ProductId)
		{
			var product = await _context.Products.FindAsync(ProductId);
			if (product == null) throw new eShopException($"Cannot find a product: {ProductId}");

			var images = _context.productImages.Where(i => i.ProductId == ProductId);
			foreach (var image in images)
			{
				await _storageService.DeleteFileAsync(image.ImagePath);
			}
			_context.Products.Remove(product);
			return await _context.SaveChangesAsync();
		}

		public async Task<int> DeleteImage(int imageId)
		{
			var productImage = await _context.productImages.FindAsync(imageId);
			if (productImage == null)
				throw new eShopException($"Cannot find an image with id {imageId}");
			_context.productImages.Remove(productImage);
			return await _context.SaveChangesAsync();
		}

		public async Task<PagedResult<ProductViewModel>> GetAllPaging(GetManageProductPagingRequest request)
		{
			var query = from p in _context.Products
						join pt in _context.productsTranslation on p.Id equals pt.ProductId
						join pic in _context.productsInCategories on p.Id equals pic.ProductId
						join c in _context.categories on pic.CategoryId equals c.Id
						select new { p, pt, pic };
			if (!string.IsNullOrEmpty(request.Keyword))
				query = query.Where(x => x.pt.Name.Contains(request.Keyword));

			if (request.CategoryIds.Count > 0)
			{
				query = query.Where(p => request.CategoryIds.Contains(p.pic.CategoryId));
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

		public async Task<ProductViewModel> GetById(int productId, string languageId)
		{
			var product = await _context.Products.FindAsync(productId);
			var productTranslation = await _context.productsTranslation
				.FirstOrDefaultAsync(x => x.ProductId == productId
				 && x.LanguageId == languageId);
			var productViewModel = new ProductViewModel()
			{
				Id = product.Id,
				DateCreated = product.DateCreated,
				Description = productTranslation != null ? productTranslation.Description : null,
				LanguageId = productTranslation.LanguageId,
				Details = productTranslation != null ? productTranslation.Details : null,
				Name = productTranslation != null ? productTranslation.Name : null,
				OriginalPrice = product.OriginalPrice,
				Price = product.Price,
				SeoAlias = productTranslation != null ? productTranslation.SeoAlias : null,
				SeoDescription = productTranslation != null ? productTranslation.SeoDescription : null,
				SeoTitle = productTranslation != null ? productTranslation.SeoTitle : null,
				Stock = product.Stock,
				ViewCount = product.ViewCount
			};
			return productViewModel;
		}

		public async Task<ProductImageViewModel> GetImageById(int imageId)
		{
			var image = await _context.productImages.FindAsync(imageId);
			if (image == null)
				throw new eShopException($"Cannot find an image with id {imageId}");

			var viewModel = new ProductImageViewModel()
			{
				Caption = image.Caption,
				DateCreated = image.DateCreated,
				FileSize = image.FileSize,
				Id = image.Id,
				ImagePath = image.ImagePath,
				IsDefault = image.IsDefault,
				ProductId = image.ProductId,
				SortOrder = image.SortOrder,
			};
			return viewModel;
		}

		public async Task<List<ProductImageViewModel>> GetListImages(int productId)
		{
			return await _context.productImages
				.Where(x => x.ProductId == productId)
				.Select(i => new ProductImageViewModel()
				{
					Caption = i.Caption,
					DateCreated = i.DateCreated,
					FileSize = i.FileSize,
					Id = i.Id,
					ImagePath = i.ImagePath,
					IsDefault = i.IsDefault,
					ProductId = i.ProductId,
					SortOrder = i.SortOrder,
				}).ToListAsync();
		}

		public async Task<int> Update(ProductUpdateRequest request)
		{
			var product = await _context.Products.FindAsync(request.Id);
			var productTranslation = await _context.productsTranslation.FirstOrDefaultAsync(x => x.ProductId == request.Id
			&& x.LanguageId == request.LanguageId);
			if (product == null || productTranslation == null) throw new eShopException($"Cannot find a product with id: {request.Id}");
			productTranslation.Name = request.Name;
			productTranslation.Description = request.Description;
			productTranslation.SeoDescription = request.SeoDescription;
			productTranslation.SeoTitle = request.SeoTitle;
			productTranslation.SeoAlias = request.SeoAlias;
			productTranslation.Details = request.Details;

			if (request.ThumbnailImage != null)
			{
				var thumbnailImage = await _context.productImages.FirstOrDefaultAsync(i => i.IsDefault == true && i.ProductId == request.Id);
				if (thumbnailImage != null)
				{
					thumbnailImage.FileSize = request.ThumbnailImage.Length;
					thumbnailImage.ImagePath = await this.SaveFile(request.ThumbnailImage);
					_context.productImages.Update(thumbnailImage);
				}
			}
			return await _context.SaveChangesAsync();
		}

		public async Task<int> UpdateImage(int imageId, ProductImageUpdateRequest request)
		{
			var productImage = await _context.productImages.FindAsync(imageId);
			if (productImage == null)
				throw new eShopException($"Cannot find an image with id {imageId}");

			if (request.ImageFile != null)
			{
				productImage.ImagePath = await this.SaveFile(request.ImageFile);
				productImage.FileSize = request.ImageFile.Length;
			}
			_context.productImages.Update(productImage);
			return await _context.SaveChangesAsync();
		}

		public async Task<bool> UpdatePrice(int ProductId, decimal newPrice)
		{
			var product = await _context.Products.FindAsync(ProductId);
			if (product == null) throw new eShopException($"Cannot find a product with id: {ProductId}");
			product.Price = newPrice;
			return await _context.SaveChangesAsync() > 0;
		}

		public async Task<bool> UpdateStock(int ProductId, int addedQuantity)
		{
			var product = await _context.Products.FindAsync(ProductId);
			if (product == null) throw new eShopException($"Cannot find a product with id: {ProductId}");
			product.Stock += addedQuantity;
			return await _context.SaveChangesAsync() > 0;
		}

		private async Task<string> SaveFile(IFormFile file)
		{
			var originalFileName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim('"');
			var fileName = $"{Guid.NewGuid()}{Path.GetExtension(originalFileName)}";
			await _storageService.SaveFileAsync(file.OpenReadStream(), fileName);
			return fileName;
		}
	}
}