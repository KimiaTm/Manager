using Manager.Core.Domain.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Manager.Core.Contracts.Facade
{
    public interface IProductFacade
    {
        ProductDTO GetById(int id);
        IEnumerable<ProductDTO> GetAll();
        int Add(ProductDTO entity);
        void Remove(ProductDTO entity);
        void Update(ProductDTO entity);
    }


}
