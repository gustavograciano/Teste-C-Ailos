namespace Questao5.Domain.Entities
{
    public class Account
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public bool IsActive { get; set; }
    }
}
