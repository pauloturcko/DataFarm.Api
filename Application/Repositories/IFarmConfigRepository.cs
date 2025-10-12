using DataFarm.Api.Domain.Config;

namespace DataFarm.Api.Repositories;

public interface IFarmConfigRepository
{
    Task<FarmConfig> GetFarmConfigAsync();
}