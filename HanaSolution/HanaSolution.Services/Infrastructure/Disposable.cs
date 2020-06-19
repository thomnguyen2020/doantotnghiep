using System;

namespace HanaSolution.Services.Infrastructure
{
    public class Disposable : IDisposable
    {
        private bool isDisposed;
        ~Disposable()
        {
            Dispose(false);
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed && disposing)
            {
                DiposeCore();
            }
            isDisposed = true;
        }

        protected virtual void DiposeCore()
        {

        }
    }
}
