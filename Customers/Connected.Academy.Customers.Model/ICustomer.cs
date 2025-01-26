using Connected.Entities;

namespace Connected.Academy.Customers;

public interface ICustomer : IEntity<int>
{
    string FirstName { get; init; }
    string LastName { get; init; }
}
