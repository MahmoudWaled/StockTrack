using AutoMapper;
using StockTrack.Data.Entities;
using StockTrack.Data.Repositories.Interfaces;
using StockTrack.Services.DTOs;
using StockTrack.Services.services.Interfaces;

namespace StockTrack.Services.services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository productRepository;
        private readonly IMapper mapper;

        public ProductService(IProductRepository _productRepository, IMapper _mapper)
        {
            productRepository = _productRepository;
            mapper = _mapper;
        }

        // Add a new product
        public async Task<ProductDto> Add(ProductDto productDto)
        {
            var entityProduct = mapper.Map<Product>(productDto);
            await productRepository.Add(entityProduct);
            return productDto;
        }

        // Delete a product by its ID
        public async Task Delete(int id)
        {
            await productRepository.Delete(id);
        }

        // Retrieve all products
        public async Task<List<ProductDto>> GetAll()
        {
            var entitiesProducts = await productRepository.GetAll();
            return mapper.Map<List<ProductDto>>(entitiesProducts);
        }

        // Retrieve a product by its ID
        public async Task<ProductDto> GetById(int id)
        {
            var entityProduct = await productRepository.GetById(id);
            return mapper.Map<ProductDto>(entityProduct);
        }

        // Search for products by name
        public async Task<List<ProductDto>> SearchByName(string name)
        {
            var entitiesProducts = await productRepository.SearchByName(name);
            return mapper.Map<List<ProductDto>>(entitiesProducts);
        }

        // Update an existing product
        public async Task<ProductDto> Update(ProductDto productDto)
        {
            var entityProduct = mapper.Map<Product>(productDto);
            await productRepository.Update(entityProduct);
            return productDto;
        }

        // Update product quantity after a sale
        public async Task UpdateProductQuantityAsync(int productId, int quantitySold)
        {
            await productRepository.UpdateProductQuantityAsync(productId, quantitySold);
        }
    }
}