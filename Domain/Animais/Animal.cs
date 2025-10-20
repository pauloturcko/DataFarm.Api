using DataFarm.Api.Domain.Animais.Aggregates;
using DataFarm.Api.Domain.Animais.Enum;

namespace DataFarm.Api.Domain.Animais
{
    public class Animal
    {
        public int Id { get; set; }
        public RacaEnum Raca { get; set; }
        public List<Peso> HistoricoPeso { get; init; } = [];
        public List<RegistroVacina> HistoricoVacina { get; init; } = [];
        public DateOnly DataChegada { get; set; }
    }
}
