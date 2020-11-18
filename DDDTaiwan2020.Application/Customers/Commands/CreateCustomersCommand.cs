using DDDTaiwan2020.Application.Common.Interfaces;
using DDDTaiwan2020.Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDDTaiwan2020.Application.Customers.Commands
{
    /// <summary>
    /// CQRS Customers 的 Create Command 命令
    /// </summary>
    public class CreateCustomersCommand: IRequest<int>
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public class CreateCustomersCommandHandler : IRequestHandler<CreateCustomersCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;

            public CreateCustomersCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }
            public async Task<int> Handle(CreateCustomersCommand request, CancellationToken cancellationToken)
            {
                CustomersEnt entity = new CustomersEnt();

                entity.CustomerId = request.CustomerID;
                entity.CompanyName = request.CompanyName;
                entity.ContactName = request.ContactName;
                entity.Address = request.Address;
                entity.City = request.City;

                _applicationDbContext.Customers.Add(entity);

                int result = await _applicationDbContext.SaveChangesAsync(cancellationToken);

                return result;
            }
        }
    }
}
