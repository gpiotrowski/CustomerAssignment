﻿using System;
using CustomerAssignment.Customers.Domain.Aggregates;
using CustomerAssignment.Customers.Domain.ValueObjects;

namespace CustomerAssignment.Customers.Domain.Factories
{
    public interface ICustomerFactory
    {
        Customer CreateCustomer(Guid customerId, Name name);
    }
}