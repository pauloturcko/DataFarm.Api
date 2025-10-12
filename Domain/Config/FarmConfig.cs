namespace DataFarm.Api.Domain.Config;

public class FarmConfig
{
    public int Id { get; set; }
    public int MaxAnimalCapacity { get; set; }
    public int MaxStockCapacity { get; set; }
    public int MinLotSizeBuy { get; set; }
}