using Connected.Caching;
using Connected.Storage;

namespace Connected.Academy.Customers;

internal sealed class CustomerCache(ICachingService cache, IStorageProvider storage)
    : EntityCache<Customer, int>(cache, storage, CustomersMetaData.CustomersEntityKey), ICustomerCache
{
}
