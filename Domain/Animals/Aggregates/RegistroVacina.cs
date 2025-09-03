using DataFarm.Api.Domain.Shared;

namespace DataFarm.Api.Domain.Animais.Aggregates
{
    public class RegistroVacina
    {
        public Insumo? Insumo { get; set; }
        public DateOnly DataAplicacao { get; set; }
    }
}
