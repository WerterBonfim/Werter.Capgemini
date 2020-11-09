using System;
using Werter.Capgemini.WebApi.Core.DomainObjects;

namespace Werter.Capgemini.WebApi.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}