
using FluentValidator;
using FluentValidator.Validation;

namespace Shop.Shared.Entities
{
    public abstract class Entity : Notifiable
    {
        public Guid Id { get; protected set; }

        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
