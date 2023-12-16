using LojaVirtual.Data;
using LojaVirtual.Models;
using LojaVirtual.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LojaVirtual.Controllers
{
    public class ProductController : Controller
    {
        private readonly DemoDataContext _context;
        private readonly IProductService _productService;

        public ProductController(IProductService product, DemoDataContext context)
        {
            _context = context;
            _productService = product;
        }

        public async Task<IActionResult> Index()
        {
            List<Product> productModel = await GetProducts();
            return View(productModel);
        }

        public async Task<List<Product>> GetProducts()
        {
            return await _context.Products.ToListAsync();
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (model.ImageFile != null)
                    {
                        await _productService.UploadBlobAsync(model.ImageFile, "products");
                        model.UrlImage = model.ImageFile.FileName;
                    }

                    _context.Add(model);
                    await _context.SaveChangesAsync();

                    return RedirectToAction(nameof(Index));
                }
                catch (Exception ex) 
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(model);
        }

        public IActionResult Delete(int id)
        {
            var product = _context.Products.FirstOrDefault(p => p.Id == id);

            if (product != null)
                return NotFound();
            try
            {
                _productService.DeleteBlob(product.UrlImage, "products");
                _context.Products.Remove(product);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
