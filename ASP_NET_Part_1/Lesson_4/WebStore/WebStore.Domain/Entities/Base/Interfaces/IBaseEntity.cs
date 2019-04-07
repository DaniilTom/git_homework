using System;
using System.Collections.Generic;
using System.Text;

namespace WebStore.Domain.Entities.Base.Interfaces
{
    public interface IBaseEntity
    {
        int Id { get; set; }
    }

    public interface INamedEntity : IBaseEntity
    {
        string Name { get; set; }
    }

    public interface IOrderedEntity
    {
        int Order { get; set; }
    }
}
