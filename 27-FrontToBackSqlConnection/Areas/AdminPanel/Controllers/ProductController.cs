using _27_FrontToBackSqlConnection.Areas.AdminPanel.ViewModels;
using _27_FrontToBackSqlConnection.Data;
using _27_FrontToBackSqlConnection.Models;
using _27_FrontToBackSqlConnection.Utilities.Enums;
using _27_FrontToBackSqlConnection.Utilities.Extensions;
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
                    Image = p.ProductImages.FirstOrDefault(p => p.IsPrimary == true).Image
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

            if (productCreateVM.MainPhoto is null)
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "Main Photo is required");
            }

            if (!productCreateVM.MainPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File type is incorrect!");
                return View(productCreateVM);
            }
            if (!productCreateVM.MainPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(productCreateVM.MainPhoto), "File size must be less than 2 mb!");
                return View(productCreateVM);
            }

            if (productCreateVM.HoverPhoto is null)
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "Hover Photo is required");
            }

            if (!productCreateVM.HoverPhoto.CheckFileType("image/"))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File type is incorrect!");
                return View(productCreateVM);
            }
            if (!productCreateVM.HoverPhoto.CheckFileSize(FileSize.MB, 1))
            {
                ModelState.AddModelError(nameof(productCreateVM.HoverPhoto), "File size must be less than 2 mb!");
                return View(productCreateVM);
            }

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

            ProductImage mainImage = new()
            {
                Image = await productCreateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = true
            };

            ProductImage hoverImage = new()
            {
                Image = await productCreateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                IsPrimary = false
            };

            Product product = new()
            {
                Name = productCreateVM.Name,
                Price = productCreateVM.Price,
                Description = productCreateVM.Description,
                SKU = productCreateVM.SKU,
                CategoryId = productCreateVM.CategoryId.Value,
                ProductImages = new List<ProductImage> { mainImage, hoverImage}
            };

            if (productCreateVM.TagIds is not null)
            {
                product.ProductTags = productCreateVM.TagIds.Select(tId => new ProductTag { TagId = tId }).ToList();
            }

            string info = string.Empty;

            if (productCreateVM.AdditionalPhoto is not null)
            {
                foreach (var file in productCreateVM.AdditionalPhoto)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} type was not correct</p>";
                        continue;
                    }
                    if (!file.CheckFileSize(FileSize.KB, 100))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} size was not correct</p>";
                        continue;
                    }

                    product.ProductImages.Add(new ProductImage
                    {
                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null
                    }); ;
                }
            }

            TempData["FileInfo"] = info;

            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (id is null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p => p.ProductTags)
                .Include(p => p.ProductImages)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (product == null) return NotFound();

            if (product.ProductImages is not null && product.ProductImages.Count > 0)
            {
                foreach (var productImage in product.ProductImages)
                {
                    if (!string.IsNullOrEmpty(productImage.Image))
                    {
                        productImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");
                    }
                }

                _context.ProductImages.RemoveRange(product.ProductImages);
            }

            if (product.ProductTags is not null && product.ProductTags.Count > 0)
            {
                _context.ProductTags.RemoveRange(product.ProductTags);
            }

            _context.Products.Remove(product);

            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Detail(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product? product = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .ThenInclude(pt => pt.Tag)
                .FirstOrDefaultAsync(p => p.Id == id);

            return View(product);
        }

        public async Task<IActionResult> Update(int? id)
        {
            if (id == null || id < 1) return BadRequest();

            Product? existProduct = await _context.Products
                .Include(p => p.ProductImages)
                .Include(p => p.ProductTags)
                .FirstOrDefaultAsync(p => p.Id == id);

            if (existProduct == null) return NotFound();

            ProductUpdateVM productUpdateVM = new()
            {
                Name = existProduct.Name,
                Price = existProduct.Price,
                Description = existProduct.Description,
                SKU = existProduct.SKU,
                CategoryId = existProduct.CategoryId,
                TagIds = existProduct.ProductTags.Select(pt => pt.TagId).ToList(),
                Categories = await _context.Categories.ToListAsync(),
                Tags = await _context.Tags.ToListAsync(),
                ProductImages = existProduct.ProductImages,
            };

            return View(productUpdateVM);
        }

        [HttpPost]
        public async Task<IActionResult> Update(int? id, ProductUpdateVM productUpdateVM)
        {
            if (id == null || id < 1) return BadRequest();

            Product? existProduct = await _context.Products
               .Include(p => p.ProductTags)
               .Include(p => p.ProductImages)
               .FirstOrDefaultAsync(p => p.Id == id);

            if (existProduct == null) return NotFound();

            productUpdateVM.Categories = await _context.Categories.Where(c => !c.isDeleted).ToListAsync();
            productUpdateVM.Tags = await _context.Tags.Where(t => !t.isDeleted).ToListAsync();
            productUpdateVM.ProductImages = existProduct.ProductImages;

            if (!ModelState.IsValid)
            {
                productUpdateVM.ProductImages = await _context.ProductImages.Where(pi => pi.ProductId == id).ToListAsync();
                return View(productUpdateVM);
            }

            if (productUpdateVM.MainPhoto is not null)
            {
                if (!productUpdateVM.MainPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File type is incorrect!");
                    return View(productUpdateVM);
                }
                if (!productUpdateVM.MainPhoto.CheckFileSize(FileSize.MB, 1))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.MainPhoto), "File size must be less than 2 mb!");
                    return View(productUpdateVM);
                }
            }

            if (productUpdateVM.HoverPhoto is not null)
            {
                if (!productUpdateVM.HoverPhoto.CheckFileType("image/"))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File type is incorrect!");
                    return View(productUpdateVM);
                }
                if (!productUpdateVM.HoverPhoto.CheckFileSize(FileSize.MB, 1))
                {
                    ModelState.AddModelError(nameof(productUpdateVM.HoverPhoto), "File size must be less than 2 mb!");
                    return View(productUpdateVM);
                }
            }

            bool existCategory = productUpdateVM.Categories.Any(c => c.Id == productUpdateVM.CategoryId);
            if (!existCategory)
            {
                ModelState.AddModelError(nameof(productUpdateVM.CategoryId), "Category does not exist!");
                productUpdateVM.ProductImages = existProduct.ProductImages;
                return View(productUpdateVM);
            }

            if (productUpdateVM.TagIds is not null)
            {
                bool existTag = productUpdateVM.TagIds.Any(tagId => !productUpdateVM.Tags.Exists(t => t.Id == tagId));
                if (existTag)
                {
                    ModelState.AddModelError(nameof(ProductCreateVM.TagIds), "Tag does not exist!");
                    productUpdateVM.ProductImages = existProduct.ProductImages;
                    return View(productUpdateVM);
                }
            }

            if (productUpdateVM.TagIds is null)
            {
                productUpdateVM.TagIds = new();
            }

            if (productUpdateVM.TagIds is not null)
            {
                _context.ProductTags.RemoveRange(existProduct.ProductTags
                   .Where(pTag => !productUpdateVM.TagIds
                   .Exists(tId => tId == pTag.TagId)).ToList());

                _context.ProductTags.AddRange(productUpdateVM.TagIds
                   .Where(tId => !existProduct.ProductTags.Exists(pTag => pTag.TagId == tId))
                   .ToList()
                   .Select(tId => new ProductTag { TagId = tId, ProductId = existProduct.Id }));
            }

            if (productUpdateVM.MainPhoto is not null)
            {
                string fileName = await productUpdateVM.MainPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage mainImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == true);

                if (mainImage is not null)
                {
                    mainImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                    _context.Remove(mainImage);

                    existProduct.ProductImages.Remove(mainImage);
                }

                existProduct.ProductImages.Add(new ProductImage
                {
                    Image = fileName,
                    IsPrimary = true,
                });

            }

            if (productUpdateVM.HoverPhoto is not null)
            {
                string fileName = await productUpdateVM.HoverPhoto.CreateFile(_env.WebRootPath, "assets", "images", "website-images");

                ProductImage hoverImage = existProduct.ProductImages.FirstOrDefault(p => p.IsPrimary == false);

                if (hoverImage is not null)
                {
                    hoverImage.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images");

                    _context.Remove(hoverImage);

                    existProduct.ProductImages.Remove(hoverImage);
                }

                existProduct.ProductImages.Add(new ProductImage
                {
                    Image = fileName,
                    IsPrimary = false,
                });
            }

            if (productUpdateVM.ImageIds is null)
            {
                productUpdateVM.ImageIds = new List<int>();
            }

            var deleteImages = existProduct.ProductImages
                .Where(pi => !productUpdateVM.ImageIds
                .Exists(imgId => imgId == pi.Id) && pi.IsPrimary == null)
                .ToList();

            deleteImages.ForEach(di => di.Image.DeleteFile(_env.WebRootPath, "assets", "images", "website-images"));

            _context.ProductImages.RemoveRange(deleteImages);

            if (productUpdateVM.AdditionalPhoto is not null)
            {
                string info = string.Empty;

                foreach (var file in productUpdateVM.AdditionalPhoto)
                {
                    if (!file.CheckFileType("image/"))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} type was not correct</p>";
                        continue;
                    }
                    if (!file.CheckFileSize(FileSize.KB, 100))
                    {
                        info += $"<p class=\"text-danger\">{file.FileName} size was not correct</p>";
                        continue;
                    }

                    existProduct.ProductImages.Add(new ProductImage
                    {
                        Image = await file.CreateFile(_env.WebRootPath, "assets", "images", "website-images"),
                        IsPrimary = null
                    }); ;
                }
                TempData["FileInfo"] = info;
            }

            existProduct.Name = productUpdateVM.Name;
            existProduct.Price = productUpdateVM.Price;
            existProduct.Description = productUpdateVM.Description;
            existProduct.SKU = productUpdateVM.SKU;
            existProduct.CategoryId = productUpdateVM.CategoryId.Value;
         

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }


    }
}
