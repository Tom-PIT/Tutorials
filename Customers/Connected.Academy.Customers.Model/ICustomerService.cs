using System;
using System.Collections.Immutable;
using Connected.Academy.Customers.Dtos;
using Connected.Annotations;
using Connected.Services;

namespace Connected.Academy.Customers;

[Service, ServiceUrl(CustomersMetaData.CustomerServiceUrl)]
public interface ICustomerService
{
    [ServiceOperation(ServiceOperationVerbs.Put)]
    Task<int> Insert(IInsertCustomerDto dto);

    [ServiceOperation(ServiceOperationVerbs.Post)]
    Task Update(IUpdateCustomerDto dto);

    [ServiceOperation(ServiceOperationVerbs.Delete)]
    Task Delete(IPrimaryKeyDto<int> dto);

    [ServiceOperation(ServiceOperationVerbs.Get)]
    Task<IImmutableList<ICustomer>> Query(IQueryDto? dto);

    [ServiceOperation(ServiceOperationVerbs.Get)]
    Task<ICustomer?> Select(IPrimaryKeyDto<int> dto);
}
