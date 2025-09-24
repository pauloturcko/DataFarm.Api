namespace DataFarm.Api.Domain.MeatPrice.Aggregates;

public class Preco
{
    public decimal PrecoAtual { get; set; }
    public DateOnly UltimaAtualizacao { get; set; }
    public decimal DiferencaAnterior { get; set; }
}
