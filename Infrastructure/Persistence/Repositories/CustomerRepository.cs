﻿using Domain.Customers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Repositories
{
    internal class CustomerRepository : ICustomerRepository
    {
        private readonly ApplicationDbContext _context;

        public CustomerRepository(ApplicationDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task Add(Customer customer) => await _context.AddAsync(customer);

        public async Task<Customer> GetByIdAsync(CustomerId id) =>
            await _context.Customers.SingleOrDefaultAsync(c => c.Id == id);
    }
}
