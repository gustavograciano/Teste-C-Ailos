using Questao5.Domain.Enumerators;

namespace Questao5.Domain.Entities
{
    public class Movement
    {
        public Guid Id { get; set; }
        public Guid AccountId { get; set; }
        public string Date { get; set; }
        public MovementType Type { get; set; }
        public decimal Value { get; set; }
    }
}
