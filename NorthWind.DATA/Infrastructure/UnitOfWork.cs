using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DATA.Infrastructure
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDbFactory dbFactory;
        private NorthWINDEntities dbContext;

        public UnitOfWork(IDbFactory dbFactory)
        {
            this.dbFactory = dbFactory;
            dbContext = dbFactory.Init();
        }

        public NorthWINDEntities DbContext
        {
            get { return dbContext; }
            //get { return dbContext ?? (dbContext = dbFactory.Init()); }
        }

        public void Commit()
        {
            DbContext.SaveChanges();
        }

        public IEnumerable<T> SQLQuery<T>(string sql, params object[] parameters)
        {
            return dbContext.Database.SqlQuery<T>(sql, parameters);
        }
    }
}
