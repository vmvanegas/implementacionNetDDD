using Domain.Customers;
using Domain.Primitives;
using Domain.ValueObjects;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Customers.Create
{
    internal sealed class CreateCustomerCommandHandler : IRequestHandler<CreateCustomerCommand, Unit>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IUnitOfWork _unitOfWork;

        public CreateCustomerCommandHandler(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
        {
            _customerRepository = customerRepository ?? throw new ArgumentNullException(nameof(customerRepository));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
        }

        public async Task<Unit> Handle(CreateCustomerCommand command, CancellationToken cancellationToken)
        {
            if(PhoneNumber.Create(command.phoneNumber) is not PhoneNumber phoneNumber)
            {
                throw new ArgumentException(nameof(phoneNumber));
            }

            if (Address.Create(command.country, 
                command.line1, 
                command.line2, 
                command.state, 
                command.city, 
                command.zipCode) is not Address address)
            {
                throw new ArgumentException(nameof(address));
            }

            var customer = new Customer
            (
                new CustomerId(Guid.NewGuid()),
                command.name,
                command.lastName,
                command.email,
                phoneNumber,
                address,
                true
            );

            await _customerRepository.Add(customer);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
