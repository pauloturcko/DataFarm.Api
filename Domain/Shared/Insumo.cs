using DataFarm.Api.Domain.Shared.Enum;
using DataFarm.Api.Domain.Stock;

namespace DataFarm.Api.Domain.Shared
{
    public class Insumo
    {
        public int Id { get; set; }
        public string? Nome { get; set; }
        public TipoInsumo Tipo { get; set; }
        public double Quantidade { get; set; }
        public int EstoqueId { get; set; }
        public Estoque? Estoque { get; set; }
    }
}
