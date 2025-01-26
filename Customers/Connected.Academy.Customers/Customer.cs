using Connected.Annotations;
using Connected.Annotations.Entities;
using Connected.Entities;

namespace Connected.Academy.Customers;

[Table(Schema = CustomersMetaData.Schema)]
internal sealed record Customer : ConsistentEntity<int>, ICustomer
{
    [Ordinal(0), Length(32)]
    public required string FirstName { get; init; }

    [Ordinal(1), Length(64)]
    public required string LastName { get; init; }
}
