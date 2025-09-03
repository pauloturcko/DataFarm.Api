namespace DataFarm.Api.Domain.Animais
{
    public class Animal
    {
        public int Id { get; set; }
        public RacaEnum Raca { get; set; }
        public List<Peso>? HistoricoPeso { get; set; }
        public DateOnly DataChegada { get; set; }
    }
}
