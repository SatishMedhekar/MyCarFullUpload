﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Formatting;
using System.Web;

namespace MyCarsale.WebHost.Infrastructure
{
    public class OutputFormatter :BufferedMediaTypeFormatter
    {

        public override bool CanReadType(Type type)
        {
            throw new NotImplementedException();
        }

        public override bool CanWriteType(Type type)
        {
            throw new NotImplementedException();
        }

    }
}