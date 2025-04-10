using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using StockTrack.Services.DTOs;
using StockTrack.Services.services.Interfaces;
using StockTrack.ViewModels;

namespace StockTrack.Controllers
{
    public class SaleController : Controller
    {
        private readonly ISaleService saleService;
        private readonly IMapper mapper;
        private readonly IProductService productService;
        private readonly IUserService userService;

        public SaleController(ISaleService saleService, IMapper mapper, IProductService productService, IUserService userService)
        {
            this.saleService = saleService;
            this.mapper = mapper;
            this.productService = productService;
            this.userService = userService;
        }

        // Display the list of all sales
        public async Task<IActionResult> Index()
        {
            var sales = await saleService.GetAll();
            var mappedSales = mapper.Map<List<SaleVM>>(sales);
            return View(mappedSales);
        }

        // Show the form to add a new sale
        public async Task<IActionResult> Add()
        {
            var saleVM = new SaleVM();

            var products = await productService.GetAll();
            saleVM.Products = products
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name
                })
                .ToList();

            var sellers = await userService.GetSellersAsync();
            saleVM.Sellers = sellers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.UserName
                })
                .ToList();

            saleVM.SaleDate = DateTime.Now;
            return View(saleVM);
        }

        // Handle the submission of a new sale
        [HttpPost]
        public async Task<IActionResult> Add(SaleVM saleVM)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(saleVM);
                return View(saleVM);
            }

            try
            {
                var saleDto = mapper.Map<SaleDto>(saleVM);
                await saleService.Add(saleDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                await PopulateDropdowns(saleVM);
                return View(saleVM);
            }
        }

        // Display details of a specific sale
        public async Task<IActionResult> ViewSale(int id)
        {
            var sale = await saleService.GetById(id);
            var mappedSale = mapper.Map<SaleVM>(sale);
            return View(mappedSale);
        }

        // Show the form to edit an existing sale
        public async Task<IActionResult> Edit(int id)
        {
            try
            {
                var sale = await saleService.GetById(id);
                var mappedSale = mapper.Map<SaleVM>(sale);

                await PopulateDropdowns(mappedSale, mappedSale.ProductId, mappedSale.UserId);
                return View(mappedSale);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while retrieving the sale: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Handle the submission of an updated sale
        [HttpPost]
        public async Task<IActionResult> Edit(SaleVM saleVM)
        {
            if (!ModelState.IsValid)
            {
                await PopulateDropdowns(saleVM, saleVM.ProductId, saleVM.UserId);
                return View(saleVM);
            }

            try
            {
                var saleDto = mapper.Map<SaleDto>(saleVM);
                await saleService.Update(saleDto);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                await PopulateDropdowns(saleVM, saleVM.ProductId, saleVM.UserId);
                return View(saleVM);
            }
        }

        // Show the confirmation page to delete a sale
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var sale = await saleService.GetById(id);
                var mappedSale = mapper.Map<SaleVM>(sale);
                return View(mappedSale);
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while retrieving the sale: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Handle the deletion of a sale
        [HttpPost]
        public async Task<IActionResult> Delete(SaleVM saleVM)
        {
            try
            {
                var mappedSale = mapper.Map<SaleDto>(saleVM);
                await saleService.Delete(mappedSale.Id);
                return RedirectToAction("Index");
            }
            catch (KeyNotFoundException ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                TempData["Error"] = "An error occurred while deleting the sale: " + ex.Message;
                return RedirectToAction("Index");
            }
        }

        // Helper method to populate Products and Sellers dropdowns
        private async Task PopulateDropdowns(SaleVM saleVM, int? selectedProductId = null, int? selectedUserId = null)
        {
            var products = await productService.GetAll();
            saleVM.Products = products
                .Select(p => new SelectListItem
                {
                    Value = p.Id.ToString(),
                    Text = p.Name,
                    Selected = p.Id == selectedProductId
                })
                .ToList();

            var sellers = await userService.GetSellersAsync();
            saleVM.Sellers = sellers
                .Select(s => new SelectListItem
                {
                    Value = s.Id.ToString(),
                    Text = s.UserName,
                    Selected = s.Id == selectedUserId
                })
                .ToList();
        }
    }
}