namespace DataFarm.Api.Domain.Config;

public class FarmConfig
{
    public int Id { get; init; }
    public int MaxAnimalCapacity { get; init; }
    public int MaxStockCapacity { get; init; }
    public int MinLotSizeBuy { get; init; }
}