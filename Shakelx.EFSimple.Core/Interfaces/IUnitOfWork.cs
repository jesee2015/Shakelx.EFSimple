using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Shakelx.EFSimple.Core.Interfaces
{
    public interface IUnitOfWork
    {
        Task<bool> SaveAsnycAsync();
    }
}
