using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceCore
{
    public interface IUnitOfWork : IDisposable
    {
        void Commit();
        Task<int> CommitAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
