using DataFarm.Api.Domain.Purchase;

namespace DataFarm.Api.Application.Repositories;

public interface IPurchaseRepository
{
    void Add (Compra compra);
    
    void Update (Compra compra);
    
    void Delete (Compra compra);
    
    Task<Compra?> GetByIdAsync(int id);
    
    Task<List<Compra>> GetAllAsync();
    
    Task<bool> SaveChangesAsync();
}