using Ecommerce.Core.DTO;
using Ecommerce.Core.Entities.Product;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{
    public class CategoriesController : BaseController
    {
        public CategoriesController(IUnitOfWork uow) : base(uow)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var category = await _uow.CategoryRepository.GetAllAsync();
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {

                return BadRequest(ex.Message);
            }
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            try
            {
                var category = await _uow.CategoryRepository.GetByIdAsync(id);
                if (category == null)
                    return NotFound();
                return Ok(category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPost]
        public async Task<IActionResult> Add(CategoryDTO categoryDto)
        {
            try
            {
                var category = new Category()
                {
                    Name = categoryDto.Name,
                    Description = categoryDto.Description
                };
                await _uow.CategoryRepository.AddAsync(category);
                return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpPut]
        public async Task<IActionResult> update(UpdateCategoryDTO categoryDto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);
                var category = new Category()
                {
                    Description = categoryDto.Description,
                    Name = categoryDto.Name,
                    Id = categoryDto.id

                };
                await _uow.CategoryRepository.UpdateAsync(category);
                return Ok(new { message = "Item Has been updated" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await _uow.CategoryRepository.DeleteAsync(id);
                return Ok(new { message = "Item Has been Deleted" });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
