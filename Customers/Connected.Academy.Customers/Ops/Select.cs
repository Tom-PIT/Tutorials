using Connected.Entities;
using Connected.Services;

namespace Connected.Academy.Customers.Ops;

internal sealed class Select(ICustomerCache cache)
    : ServiceFunction<IPrimaryKeyDto<int>, ICustomer?>
{
    protected override async Task<ICustomer?> OnInvoke()
    {
        return await cache.AsEntity(f => f.Id == Dto.Id);
    }
}
