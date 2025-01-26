using System;
using Connected.Academy.Customers.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Academy.Customers.Ops;

internal sealed class Insert(IStorageProvider storage, IEventService events, ICustomerService customers, ICustomerCache cache)
    : ServiceFunction<IInsertCustomerDto, int>
{
    protected override async Task<int> OnInvoke()
    {
        var entity = await storage.Open<Customer>().Update(Dto.AsEntity<Customer>(State.New)) ?? throw new NullReferenceException(Strings.ErrEntityExpected);

        await cache.Refresh(entity.Id);
        await events.Inserted(this, customers, entity.Id);

        return entity.Id;
    }
}
