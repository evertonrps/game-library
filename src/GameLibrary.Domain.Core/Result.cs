﻿using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace GameLibrary.Domain.Core
{
    public class Result<T>
    {
        public T Item { get; set; }
        public string Message { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }
}
