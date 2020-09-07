using Microsoft.AspNetCore.Mvc;
using SearchEngine.Business.Interface;
using SearchEngine.WebAPI.Contants;

namespace SearchEngine.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductTypePriorityController : ControllerBase
    {
        private readonly IProductTypePriorityService productTypePriorityService;

        public ProductTypePriorityController(IProductTypePriorityService productTypePriorityService)
        {
            this.productTypePriorityService = productTypePriorityService;
        }

        [HttpGet(nameof(Messages.GetList))]
        public IActionResult GetList()
        {
            var result = productTypePriorityService.GetList();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
