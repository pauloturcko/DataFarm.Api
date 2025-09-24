namespace DataFarm.Api.Domain.Purchase.Enum;
[Flags]
public enum TipoFornecedor
{
    Racao = 1,
    Animais = 2,
    Vacinas = 4,
    OutrosInsumos = 8,
}
