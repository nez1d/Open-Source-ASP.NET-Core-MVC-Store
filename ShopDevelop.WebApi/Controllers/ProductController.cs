﻿using Asp.Versioning;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Application.Entities.Product.Commands.Create.Clothes;
using ShopDevelop.Application.Entities.Product.Commands.Create.Shoes;
using ShopDevelop.Application.Entities.Product.Commands.Delete;
using ShopDevelop.Application.Entities.Product.Commands.Update;
using ShopDevelop.Application.Entities.Product.Queries.GetByArticle;
using ShopDevelop.Application.Entities.Product.Queries.GetByName;
using ShopDevelop.Application.Entities.Product.Queries.GetByNovelty;
using ShopDevelop.Application.Entities.Product.Queries.GetBySellerId;
using ShopDevelop.Application.Entities.Product.Queries.GetMinimizedProducts;
using ShopDevelop.Application.Entities.Product.Queries.GetProductDetails;
using ShopDevelop.Application.Entities.Product.Queries.GetSortedByPrice;
using ShopDevelop.Application.Entities.Product.Queries.GetSortedByRating;
using ShopDevelop.Domain.Dto.Product;

namespace ShopDevelop.WebApi.Controllers;

[ApiController]
[ApiVersion(1, Deprecated = false)]
[Route("api/v{version:apiVersion}/[controller]/[action]")]
public class ProductController(IMapper mapper) : BaseController
{
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product-clothes")]
    public async Task<IActionResult> CreateClothes([FromBody] CreateClothesProductDto model)
    {
        var command = mapper.Map<CreateClothesProductCommand>(model);
        var result = await Mediator.Send(command);

        if (result == Guid.Empty)
            return BadRequest();

        return Created();
    }
    
    [HttpPost]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product-shoes")]
    public async Task<IActionResult> CreateShoes([FromBody] CreateShoesProductDto model)
    {
        var command = mapper.Map<CreateShoesProductCommand>(model);
        var result = await Mediator.Send(command);

        if (result == Guid.Empty)
            return BadRequest();
        
        return Ok();
    }
    
    [HttpPut]
    [MapToApiVersion(1)]
    // TODO: доделать
    [Route("/api/v{version:apiVersion}/product")]
    public async Task<IActionResult> Edit([FromBody] UpdateProductDto model)
    {
        var command = mapper.Map<UpdateProductCommand>(model);
        await Mediator.Send(command);
        return NoContent();
    }
    
    [HttpDelete]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/category/{productId:guid}")]
    public async Task<IActionResult> Delete(Guid productId)
    {
        await Mediator.Send(
            new DeleteProductCommand()
            {
                ProductId = productId
            });
        
        return NoContent();
    }

    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/minimized-products")]
    public async Task<ActionResult> GetAll()
    {
        var result = 
            await Mediator.Send(
                new GetMiniProductListQuery());
        
        if(!result.Any())
            return NotFound();
        
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product/{id:guid}")]
    public async Task<ActionResult> GetById(Guid id)
    {
        var result = 
            await Mediator.Send(
                new GetProductByIdQuery
                {
                    Id = id
                });
        
        if(result is null)
            return NotFound();
        
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product/{article:int}")]
    public async Task<ActionResult> GetByArticle(int article)
    {
        var query = 
            await Mediator.Send(
                new GetProductByArticleQuery()
                {
                    Article = article
                });
        
        if(query is null)
            return NotFound();
        
        return Ok(query);
    }

    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product/{maxPrice:decimal}/{minPrice:decimal}/{descending:bool}")]
    public async Task<ActionResult> GetSortedByPrice(decimal? maxPrice = null, decimal? minPrice = null, bool descending = false)
    {
        var result = 
            await Mediator.Send(
                new GetSortedProductsByPriceQuery()
                {
                    MaxPrice = maxPrice,
                    MinPrice = minPrice,
                    Descending = descending
                });

        if (!result.Any())
            return BadRequest();
        
        return Ok(result);
    }
    
    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/product/{descending:bool}")]
    public async Task<ActionResult> GetSortedByRating(bool descending = false)
    {
        var result = 
            await Mediator.Send(
                new GetSortedProductsByRatingQuery()
                {
                    Descending = descending
                });

        if (!result.Any())
            return BadRequest();
        
        return Ok(result);
    }

    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/products/{name}")]
    // TODO: доделать
    public async Task<ActionResult> GetByName(string name)
    {
        var result = 
            await Mediator.Send(
                new GetProductByNameQuery()
                {
                    Name = name
                });
        
        if (!result.Any())
            return NotFound();
        
        return Ok();
    }
    
    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/products/{descending:bool}")]
    public async Task<ActionResult> GetByNoveltyByRating(bool descending = true)
    {
        var result = 
            await Mediator.Send(
                new GetProductByNoveltyQuery()
                {
                    Descending = descending
                });
        
        if(!result.Any())
            return NotFound();
        
        return Ok();
    }
    
    [HttpGet]
    [AllowAnonymous]
    [MapToApiVersion(1)]
    [Route("/api/v{version:apiVersion}/seller-products/{sellerId:int}")]
    public async Task<ActionResult> GetBySellerId(int sellerId)
    {
        var result = 
            await Mediator.Send(
                new GetProductBySellerIdQuery()
                {
                    SellerId = sellerId
                });
        
        if(!result.Any())
            return NotFound();
        
        return Ok(result);
    }
}