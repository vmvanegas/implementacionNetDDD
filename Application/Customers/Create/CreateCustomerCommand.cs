using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Create
{
    public record CreateCustomerCommand(
        string name, 
        string lastName, 
        string email,
        string phoneNumber,
        string country, string line1, string line2, string city, string state, string zipCode,
        bool active
     ) : IRequest<Unit>;
}
