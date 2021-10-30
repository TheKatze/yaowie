using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Yaowie.Api
{
    public interface IRepository<TEntity, TKey>
    {
        IQueryable<TEntity> Entities { get; }
    }
}
