using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Shakelx.EFSimple.Core.Entities;
using Shakelx.EFSimple.Core.Interfaces;
using Shakelx.EFSimple.Infrastructure.DataBase;

namespace Shakelx.EFSimple.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly IProductRepository _productRepository;
        private readonly IUnitOfWork _unitOfWork;
        public ValuesController(IProductRepository productRepository, IUnitOfWork unitOfWork)
        {
            _productRepository = productRepository;
            _unitOfWork = unitOfWork;
        }

        // GET api/values
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var ps = await _productRepository.GetProductsAsync();
            return Ok(ps);
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post()
        {
            var p = new Product { Name = "huawei", Price = 12999 };
            _productRepository.AddProductAsync(p);
            _unitOfWork.SaveAsnycAsync();

        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
