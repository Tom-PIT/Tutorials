using System.ComponentModel.DataAnnotations;
using Connected.Services;

namespace Connected.Academy.Customers.Dtos;

internal abstract class CustomerDto : Dto, ICustomerDto
{
    [Required, MaxLength(32)]
    public required string FirstName { get; set; }

    [Required, MaxLength(64)]
    public required string LastName { get; set; }
}
