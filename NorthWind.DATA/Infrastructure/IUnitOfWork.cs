using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DATA.Infrastructure
{
    public interface IUnitOfWork
    {
        void Commit();
        IEnumerable<T> SQLQuery<T>(string sql, params object[] parameters);
    }
}
