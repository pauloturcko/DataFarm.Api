using DataFarm.Api.Domain.Shared;

namespace DataFarm.Api.Domain.Animais.Aggregates
{
    public class RegistroVacina
    {
        // Foreing Key que aponta para Insumo.cs
        public int InsumoId { get; set; }
        public DateOnly DataAplicacao { get; set; }
    }
}
