using System;
using System.Collections.Generic;
using System.Text;

namespace CommonLib.Extensions
{
    public interface IEngine
    {
        T Resolve<T>() where T : class;
    }
}
