namespace Danps.Core.DomainObjects
{
    public abstract class Entity
    {
        protected Entity()
        {
            Id = 0;
        }

        public int Id { get; set; }
    }
}