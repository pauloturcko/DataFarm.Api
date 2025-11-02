using DataFarm.Api.Application.Repositories;
using DataFarm.Api.Domain.Config;
using Microsoft.EntityFrameworkCore;

namespace DataFarm.Api.Infra.Data;

public class FarmConfigRepository : IFarmConfigRepository
{
    private readonly AppDbContext _context;

    public FarmConfigRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<FarmConfig?> GetFarmConfigAsync()
    {
        return await _context.FarmConfigs.FirstOrDefaultAsync();
    }
}