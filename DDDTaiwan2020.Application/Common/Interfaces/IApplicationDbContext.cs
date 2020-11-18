﻿using DDDTaiwan2020.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDDTaiwan2020.Application.Common.Interfaces
{
    /// <summary>
    /// 提供 DI Container 在 CQRS Command 端注入 DbContext 物件
    /// </summary>
    public interface IApplicationDbContext
    {
        DbSet<CustomersEnt> Customers { get; set; }

        Task<int> SaveChangesAsync(CancellationToken cancellationToken);

    }
}
