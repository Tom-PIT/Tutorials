using System;
using Connected.Services;

namespace Connected.Academy.Customers.Dtos;

public interface ICustomerDto : IDto
{
    string FirstName { get; set; }
    string LastName { get; set; }
}
