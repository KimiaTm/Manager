using Manager.Core.Contracts.Repository;
using Manager.Core.Domain.Entities;
using Manager.Infrastructure.Data.Common;
using Manager.Infrastructure.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Infrastructure.Data.Repository
{
    public class ProductRepository : GenericRepository<Products>, IProductRepository
    {
        public ProductRepository(ManagerContext Context) : base(Context)
        {
        }
    }
}
