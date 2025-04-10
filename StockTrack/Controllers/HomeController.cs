using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using StockTrack.Services.services.Interfaces;
using StockTrack.ViewModels;

namespace StockTrack.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductService productService;
        private readonly IMapper mapper;

        public HomeController(ILogger<HomeController> logger, IProductService productService, IMapper mapper)
        {
            _logger = logger;
            this.productService = productService;
            this.mapper = mapper;
        }

        // Display the list of all products on the home page
        public async Task<IActionResult> Index()
        {
            var data = await productService.GetAll();
            var products = mapper.Map<List<ProductVM>>(data);
            return View(products);
        }
    }
}