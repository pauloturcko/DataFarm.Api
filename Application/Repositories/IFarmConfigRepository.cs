using DataFarm.Api.Domain.Config;

namespace DataFarm.Api.Application.Repositories;

public interface IFarmConfigRepository
{
    Task<FarmConfig?> GetFarmConfigAsync();
}