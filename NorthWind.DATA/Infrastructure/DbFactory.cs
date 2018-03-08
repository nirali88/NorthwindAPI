using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DATA.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        NorthWINDEntities dbContext;

        public NorthWINDEntities Init()
        {
            return dbContext ?? (dbContext = new NorthWINDEntities());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null) dbContext.Dispose();
        }
    }
}
