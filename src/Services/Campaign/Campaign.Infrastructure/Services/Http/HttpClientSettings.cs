﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Infrastructure.Services.Http
{
    public class HttpClientSettings
    {
        public string BaseUrl { get; set; }
        public int TimeoutSeconds { get; set; }
    }
}