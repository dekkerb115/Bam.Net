﻿using Bam.Net.ServiceProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bam.Net.ServiceProxy
{
    public interface IApplicationNameResolver: IApplicationNameProvider // TODO: move this to Bam.Net
    {
        string ResolveApplicationName(IHttpContext context);
    }
}
