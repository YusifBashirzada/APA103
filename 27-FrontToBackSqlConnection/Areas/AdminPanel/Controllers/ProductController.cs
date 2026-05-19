using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace _27_FrontToBackSqlConnection.Areas.AdminPanel.Controllers
{
    [Area("AdminPanel")]
    public class ProductController : Controller
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ProductController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        public async Task<IActionResult> Index()
        {
            List<ProductGetVM> productGetVMs = await _context.Products
                .Where(p => !p.isDeleted)
                .Include(p => p.ProductImages)
                .Include(p => p.Category)
                .Select(p => new ProductGetVM
                {
                    Id = p.Id,
                    Name = p.Name,
                    Price = p.Price,
                    CategoryName = p.Category.Name,
                    SKU = p.SKU,
                    Image = p.ProductImages.FirstOrDefault().Image
                })
                .ToListAsync();

            return View(productGetVMs);
        }

        public async Task<IActionResult> Create()
        {
            ProductCreateVM productCreateVM = new()
            {
                Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync(),
                Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync()
            };

            return View(productCreateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductCreateVM productCreateVM)
        {
            productCreateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
            productCreateVM.Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productCreateVM);

            bool existCategory = productCreateVM.Categories.Any(c => c.Id == productCreateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(ProductCreateVM.CategoryId), "Category does not exist!");
                return View(productCreateVM);
            }

           if (productCreateVM.TagIds is not null)
            {
                bool existTag = productCreateVM.TagIds.Any(tagId => !productCreateVM.Tags.Exists(t => t.Id == tagId));
             if (existTag)
                {
                    ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "Tag does not exist!");
                    return View(productCreateVM);
                }
            }

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Description = productCreateVM.Description,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
            };

            if (productCreateVM.TagIds is not null)
            {
                product.ProductTags = productCreateVM.TagIds.Select(tId => new ProductTag { TagId = tId }).ToList();
            }

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product? existProduct = await _context.Products.Include(p => p.ProductTags).FirstOrDefaultAsync(p => p.Id == id);

            if (existProduct == null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = existProduct.Name,
                Price= existProduct.Price,
                Description = existProduct.Description,
                SKU = existProduct.SKU,
                CategoryId = existProduct.CategoryId,
                TagIds = existProduct.ProductTags.Select(pt=>pt.TagId).ToList(),
                Categories = await _context.Categories.ToListAsync(),
                Tags = await _context.Tags.ToListAsync(),
            };

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            if (id == null || id < 1) return BadRequest();

            productUpdateVM.Categories = await _context.Categories.Where(c=>!c.isDeleted).ToListAsync();

            if (!ModelState.IsValid) return View(productUpdateVM);

            Product? existProduct = await _context.Products.FirstOrDefaultAsync(p => p.Id == id);
            if (existProduct == null) return NotFound();

            bool existCategory = productUpdateVM.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(productUpdateVM.CategoryId), "Category does not exist!");
                return View(productUpdateVM);
            }

            if (productUpdateVM.TagIds is not null)
            {
                bool existTag = productUpdateVM.TagIds.Any(tagId => !productUpdateVM.Tags.Exists(t => t.Id == tagId));
                if (!existTag)
                {
                    ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "Tag does not exist!");
                    return View(productUpdateVM);
                }
            }

            existProduct.Name = productUpdateVM.Name;
            existProduct.Price = productUpdateVM.Price;
            existProduct.Description = productUpdateVM.Description;
            existProduct.SKU = productUpdateVM.SKU;
            existProduct.CategoryId = productUpdateVM.CategoryId.Value;
            if (productUpdateVM.TagIds is not null)
            {
                existProduct.ProductTags = productUpdateVM.TagIds.Select(tId => new ProductTag { TagId = tId}).ToList();
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

    }
}
