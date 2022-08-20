using AutoMapper;
using Manager.Core.Contracts.Facade;
using Manager.Core.Contracts.UnitOfWork;
using Manager.Core.Domain.DTOs;
using Manager.Core.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Manager.Core.ApplicationService.Facade
{
    public class FactorFacade : IFactorFacade
    {
        private readonly IUnitOfWork unitofWork;
        private readonly IMapper mapper;
        public FactorFacade(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(FactorDTO entity)
        {
            Factor factorsDTO = mapper.Map<FactorDTO, Factor>(entity);
            unitofWork.Factor.Add(factorsDTO);
            unitofWork.Save();
            return factorsDTO.FactorId;
        }

        public void Delete(FactorDTO entity)
        {
            Factor factor = mapper.Map<FactorDTO, Factor>(entity);
            unitofWork.Factor.Remove(factor);
            unitofWork.Save();
        }

        public IEnumerable<FactorDTO> GetAll()
        {
            IEnumerable<Factor> factors = unitofWork.Factor.GetAll();
            IEnumerable<FactorDTO> productsDTO = mapper.Map<IEnumerable<Factor>, IEnumerable<FactorDTO>>(factors);
            return productsDTO;
        }

        public FactorDTO GetById(int id)
        {
            Factor factor = unitofWork.Factor.GetById(id);
            FactorDTO factorDTO = mapper.Map<Factor, FactorDTO>(factor);
            return factorDTO;
        }

        public void Update(FactorDTO entity)
        {
            Factor factor = mapper.Map<FactorDTO, Factor>(entity);
            unitofWork.Factor.Update(factor);
            unitofWork.Save();
        }
    }
}
