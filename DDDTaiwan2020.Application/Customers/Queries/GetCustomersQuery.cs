using DDDTaiwan2020.Application.Common.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDDTaiwan2020.Application.Customers.Queries
{
    /// <summary>
    /// 查詢 Northwind 的 Customers 的命令
    /// </summary>
    public class GetCustomersQuery: IRequest<IEnumerable<CustomersDto>>
    {
        public class GetCustomersQueryHandler : IRequestHandler<GetCustomersQuery, IEnumerable<CustomersDto>>
        {
            private readonly IApplicationDbContext _context;

            public GetCustomersQueryHandler(IApplicationDbContext context)
            {
                _context = context;
            }

            public async Task<IEnumerable<CustomersDto>> Handle(GetCustomersQuery request, CancellationToken cancellationToken)
            {
                var result = await (from customer in _context.Customers
                                    select new CustomersDto
                                    {
                                        CustomerId = customer.CustomerId,
                                        CompanyName = customer.CompanyName,
                                        ContactTitle = customer.ContactTitle,
                                        ContactName = customer.ContactName,
                                        Address = customer.Address,
                                        City = customer.City,
                                        Region = customer.Region

                                    }).ToListAsync(cancellationToken);

                return result;
                //return await Task.FromResult<IEnumerable<CustomersDto>>(null);
            }
        }
    }
}
