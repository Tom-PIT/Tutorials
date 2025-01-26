using System;

namespace Connected.Academy.Customers;

public static class CustomersMetaData
{
    private const string Namespace = "services/academy";
    public const string CustomerServiceUrl = $"{Namespace}/customers";
    public const string CustomersEntityKey = $"{Schema}.{nameof(ICustomer)}";
    public const string Schema = "academy";
}
