using System;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Academy.Customers.Ops;

internal sealed class Delete(IStorageProvider storage, IEventService events, ICustomerService customers, ICustomerCache cache)
    : ServiceAction<IPrimaryKeyDto<int>>
{
    protected override async Task OnInvoke()
    {
        _ = SetState(await customers.Select(Dto)) as Customer ?? throw new NullReferenceException(Strings.ErrEntityExpected);

        await storage.Open<Customer>().Update(Dto.AsEntity<Customer>(State.Deleted));
        await cache.Remove(Dto.Id);
        await events.Deleted(this, customers, Dto.Id);
    }
}
