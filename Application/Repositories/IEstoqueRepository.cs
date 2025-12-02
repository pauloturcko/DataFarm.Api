using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.Domain.Stock;

namespace DataFarm.Api.Application.Repositories;

public interface IEstoqueRepository
{
    void Add (Estoque estoque);
    
    void Update (Estoque estoque);
    
    void Delete (Estoque estoque);
    
    Task<List<Estoque>> GetAllAsync();
    
    Task<Estoque?> GetByIdAsync(int id);
    
    Task<Estoque?> GetByNameAsync(string nome);
    
    Task<bool> SaveChangesAsync();
}