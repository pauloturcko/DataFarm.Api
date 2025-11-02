using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Domain.Purchase.Aggregates;
using Microsoft.EntityFrameworkCore;

namespace DataFarm.Api.Infra.Data;

public class FornecedorRepository : IFornecedorRepository
{
    private readonly AppDbContext _context;

    public FornecedorRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Fornecedor fornecedor)
    {
        _context.Fornecedores.Add(fornecedor);
    }

    public async Task<Fornecedor?> GetByIdAsync(int id)
    {
        return await _context.Fornecedores.FindAsync(id);
    }

    public void Update(Fornecedor fornecedor)
    {
        _context.Fornecedores.Update(fornecedor);
    }

    public void Delete(Fornecedor fornecedor)
    {
        _context.Fornecedores.Remove(fornecedor);
    }

    public async Task<List<Fornecedor>> GetAllAsync()
    {
        return await _context.Fornecedores.ToListAsync();
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
    
    public async Task<Fornecedor?> GetByNameAsync(string nome)
    {
        return await _context.Fornecedores.FirstOrDefaultAsync(f => f.Nome == nome);
    }
}