// Controllers/ProductsController.cs
using Microsoft.AspNetCore.Mvc;
using ProductCatalogueApp.Models;

namespace ProductCatalogueApp.Controllers;

public class ProductsController : Controller
{
    // Mocked database list for demonstration purposes
    private static readonly List<Product> _products = new()
    {
        new Product { Id = 1, Name = "Wireless Mouse", Category = "Electronics", Price = 29.99m, Description = "Ergonomic 2.4GHz wireless mouse." },
        new Product { Id = 2, Name = "Mechanical Keyboard", Category = "Electronics", Price = 89.99m, Description = "RGB backlit mechanical keyboard with blue switches." },
        new Product { Id = 3, Name = "Coffee Mug", Category = "Kitchenware", Price = 12.50m, Description = "Ceramic 15oz mug, dishwasher safe." },
        new Product { Id = 4, Name = "Leather Notebook", Category = "Stationery", Price = 18.00m, Description = "A5 ruled journal with premium paper." }
    };

    // GET: /Products
    public IActionResult Index()
    {
        return View(_products);
    }

    // GET: /Products/Details/1
    public IActionResult Details(int id)
    {
        var product = _products.FirstOrDefault(p => p.Id == id);
        if (product == null)
        {
            return NotFound();
        }
        return View(product);
    }
}
