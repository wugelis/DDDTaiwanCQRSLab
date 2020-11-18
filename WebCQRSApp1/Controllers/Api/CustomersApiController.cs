using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDDTaiwan2020.Application.Customers.Commands;
using DDDTaiwan2020.Application.Customers.Queries;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebCQRSApp1.Controllers.Api
{
    public class CustomersApiController : MediatorApiController
    {
        [Route("GetCustomers")]
        public async Task<IEnumerable<CustomersDto>> GetCustomers()
        {
            return await Mediator.Send(new GetCustomersQuery());
        }

        [HttpPost]
        [Route("CreateCustomer")]
        public async Task<int> CreateCustomer(CreateCustomersCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public async Task<int> UpdateCusotmer(UpdateCustomersCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPost]
        [Route("DeleteCustomer")]
        public async Task<int> DeleteCustomer()
        {
            bool food = false;
            if (food.TryFormat(new Span<char>(new char[] { '0'}), out int result))
            {

            }
            return await Task.FromResult<int>(0);
        }
    }
}
