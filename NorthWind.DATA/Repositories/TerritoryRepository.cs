using NorthWind.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Model;

namespace NorthWind.DATA.Repositories
{
    public class TerritoryRepository : RepositoryBase<Territory>, ITerritoryRepository
    {
        public TerritoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }

    public interface ITerritoryRepository : IRepository<Territory>
    {

    }
}
