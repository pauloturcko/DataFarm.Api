using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Domain.Purchase;
using Microsoft.EntityFrameworkCore;

namespace DataFarm.Api.Infra.Data;

public class CompraRepository : IPurchaseRepository
{
    private readonly AppDbContext _context;

    public CompraRepository(AppDbContext context)
    {
        _context = context;
    }

    public void Add(Compra compra)
    {
        _context.Compras.Add(compra);
    }

    public async Task<Compra?> GetByIdAsync(int id)
    {
        return await _context.Compras.FindAsync(id);
    }

    public void Update(Compra compra)
    {
        _context.Compras.Update(compra);
    }

    public async Task<List<Compra>> GetAllAsync()
    {
        return await _context.Compras.ToListAsync();
    }

    public void Delete(Compra compra)
    {
        _context.Compras.Remove(compra);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }
}