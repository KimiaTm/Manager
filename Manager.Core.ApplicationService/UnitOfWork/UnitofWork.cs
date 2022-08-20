using Manager.Core.Contracts.Repository;
using Manager.Core.Contracts.UnitOfWork;
using Manager.Infrastructure.Data.Repository;
using Manager.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Core.ApplicationService.UnitOfWork
{
    public class UnitofWork : IUnitOfWork
    {
        private ManagerContext context;

        public UnitofWork(ManagerContext context)
        {
            this.context = context;
            Product=new ProductRepository(this.context);
            Factor=new FactorRepository(this.context);
            Store=new StoreRepository(this.context);
        }

       
        public IProductRepository Product { get; private set; }

        public IFactorRepository Factor { get; private set; }

        public IStoreRepository Store { get; private set; }

        public void Dispose()
        {
            context.Dispose();
        }

        public int Save()
        {
            return context.SaveChanges();
        }
    }
}
