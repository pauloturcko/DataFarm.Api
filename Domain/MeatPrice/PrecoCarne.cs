using DataFarm.Api.Domain.MeatPrice.Aggregates;

namespace DataFarm.Api.Domain.MeatPrice;

public class PrecoCarne
{
    public int Id { get; set; }
    public List<Preco>? HistoricoPreco { get; set; }
}
