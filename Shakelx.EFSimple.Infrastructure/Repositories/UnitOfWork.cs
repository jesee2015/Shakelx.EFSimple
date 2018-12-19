using Shakelx.EFSimple.Core.Interfaces;
using Shakelx.EFSimple.Infrastructure.DataBase;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shakelx.EFSimple.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly MyDbContext _ctx;
        public UnitOfWork(MyDbContext ctx)
        {
            _ctx = ctx;
        }
        public async Task<bool> SaveAsnycAsync()
        {
            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
