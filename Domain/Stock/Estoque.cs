using DataFarm.Api.Domain.Shared;

namespace DataFarm.Api.Domain.Stock;

public class Estoque
{
    public int Id { get; set; }
    public int CapacidadeMaxima { get; set; }
    public List<Insumo>? Itens { get; set; }

}
