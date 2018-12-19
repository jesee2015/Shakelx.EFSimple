using Microsoft.Extensions.Logging;
using Shakelx.EFSimple.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shakelx.EFSimple.Infrastructure.DataBase
{
    public static class MyContextSeed
    {
        public static void Seed(this MyDbContext ctx, ILoggerFactory log)
        {
            if (!ctx.Products.Any())
            {
                ctx.Products.AddRange(new List<Product>
                {
                    new Product{  Name="iphone", Price=7999 },
                    new Product{  Name="xiaomi", Price=2899 },
                });
                ctx.SaveChangesAsync();
            }
        }

    }
}
