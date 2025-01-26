using System.Collections.Immutable;
using Connected.Academy.Customers.Dtos;
using Connected.Academy.Customers.Ops;
using Connected.Services;

namespace Connected.Academy.Customers;

internal sealed class CustomerService(IServiceProvider services) : Service(services), ICustomerService
{
    public async Task Delete(IPrimaryKeyDto<int> dto)
    {
        await Invoke(GetOperation<Delete>(), dto);
    }

    public async Task<int> Insert(IInsertCustomerDto dto)
    {
        return await Invoke(GetOperation<Insert>(), dto);
    }

    public async Task<IImmutableList<ICustomer>> Query(IQueryDto? dto)
    {
        return await Invoke(GetOperation<Query>(), dto ?? QueryDto.NoPaging);
    }

    public async Task<ICustomer?> Select(IPrimaryKeyDto<int> dto)
    {
        return await Invoke(GetOperation<Select>(), dto);
    }

    public async Task Update(IUpdateCustomerDto dto)
    {
        await Invoke(GetOperation<Update>(), dto);
    }
}
