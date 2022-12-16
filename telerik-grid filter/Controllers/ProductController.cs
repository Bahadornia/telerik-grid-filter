using Common;
using Core.Dtos;
using Core.Entities;
using Infrastracture.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace telerik_grid_filter.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly DataContext context;

        public ProductController(DataContext productContext)
        {
            context = productContext;
        }

        // GET: api/<ValuesController>
        [HttpPost]
        public async Task<IEnumerable<Product>> Get([FromBody] InputDto<Product> input)
        {
            var result = context.Products.ApplyFilter(input.Filter);
            return await result.ToListAsync();
        }
    }
}
