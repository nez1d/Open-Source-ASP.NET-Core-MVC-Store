﻿using Microsoft.AspNetCore.Mvc;
using ShopDevelop.Data.DataBase;
using ShopDevelop.Data.Models;
using ShopDevelop.Data.Repository.Entity;
using ShopDevelop.Web.Models;

namespace ShopDevelop.Web.Controllers
{
    public class CartController : Controller
    {
        private readonly ShoppingCart _shoppingCart;
        private readonly ApplicationDbContext _applicationDbContext;

        public CartController(ApplicationDbContext applicationDbContext,
                              ShoppingCart shoppingCart)
        {
            _shoppingCart = shoppingCart;
            _applicationDbContext = applicationDbContext;
        }

        public IActionResult Index(int id)
        {
            var products = _shoppingCart.GetAllItems();
            _shoppingCart.ShoppingCartItems = products;

            var shoppingCart = new ShoppingCartViewModel
            {
                ShoppingCart = _shoppingCart,
            };
            return View("Index", shoppingCart); 
        }

        [HttpGet]
        public IActionResult Add(int id, int amount)
        {
            var product = _applicationDbContext.Products
                .FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                _shoppingCart.AddToCart(product/*, amount*/);
            }

            return Redirect("Index");
        }
    }
}