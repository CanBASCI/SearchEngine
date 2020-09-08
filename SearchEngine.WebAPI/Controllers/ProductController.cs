using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using SearchEngine.Business.Interface;
using SearchEngine.WebAPI.Contants;

namespace SearchEngine.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpGet(nameof(Messages.GetList))]
        public IActionResult GetList()
        {
            var result = productService.GetList();

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }

        [HttpGet(nameof(Messages.GetListByText))]
        public IActionResult GetListByText(string text)
        {
            var result = productService.GetListByText(text);

            if (result.IsSuccess)
            {
                return Ok(result.Data);
            }
            return BadRequest(result.Message);
        }
    }
}
