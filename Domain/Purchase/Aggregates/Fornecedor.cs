using DataFarm.Api.Domain.Purchase.Enum;

namespace DataFarm.Api.Domain.Purchase.Aggregates;

public class Fornecedor
{
    public int Id { get; set; }
    public string? Nome { get; set; }
    public TipoFornecedor Tipo { get; set; }
    public bool Favorito { get; set; }

}
