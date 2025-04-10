using StockTrack.Services.DTOs;

namespace StockTrack.Services.services.Interfaces
{
    public interface ISaleService
    {
        Task<List<SaleDto>> GetAll();
        Task<SaleDto> Add(SaleDto saleDto);
        Task<SaleDto> GetById(int id);
        Task<SaleDto> Update(SaleDto saleDto);
        Task Delete(int id);
    }
}
