﻿using eShopSolution.Application.Catalog.Product;
using eShopSolution.ViewModels.Catalog.Product;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eShopSolution.BackEndAPI.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IPublicProductService _publicProductService;
		private readonly IManageProductService _manageProductService;
		public ProductsController(IPublicProductService publicProductService, IManageProductService manageProductService)
		{
			_publicProductService = publicProductService;
			_manageProductService = manageProductService;
		}
		[HttpGet("{productId}/{languageId}")]
		public async Task<IActionResult> GetById(int productId, string languageId)
		{
			var product = await _manageProductService.GetById(productId, languageId);
			if(product == null)
				return NotFound("Cannot fint product");
			return Ok(product);
		}
		[HttpGet("Public-Paging/{languageId}")]
		public async Task<IActionResult> GetAllPaging(string languageId,[FromQuery]GetPublicProducPagingRequest request)
		{
			var products = await _publicProductService.GetAllByCategoryId(languageId, request);
			return Ok(products);
		}

		[HttpPost]
		public async Task<IActionResult> Create([FromForm]ProductCreateRequest request)
		{
			if(!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var productId = await _manageProductService.Create(request);
			if (productId == 0)
				return BadRequest();

			var product = await _manageProductService.GetById(productId, request.LanguageId);
			return CreatedAtAction(nameof(GetById),new { id = productId}, productId);
		}
		[HttpPut]
		public async Task<IActionResult> Update([FromForm] ProductUpdateRequest request)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}
			var affectedResult = await _manageProductService.Update(request);
			if (affectedResult == 0)
				return BadRequest();
			return Ok();
		}
		[HttpDelete("{productId}")]
		public async Task<IActionResult> Delete(int productId)
		{
			var affectedResult = await _manageProductService.Delete(productId);
			if (affectedResult == 0)
				return BadRequest();
			return Ok();
		}
		[HttpPatch("Price/{productId}/{newPrice}")]
		public async Task<IActionResult> UpdatePrice(int productId, decimal newPrice )
		{
			var isSuccessful = await _manageProductService.UpdatePrice(productId, newPrice);
			if (isSuccessful)
				return Ok();
			return Ok();
		}
	}
}