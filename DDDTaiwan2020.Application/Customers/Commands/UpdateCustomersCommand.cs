using DDDTaiwan2020.Application.Common.Interfaces;
using DDDTaiwan2020.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace DDDTaiwan2020.Application.Customers.Commands
{
    /// <summary>
    /// 
    /// </summary>
    public class UpdateCustomersCommand: IRequest<int>
    {
        public string CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }

        public class UpdateCustomersCommandHandler : IRequestHandler<UpdateCustomersCommand, int>
        {
            private readonly IApplicationDbContext _applicationDbContext;
            public UpdateCustomersCommandHandler(IApplicationDbContext applicationDbContext)
            {
                _applicationDbContext = applicationDbContext;
            }

            public Task<int> Handle(UpdateCustomersCommand request, CancellationToken cancellationToken)
            {
                CustomersEnt entity = _applicationDbContext.Customers
                    .Where(c => c.CustomerId == request.CustomerID)
                    .FirstOrDefault();

                entity.CompanyName = request.CompanyName;
                entity.ContactTitle = request.ContactTitle;
                entity.ContactName = request.ContactName;
                entity.Address = request.Address;

                _applicationDbContext.Customers.Update(entity).State = Microsoft.EntityFrameworkCore.EntityState.Modified;

                return _applicationDbContext.SaveChangesAsync(cancellationToken);
            }
        }
    }
}
