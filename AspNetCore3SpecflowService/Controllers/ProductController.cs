using AspNetCore3SpecflowModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading;
using System.Threading.Tasks;

namespace AspNetCore3SpecflowService.Controllers
{
    [ApiController]
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("[controller]")]
    public class ProductController : Controller
    {


        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<ActionResult<Product>> Create(Product product, CancellationToken cancellationToken)
        {
            product.Id++;
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public virtual async Task<ActionResult<Product>> GetById(int id, CancellationToken cancellationToken = default(CancellationToken))
        {
            if (id < 0) return BadRequest();

            return new Product { Id = 1 };
        }

    }
}
