﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    internal class ApplicationAssemblyReference
    {
        internal static readonly Assembly assembly = typeof(ApplicationAssemblyReference).Assembly;
    }
}
