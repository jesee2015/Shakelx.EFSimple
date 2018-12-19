using Microsoft.EntityFrameworkCore;
using Shakelx.EFSimple.Core.Entities;
using Shakelx.EFSimple.Core.Interfaces;
using Shakelx.EFSimple.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakelx.EFSimple.Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly MyDbContext _ctx;
        public ProductRepository(MyDbContext ctx)
        {
            _ctx = ctx;
        }

        public void AddProductAsync(Product product)
        {
            _ctx.Products.AddAsync(product);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _ctx.Products.ToListAsync();
        }
    }
}
