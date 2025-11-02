using DataFarm.Api.Domain.Purchase.Aggregates;

namespace DataFarm.Api.Application.Repositories;

public interface IFornecedorRepository
{
    void Add (Fornecedor fornecedor);
    
    void Update (Fornecedor fornecedor);
    
    void Delete (Fornecedor fornecedor);
    
    Task<List<Fornecedor>> GetAllAsync();
    
    Task<Fornecedor?> GetByIdAsync(int id);
    
    Task<Fornecedor?> GetByNameAsync(string nome);
    
    Task<bool> SaveChangesAsync();
}