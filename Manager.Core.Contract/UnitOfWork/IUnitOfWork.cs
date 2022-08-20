using Manager.Core.Contracts.Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Core.Contracts.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        public IProductRepository Product { get; }
        public IFactorRepository Factor { get; }
        public IStoreRepository Store { get; }
        int Save();
    }
}
