using Microsoft.Win32.SafeHandles;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace CursoBasico.POO_01.Interface
{
    internal class BaseClass : IDisposable
    {

        /*
         * Este es solo un ejemplo de como se utiliza una 
         * interfaz
         * Solo hay que implementar los metodos que contenga esa clase
         */

        //Flag: Has Dispose already been called ?
        bool disposed = false;

        //Instantiate a SafeHandle instance
        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if(disposed)
                return;
            if(disposing)
            {
                handle.Dispose();
                // Free any other managed objects here.

            }

            disposed = true;
        }
    }
}
