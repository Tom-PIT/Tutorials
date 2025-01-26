using System;
using Connected.Annotations;

namespace Connected.Academy.Customers.Dtos;

internal sealed class UpdateCustomerDto : CustomerDto, IUpdateCustomerDto
{
    [MinValue(1)]
    public int Id { get; set; }
}
