using System;
using System.Collections.Generic;
using System.Text;

namespace GameId.Domain.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        int SaveChanges();
    }
    
}
