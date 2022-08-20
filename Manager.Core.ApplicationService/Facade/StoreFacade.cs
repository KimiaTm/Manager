using AutoMapper;
using Manager.Core.Contracts.Facade;
using Manager.Core.Contracts.UnitOfWork;
using Manager.Core.Domain.DTOs;
using Manager.Core.Domain.Entities;
using System.Collections.Generic;

namespace Manager.Core.ApplicationService.Facade
{
    public class StoreFacade : IStoreFacade
    {
        private readonly IUnitOfWork unitofWork;
        private readonly IMapper mapper;
        public StoreFacade(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }

        public int Add(StoreDTO entity)
        {
           Store store=mapper.Map<StoreDTO,Store>(entity);
            unitofWork.Store.Add(store);
            unitofWork.Save();
            return store.Id;
        }

        public IEnumerable<StoreDTO> GetAll()
        {
            IEnumerable<Store>stores=unitofWork.Store.GetAll();
            IEnumerable<StoreDTO>newStore=mapper.Map<IEnumerable<Store>,IEnumerable<StoreDTO>>(stores);
            return newStore;
        }

        public StoreDTO GetById(int id)
        {
           Store store=unitofWork.Store.GetById(id);
            StoreDTO storeDTO=mapper.Map<Store,StoreDTO>(store);
            return storeDTO;
        }

        public void Remove(StoreDTO entity)
        {
            Store store = mapper.Map<StoreDTO, Store>(entity);
            unitofWork.Store.Remove(store);
            unitofWork.Save();
        }

        public void Update(StoreDTO entity)
        {
            Store store = mapper.Map<StoreDTO, Store>(entity);
            unitofWork.Store.Update(store);
            unitofWork.Save();
        }
    }
}
