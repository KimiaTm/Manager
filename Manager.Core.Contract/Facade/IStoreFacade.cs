using Manager.Core.Domain.DTOs;
using System.Collections.Generic;

namespace Manager.Core.Contracts.Facade
{
    public interface IStoreFacade
    {
        StoreDTO GetById(int id);
        IEnumerable<StoreDTO> GetAll();
        int Add(StoreDTO entity);
        void Remove(StoreDTO entity);
        void Update(StoreDTO entity);
    }
}
