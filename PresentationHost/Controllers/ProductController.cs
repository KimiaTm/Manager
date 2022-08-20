using Manager.Core.Contracts.Facade;
using Manager.Core.Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using PresentationHost.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PresentationHost.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductFacade productFacade;
        public ProductsController(IProductFacade productFacade)
        {
            this.productFacade = productFacade;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            ResponseViewModel<IEnumerable<ProductDTO>> model = new ResponseViewModel<IEnumerable<ProductDTO>>();
            try
            {
                model.Data = productFacade.GetAll().ToList();
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }
            return Ok(model);
        }
        [HttpGet]
        [Route("Get/{id}")]
        public IActionResult Get(int id)
        {
            ResponseViewModel<ProductDTO> model = new ResponseViewModel<ProductDTO>();
            try
            {
                model.Data = productFacade.GetById(id);
            }
            catch (InvalidOperationException ex)
            {
                model.AddError("محصول وجود ندارد");
                return NotFound(model);
            }
            return Ok(model);
        }
        [HttpPost]
        public IActionResult PostProduct(ProductDTO product)
        {
            ResponseViewModel<int> model = new ResponseViewModel<int>();
            try
            {
                model.Data = productFacade.Add(product);
            }
            catch (Exception ex)
            {

                model.AddError(ex.Message);
                return BadRequest(model);
            }

            return Created($"/api/product/{model.Data}", model);
        }
        [HttpPut]
        [Route("Edit/{product}")]
        public IActionResult EditProduct(ProductDTO product)
        {
            if (product.ProductId == 0)
            {
                return BadRequest("ID Not Found");
            }
            productFacade.Update(product);
            return Ok(product);
        }
        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            var product = productFacade.GetById(id);
            productFacade.Remove(product);
            return Ok($"/api/product/Delete/{product}");
        }
    }
}
