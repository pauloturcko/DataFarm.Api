using DataFarm.Api.Domain.Stock;
using DataFarm.Api.DTOs;

namespace DataFarm.Api.Application.Services;

public interface IEstoqueService
{
    Task<Estoque?> AddItemAsync(AddItemRequest request);
    
    Task<Estoque?> GetItemByIdAsync(int id);
    
    Task<List<Estoque>> GetItemListAsync();
    
    Task<Estoque?> ConsumeItemAsync(int id, double quantidade);
    
    Task<Estoque> UpdateItemAsync(int id, UpdateItemRequest request);

    Task<bool> DeleteItemAsync(int id);
}