
using Amazon.Core.Contract.Services;
using Amazon.Core.Dtos.Identity;
using Amazon.Core.Errors;
using Amazon.Service.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Amazon.Apis.Controllers
{
    public class CategoryController : BaseApiController
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpPost("create")]
        public async Task<ActionResult<UserDto>> CreateCategory([FromBody] LoginDto model)
        {
            try
            {
                var userDto = await _categoryService.create();
                return Ok(userDto);
            }
            catch (ApiExeptionResponse ex)
            {
                return StatusCode(ex.StatusCode, new { message = ex.Message });
            }
        }
    }
}
