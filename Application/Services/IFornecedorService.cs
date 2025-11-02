using DataFarm.Api.Domain.Purchase.Aggregates;
using DataFarm.Api.DTOs;

namespace DataFarm.Api.Application.Services;

public interface IFornecedorService
{
    Task<Fornecedor?> CreateFornecedorAsync(CreateFornecedorRequest request);
    
    Task<Fornecedor?> GetFornecedorByIdAsync(int id);
    
    Task<List<Fornecedor>> GetFornecedorListAsync();
    
    Task<Fornecedor?> UpdateFornecedorAsync(UpdateFornecedorRequest request);
   
    Task<bool> DeleteFornecedorAsync(int id);
}