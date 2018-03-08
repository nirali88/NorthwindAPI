using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthWind.DATA.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDisposed = false;

        ~Disposable()
        {
            Dispose(false);
        }

        private void Dispose(bool isDisposing)
        {
            if (!isDisposed && isDisposing)
                DisposeCore();
            isDisposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void DisposeCore()
        { }
    }
}
