using CqrsExample.Domain;

namespace CqrsExample.Application;

public interface IRepository<T> where T : AggregateRoot
{
    T GetById(string id);
}