using AutoMapper;
using StockTrack.Data.Entities;
using StockTrack.Data.Repositories.Interfaces;
using StockTrack.Services.DTOs;
using StockTrack.Services.services.Interfaces;

namespace StockTrack.Services.services
{
    public class SaleService : ISaleService
    {
        private readonly ISaleRepository saleRepository;
        private readonly IMapper mapper;
        private readonly IProductService productService;
        private readonly IUserService userService;

        public SaleService(ISaleRepository _saleRepository, IMapper _mapper, IProductService productService, IUserService userService)
        {
            saleRepository = _saleRepository;
            mapper = _mapper;
            this.productService = productService;
            this.userService = userService;
        }

        // Add a new sale with validation and quantity update
        public async Task<SaleDto> Add(SaleDto saleDto)
        {
            var product = await productService.GetById(saleDto.ProductId);
            if (product == null)
            {
                throw new Exception("Invalid Product selected.");
            }

            var user = await userService.GetById(saleDto.UserId);
            if (user == null || user.Role != "Seller")
            {
                throw new Exception("Invalid Seller selected.");
            }

            if (saleDto.QuantitySold > product.Quantity)
            {
                throw new Exception($"Only {product.Quantity} items are available in stock.");
            }

            saleDto.TotalPrice = saleDto.QuantitySold * product.Price;
            await productService.UpdateProductQuantityAsync(saleDto.ProductId, saleDto.QuantitySold);

            saleDto.Product = null;
            saleDto.User = null;

            var entitySale = mapper.Map<Sale>(saleDto);
            await saleRepository.Add(entitySale);

            var addedSale = await saleRepository.GetById(entitySale.Id);
            return mapper.Map<SaleDto>(addedSale);
        }

        // Retrieve all sales with related Product and User data
        public async Task<List<SaleDto>> GetAll()
        {
            var entitiesSales = await saleRepository.GetAll();
            var saleDtos = mapper.Map<List<SaleDto>>(entitiesSales);

            foreach (var saleDto in saleDtos)
            {
                if (saleDto.ProductId > 0)
                {
                    saleDto.Product = await productService.GetById(saleDto.ProductId);
                }
                if (saleDto.UserId > 0)
                {
                    saleDto.User = await userService.GetById(saleDto.UserId);
                }
            }

            return saleDtos;
        }

        // Retrieve a sale by its ID
        public async Task<SaleDto> GetById(int id)
        {
            var entitySale = await saleRepository.GetById(id);
            return mapper.Map<SaleDto>(entitySale);
        }

        // Update an existing sale with quantity rollback and validation
        public async Task<SaleDto> Update(SaleDto saleDto)
        {
            var oldSale = await saleRepository.GetById(saleDto.Id);
            if (oldSale == null)
            {
                throw new KeyNotFoundException($"Sale with ID {saleDto.Id} not found.");
            }

            var product = await productService.GetById(saleDto.ProductId);
            if (product == null)
            {
                throw new Exception("Invalid Product selected.");
            }

            var user = await userService.GetById(saleDto.UserId);
            if (user == null || user.Role != "Seller")
            {
                throw new Exception("Invalid Seller selected.");
            }

            await productService.UpdateProductQuantityAsync(oldSale.ProductId, -oldSale.QuantitySold);

            if (saleDto.QuantitySold > product.Quantity)
            {
                await productService.UpdateProductQuantityAsync(oldSale.ProductId, oldSale.QuantitySold);
                throw new Exception($"Only {product.Quantity} items are available in stock.");
            }

            saleDto.TotalPrice = saleDto.QuantitySold * product.Price;
            await productService.UpdateProductQuantityAsync(saleDto.ProductId, saleDto.QuantitySold);

            saleDto.Product = null;
            saleDto.User = null;

            var mappedSale = mapper.Map<Sale>(saleDto);
            var updatedSale = await saleRepository.Update(mappedSale);

            var resultSale = await saleRepository.GetById(updatedSale.Id);
            return mapper.Map<SaleDto>(resultSale);
        }

        // Delete a sale by its ID
        public async Task Delete(int id)
        {
            await saleRepository.Delete(id);
        }
    }
}