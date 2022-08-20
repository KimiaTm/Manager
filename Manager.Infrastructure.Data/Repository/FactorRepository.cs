﻿using Manager.Core.Contracts.Repository;
using Manager.Core.Domain.Entities;
using Manager.Infrastructure.Data.Common;
using Manager.Infrastructure.EF;

namespace Manager.Infrastructure.Data.Repository
{
    public class FactorRepository : GenericRepository<Factor>, IFactorRepository
    {
        public FactorRepository(ManagerContext Context) : base(Context)
        {
        }
    }
}
