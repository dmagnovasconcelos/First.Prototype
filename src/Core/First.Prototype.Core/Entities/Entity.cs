using System;

namespace First.Prototype.Core.Entities
{
  public abstract class Entity
  {
    public Guid Id { get; set; }

    protected Entity()
    {
      Id = Guid.NewGuid();
    }
  }
}