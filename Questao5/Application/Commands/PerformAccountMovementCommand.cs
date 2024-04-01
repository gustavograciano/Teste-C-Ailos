using Questao5.Domain.Enumerators;

namespace Questao5.Application.Commands
{
    public class PerformAccountMovementCommand
    {
        public Guid RequestId { get; set; }
        public Guid AccountId { get; set; }
        public decimal Value { get; set; }
        public MovementType Type { get; set; }
    }
}
