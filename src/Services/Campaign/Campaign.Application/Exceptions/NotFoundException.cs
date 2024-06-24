﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Campaign.Application.Exceptions
{
    public class NotFoundException : ApplicationException
    {
        public NotFoundException()
            : base("Entity is not found")
        {
        }
    }
}
