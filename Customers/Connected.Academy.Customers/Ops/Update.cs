using Connected.Academy.Customers.Dtos;
using Connected.Entities;
using Connected.Notifications;
using Connected.Services;
using Connected.Storage;

namespace Connected.Academy.Customers.Ops;

internal sealed class Update(IStorageProvider storage, IEventService events, ICustomerService customers, ICustomerCache cache)
    : ServiceAction<IUpdateCustomerDto>
{
    protected override async Task OnInvoke()
    {
        var entity = SetState(await customers.Select(Dto)) as Customer ?? throw new NullReferenceException(Strings.ErrEntityExpected);

        await storage.Open<Customer>().Update(entity.Merge(Dto, State.Default), Dto, async () =>
        {
            await cache.Refresh(Dto.Id);

            return SetState(await customers.Select(Dto)) as Customer ?? throw new NullReferenceException(Strings.ErrEntityExpected);
        }, Caller);

        await cache.Refresh(Dto.Id);
        await events.Updated(this, customers, Dto.Id);
    }
}
