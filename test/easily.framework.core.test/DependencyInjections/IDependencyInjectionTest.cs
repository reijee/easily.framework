﻿using easily.framework.core.DependencyInjections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace easily.framework.core.test.DependencyInjections
{
    public interface IDependencyInjectionTest: ITransientDependency
    {
        Task PrintAsync(string message);
    }
}
