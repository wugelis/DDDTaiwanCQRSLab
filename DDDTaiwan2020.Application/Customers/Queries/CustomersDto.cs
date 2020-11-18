using System;
using System.Collections.Generic;
using System.Text;

namespace DDDTaiwan2020.Application.Customers.Queries
{
    /// <summary>
    /// 提供 Application 層往 Aggregate Root 外面拋 Customers 物件轉換 DTO 時使用
    /// </summary>
    public class CustomersDto: baseDto
    {
        public string CustomerId { get; set; }
        public string CompanyName { get; set; }
        public string ContactName { get; set; }
        public string ContactTitle { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Region { get; set; }
    }
}
