using Manager.Core.Domain.DTOs;
using System.Collections.Generic;

namespace Manager.Core.Contracts.Facade
{
    public interface IFactorFacade
    {
        FactorDTO GetById(int id);
        IEnumerable<FactorDTO> GetAll();
        int Add(FactorDTO entity);
        void Delete(FactorDTO entity);
        void Update(FactorDTO entity);
    }


}
