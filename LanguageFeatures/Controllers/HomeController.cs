﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LanguageFeatures.Model;
using Microsoft.AspNetCore.Mvc;


namespace LanguageFeatures.Controllers
{
    public class HomeController : Controller
    {
        
       
           
   
        public async Task<ViewResult> Index()
        {
            long? length = await MyAsyncMethods.GetPageLength();
        ShoppingCart cart = new ShoppingCart { Products = Product.GetProducts() };

            decimal priceFilterTotal = cart.Filter(p => (p?.Price ?? 0) >= 20).TotalPrices();

            List<string> results = new List<string>();

            foreach(Product p in Product.GetProducts())
            {
                string name = p?.Name ?? "<No Name>";
                decimal? price = p?.Price ?? 0;
                string relatedName = p?.Related?.Name ?? "<None>";
                results.Add($"Name: {name}, Price: {price:C2}, Related: {relatedName}");

            }


            results.Add($"Total Cost of items that are more expensive than 20$: {priceFilterTotal}");
            results.Add( $"Length: {length}" );
            return View(results);
        }
    }
}