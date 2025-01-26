using System;
using Connected.Caching;

namespace Connected.Academy.Customers;

internal interface ICustomerCache : IEntityCache<Customer, int>
{

}
