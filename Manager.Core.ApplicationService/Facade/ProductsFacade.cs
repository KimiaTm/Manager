using AutoMapper;
using Manager.Core.Contracts.Facade;
using Manager.Core.Contracts.UnitOfWork;
using Manager.Core.Domain.DTOs;
using Manager.Core.Domain.Entities;
using System.Collections.Generic;
using System.Text;

namespace Manager.Core.ApplicationService.Facade
{
    public class ProductsFacade : IProductFacade
    {
        private readonly IUnitOfWork unitofWork;
        private readonly IMapper mapper;

        public ProductsFacade(IUnitOfWork unitofWork, IMapper mapper)
        {
            this.unitofWork = unitofWork;
            this.mapper = mapper;
        }
        public int Add(ProductDTO entity)
        {
            Products productsDTO = mapper.Map<ProductDTO, Products>(entity);
            unitofWork.Product.Add(productsDTO);
            unitofWork.Save();
            return productsDTO.ProductId;
        }

        public IEnumerable<ProductDTO> GetAll()
        {
            IEnumerable<Products> products = unitofWork.Product.GetAll();
            IEnumerable<ProductDTO> productsDTO = mapper.Map<IEnumerable<Products>, IEnumerable<ProductDTO>>(products);
            return productsDTO;
        }

        public ProductDTO GetById(int id)
        {
            Products products = unitofWork.Product.GetById(id);
            ProductDTO productsDTO = mapper.Map<Products, ProductDTO>(products);
            return productsDTO;
        }

        public void Remove(ProductDTO entity)
        {
            Products bookDTO = mapper.Map<ProductDTO, Products>(entity);
            unitofWork.Product.Remove(bookDTO);
            unitofWork.Save();
        }

        public void Update(ProductDTO entity)
        {
            Products productsDTO = mapper.Map<ProductDTO, Products>(entity);
            unitofWork.Product.Update(productsDTO);
            unitofWork.Save();
        }
    }
}
