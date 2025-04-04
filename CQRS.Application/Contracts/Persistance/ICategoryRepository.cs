﻿using CQRS.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CQRS.Application.Contracts.Persistance
{
    public interface ICategoryRepository: IAsyncRepository<Category>
    {
    }
}
