using NorthWind.DATA.Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NorthWind.Model;

namespace NorthWind.DATA.Repositories
{
    public class ShipperRepository : RepositoryBase<Shipper>, IShipperRepository
    {
        public ShipperRepository(IDbFactory dbFactory) : base(dbFactory)
        {

        }
    }

    public interface IShipperRepository : IRepository<Shipper>
    {

    }
}
