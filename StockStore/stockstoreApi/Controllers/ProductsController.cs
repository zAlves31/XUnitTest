using Microsoft.AspNetCore.Mvc;
using stockstoreApi.Domains;
using stockstoreApi.Interfaces;
using stockstoreApi.Repositories;

namespace stockstoreApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private ProductRepository _productRepository { get; set; }

        public ProductsController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {

                return Ok(_productRepository.Listar());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                return Ok(_productRepository.BuscarPorId(id));
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                _productRepository.Deletar(id);

                return StatusCode(204);
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IActionResult Post(Products product)
        {
            try
            {
                _productRepository.Cadastrar(product);

                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid id, Products product)
        {
            try
            {
                _productRepository.Atualizar(id, product);

                return NoContent();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}

