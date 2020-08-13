using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ServiceCore
{
    public interface IRepository<T> where T : IAggregateRoot
    {
        // Entity Framework - The Repository Pattern - Custom Repositories (p. 525)
        // IQueryable<T> allows LINQ expression trees to flow into the EF4 provider and give the provider a holistic
        // view of the query. A second option would be to return IEnumerable<T>, which means the EF4 LINQ provider will
        // only see the expressions built inside of the repository.Any grouping, ordering, and projection done outside
        // of the repository will not be composed into the SQL command sent to the database, which can hurt
        // performance.
        //
        // c# - Returning IEnumerable<T> vs. IQueryable<T> - Stack Overflow
        // https://stackoverflow.com/questions/2876616/returning-ienumerablet-vs-iqueryablet
        IQueryable<T> FindAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        Task<T> FindByIdAsync(int id);
        T Add(T newEntity);
        void Remove(T entity);

        // Entity Framework - The Repository Pattern (p. 510)
        // The IRepository<T> interface does not expose a Save operation, because we don’t want to persist objects individually.
        IUnitOfWork UnitOfWork { get; }
        // .NET Microservices: Architecture for Containerized .NET Applications - Repository contracts (interfaces) in the domain model layer (p. 225)
    }
}
