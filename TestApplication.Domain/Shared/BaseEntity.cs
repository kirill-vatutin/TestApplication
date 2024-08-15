namespace TestApplication.Domain.Shared
{
    public abstract class BaseEntity
    {
        public Guid Id { get; private set; }

        protected BaseEntity() { }
    }
}
