using CommonLib.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace OA.MVC.Common.Base
{
    public class SzcgOAEngine : IEngine
    {
        private IServiceProvider _serviceProvider;
        public SzcgOAEngine(IServiceProvider serviceProvider)
        {
            this._serviceProvider = serviceProvider;
        }

        public T Resolve<T>() where T : class
        {
            return _serviceProvider.GetService<T>();
        }
    }
}
