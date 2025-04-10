using StockTrack.Data.Entities;

namespace StockTrack.Data.Repositories.Interfaces
{
    public interface ISaleRepository
    {
        Task<List<Sale>> GetAll();
        Task<Sale> GetById(int id);
        Task<Sale> Add(Sale sale);
        Task<Sale> Update(Sale sale);
        Task Delete(int id);




    }
}
