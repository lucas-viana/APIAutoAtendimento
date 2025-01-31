using AutoAtendimento.Models;
using AutoAtendimento.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AutoAtendimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IUnitOfWork _unitOfWork;

        public ProductController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }



        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllAsync()
        {
            return await _unitOfWork.ProductRepository.GetAllAsync();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);

            if (product is null)
            {
                return NotFound($"Product with id: {id} not found.");
            }
            return Ok(product);
        }

        // POST api/<ProductController>
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] Product product)
        {
            if (product is null)
            {
                return BadRequest("Incosistent data");
            }

            _unitOfWork.ProductRepository.Create(product);
            await _unitOfWork.CommitAsync();
            return Ok(product);
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public async Task<ActionResult<Product>> Put(int id, [FromBody] Product product)
        {
            var productUpdate = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);
            if(product is null || productUpdate is null)
            {
                return BadRequest("Incosistent data");
            }
            _unitOfWork.ProductRepository.Update(product);
            await _unitOfWork.CommitAsync();
            return Ok(product);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Product>> Delete(int id)
        {
            var product = await _unitOfWork.ProductRepository.GetAsync(p => p.Id == id);

            if (product is null)
            {
                return NotFound("Product not found...");
            }

            _unitOfWork.ProductRepository.Delete(product);
            await _unitOfWork.CommitAsync();
            return Ok(product);
        }
    }
}
