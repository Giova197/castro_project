using CastroProgetto.Application.DTO;
using CastroProgetto.Application.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CastroProgetto.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductOutput>>> GetProductsAsync(
            [FromQuery] string category,
            [FromQuery] int? priceLessThan)
            => new JsonResult(
                await _productService.GetProductsAsync(
                    category,
                    priceLessThan)
                .ConfigureAwait(false)
                );

    }
}
