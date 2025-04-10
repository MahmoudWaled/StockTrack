using StockTrack.Data.Entities;

namespace StockTrack.Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(int id);
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task Delete(int id);
        Task<List<Product>> SearchByName(string name);
        Task UpdateProductQuantityAsync(int productId, int quantitySold);

    }
}
