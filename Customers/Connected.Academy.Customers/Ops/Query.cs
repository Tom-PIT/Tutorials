using System;
using System.Collections.Immutable;
using Connected.Entities;
using Connected.Services;

namespace Connected.Academy.Customers.Ops;

internal sealed class Query(ICustomerCache cache)
    : ServiceFunction<IQueryDto, IImmutableList<ICustomer>>
{
    protected override async Task<IImmutableList<ICustomer>> OnInvoke()
    {
        return await cache.AsEntities<ICustomer>();
    }
}
