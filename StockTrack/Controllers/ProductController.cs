using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrack.Services.DTOs;
using StockTrack.Services.services.Interfaces;
using StockTrack.ViewModels;

namespace StockTrack.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public ProductController(IProductService productService, IMapper mapper)
        {
            this.productService = productService;
            this.mapper = mapper;
        }

        // Display the list of all products
        public async Task<IActionResult> Index()
        {
            var data = await productService.GetAll();
            var products = mapper.Map<List<ProductVM>>(data);
            return View(products);
        }

        // Show the form to add a new product
        public async Task<IActionResult> AddProduct()
        {
            return View();
        }

        // Handle the submission of a new product
        [HttpPost]
        public async Task<IActionResult> AddProduct(ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var newProduct = mapper.Map<ProductDto>(product);
            await productService.Add(newProduct);
            return RedirectToAction("Index");
        }

        // Show the form to edit an existing product
        public async Task<IActionResult> Edit(int id)
        {
            var product = await productService.GetById(id);
            var mappedProduct = mapper.Map<ProductVM>(product);
            return View(mappedProduct);
        }

        // Handle the submission of an updated product
        [HttpPost]
        public async Task<IActionResult> Edit(ProductVM product)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            var mappedProduct = mapper.Map<ProductDto>(product);
            await productService.Update(mappedProduct);
            return RedirectToAction("Index");
        }

        // Show the confirmation page to delete a product
        public async Task<IActionResult> Delete(int id)
        {
            var productWantToDelete = await productService.GetById(id);
            var mappedProduct = mapper.Map<ProductVM>(productWantToDelete);
            return View(mappedProduct);
        }

        // Handle the deletion of a product
        [HttpPost]
        public async Task<IActionResult> Delete(ProductVM product)
        {
            try
            {
                var mappedProduct = mapper.Map<ProductDto>(product);
                await productService.Delete(mappedProduct.Id);
                return RedirectToAction("Index");
            }
            catch (InvalidOperationException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while deleting the product: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Display details of a specific product
        public async Task<IActionResult> ViewProduct(int id)
        {
            var product = await productService.GetById(id);
            var mappedProduct = mapper.Map<ProductVM>(product);
            return View(mappedProduct);
        }
    }
}