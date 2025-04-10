using StockTrack.Services.DTOs;

namespace StockTrack.Services.services.Interfaces
{
    public interface IProductService
    {
        Task<List<ProductDto>> GetAll();
        Task<ProductDto> GetById(int id);
        Task<ProductDto> Add(ProductDto productDto);
        Task<ProductDto> Update(ProductDto productDto);
        Task Delete(int id);
        Task<List<ProductDto>> SearchByName(string name);
        Task UpdateProductQuantityAsync(int productId, int quantitySold);


    }
}
