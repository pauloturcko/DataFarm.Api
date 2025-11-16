using DataFarm.Api.Domain.Purchase;
using DataFarm.Api.DTOs;

namespace DataFarm.Api.Application.Services;

public interface IPurchaseService
{
    Task<Compra?> CreateCompraAsync(CreatePurchaseRequest request);
    
    Task<Compra?> GetCompraByIdAsync(int id);
    
    Task<List<Compra>> GetCompraListAsync();
    
    Task<List<Compra>> UpdateCompraAsync(int id, UpdatePurchaseRequest request);
    
    Task<bool> DeletePurchaseAsync(int id);
}