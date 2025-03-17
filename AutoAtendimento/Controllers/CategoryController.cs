using AutoAtendimento.Models;
using AutoAtendimento.Repository.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AutoAtendimento.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController(IUnitOfWork unitOfWork) : Controller
    {
        private readonly IUnitOfWork _unityOfWork = unitOfWork;


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll()
        {
            var categories = await _unityOfWork.CategoryRepository.GetAllAsync();
            return Ok(categories);
        }

        [HttpGet("{id:int}", Name = "GetById")]
        public async Task<ActionResult<Category>> GetCategoryAsync(int id)
        {
            var category = await _unityOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound($"Category not found...");
            }

            return Ok(category);
        }
        [HttpPost]
        public async Task<ActionResult<Category>> Post([FromBody] Category category)
        {

            if (category is null)
            {
                return BadRequest("Dados invalidos");
            }

            _unityOfWork.CategoryRepository.Create(category);
            await _unityOfWork.CommitAsync();
            return Ok(category);
        }


        [HttpPut("{id:int}")]
        public async Task<ActionResult<Category>> PutCategory(int id, [FromBody] Category cat)
        {
            var category = await _unityOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null || cat is null)
            {
                return BadRequest("incosistent data");
            }
            await _unityOfWork.CategoryRepository.UpdateAsync(cat);
            await _unityOfWork.CommitAsync();
            return Ok(cat);
        }

        [HttpDelete("{id:int}", Name = "DeleteCategory")]
        public async Task<ActionResult<Category>> DeleteCategory(int id)
        {
            var category = await _unityOfWork.CategoryRepository.GetByIdAsync(id);
            if (category is null)
            {
                return NotFound("Category not found...");
            }
            await _unityOfWork.CategoryRepository.DeleteAsync(category.Id);
            await _unityOfWork.CommitAsync();
            return Ok(category);
        }
    }
}
