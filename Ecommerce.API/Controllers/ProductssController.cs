using AutoMapper;
using Ecommerce.API.Helper;
using Ecommerce.Core.DTO;
using Ecommerce.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce.API.Controllers
{

    public class ProductssController : BaseController
    {
        public ProductssController(IUnitOfWork uow, IMapper mapper) : base(uow, mapper)
        {
        }
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var products = await _uow.ProductRepository
                    .GetAllAsync(x => x.Category, x => x.Photos);
                if (products == null)
                    return NotFound(new ResponseAPI(404));
                var result = _mapper.Map<List<ProductDTO>>(products);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
