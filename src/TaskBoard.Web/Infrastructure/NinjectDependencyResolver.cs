using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ninject;

namespace TaskBoard.Web.Infrastructure
{
    public class NinjectDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectDependencyResolver(IKernel kernel)
        {
            _kernel = kernel;
        }

        public object GetService(Type serviceType)
        {
            return _kernel.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            return _kernel.GetAll(serviceType);
        }
    }
}