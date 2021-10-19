namespace Framework.Domain.Abstractions
{
    public abstract class AggregateRoot<TKey> : Entity<TKey>
    {

        protected AggregateRoot() { }
        protected AggregateRoot(TKey id) : base(id)
        {
        }

    }
}
